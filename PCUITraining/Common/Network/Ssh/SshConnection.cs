using Common.Extentions;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Common.Network.Ssh
{
    /// <summary>
    /// SSH接続クラス.
    /// </summary>
    /// <remarks>NuGetでSSH.NETをインストールする必要がある</remarks>
    public class SshConnection
    {
        /// <summary>
        /// sshクライアント.
        /// </summary>
        private SshClient SshClient { get; set; }

        /// <summary>
        /// シェルストリーム.
        /// </summary>
        private ShellStream ShellStream { get; set; }

        /// <summary>
        /// シェルストリームリーダー.
        /// </summary>
        private StreamReader StreamReader { get; set; }

        /// <summary>
        /// シェルストリームライター.
        /// </summary>
        private StreamWriter StreamWriter { get; set; }

        /// <summary>
        /// 出力書き込みI/F
        /// </summary>
        private List<ISshOutputWriter> SshOutputWriter { get; set; }

        /// <summary>
        /// 接続状態.
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        /// 接続中ホスト名.
        /// </summary>
        public string ConnectedHostName { get; private set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public SshConnection()
        {
            SshClient = null;
            ShellStream = null;
            StreamReader = null;
            StreamWriter = null;
            SshOutputWriter = new List<ISshOutputWriter>();
            IsConnected = false;
            ConnectedHostName = string.Empty;
        }

        /// <summary>
        /// 出力書き込みI/Fを追加.
        /// </summary>
        /// <param name="writer"></param>
        public void AddWriter(ISshOutputWriter writer)
        {
            SshOutputWriter.Add(writer);
        }

        /// <summary>
        /// Writerへの出力.
        /// </summary>
        /// <param name="text"></param>
        public void Write(string message)
        {
            if (SshOutputWriter.Count <= 0 || message.IsEmpty())
            {
                return;
            }

            foreach (var writer in SshOutputWriter)
            {
                writer.Write(message);
            }
        }

        /// <summary>
        /// 接続.
        /// </summary>
        /// <param name="strHostName">ホスト名(IPアドレスでも可)</param>
        /// <param name="strLoginId">ログインID</param>
        /// <param name="strPassword">パスワード</param>
        /// <returns></returns>
        public bool Connect(string strHostName, string strLoginId, string strPassword)
        {
            if (!DisConnect())
            {
                Write("ホスト[{0}]との切断に失敗しました".Fmt(ConnectedHostName));
                return false;
            }

            try
            {
                ConnectedHostName = strHostName;

                // 接続情報
                var ConnNfo = new ConnectionInfo(
                    strHostName,
                    22,
                    strLoginId,
                    new AuthenticationMethod[]
                    {
                        new PasswordAuthenticationMethod(strLoginId, strPassword),
                    });

                // SSHクライアント生成
                SshClient = new SshClient(ConnNfo);
                SshClient.ConnectionInfo.Timeout = new TimeSpan(0, 0, 5);

                // SSH接続
                SshClient.Connect();

                // SSH接続.
                if (!SshClient.IsConnected)
                {
                    // 失敗.
                    Write("{0}との接続に失敗しました".Fmt(ConnectedHostName));
                    return false;
                }

                // I/Oストリームの取得.
                ShellStream = SshClient.CreateShellStream(string.Empty, 0, 0, 0, 0, 0);
                StreamReader = new StreamReader(ShellStream, Encoding.GetEncoding("euc-jp"));
                StreamWriter = new StreamWriter(ShellStream, Encoding.GetEncoding("euc-jp"));
                StreamWriter.AutoFlush = true;

                // 読み取り処理をタイマで実行.
                IsConnected = true;
                var timer = new Timer();
                timer.Interval = 500;
                timer.Tick += (sender, e) =>
                {
                    if (!IsConnected)
                    {
                        timer.Stop();
                        return;
                    }

                    Write(StreamReader.ReadToEnd());
                };

                timer.Start();
            }
            catch (Exception ex)
            {
                Write(ex.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// コマンド送信.
        /// </summary>
        /// <param name="strCmd"></param>
        /// <returns></returns>
        public bool Cmd(string strCmd)
        {
            if (null == StreamWriter)
            {
                return false;
            }

            try
            {
                // コマンド実行
                StreamWriter.WriteLine(strCmd);
            }
            catch (Exception ex)
            {
                Write(ex.ToString());
                return false;
            }

            return true;

        }

        /// <summary>
        /// 切断.
        /// </summary>
        /// <returns></returns>
        public bool DisConnect()
        {
            try
            {
                IsConnected = false;

                // クローズ.
                if (null != ShellStream)
                {
                    ShellStream.Dispose();
                    ShellStream = null;
                }

                // SSH切断
                if (null != SshClient)
                {
                    SshClient.Disconnect();
                    SshClient.Dispose();

                    SshClient = null;
                }

                if (!ConnectedHostName.IsEmpty())
                {
                    Write("\n\n{0}との接続を切断しました\n\n".Fmt(ConnectedHostName));
                    ConnectedHostName = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Write(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
