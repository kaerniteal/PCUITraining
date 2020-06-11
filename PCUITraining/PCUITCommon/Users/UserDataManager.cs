using Common.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PCUITCommon.Users
{
    /// <summary>
    /// ユーザーデータ管理.
    /// </summary>
    public class UserDataManager
    {
        /// <summary>
        /// ユーザーデータ格納フォルダのルートパス.
        /// </summary>
        public static readonly string RootPath = @".\UserData\";

        /// <summary>
        /// ユーザーデータリスト.
        /// </summary>
        public List<UserData> UserDataList { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public UserDataManager()
        {
            this.UserDataList = new List<UserData>();
        }

        /// <summary>
        /// 全て読み込み
        /// </summary>
        /// <returns>成否</returns>
        public bool LoadUserDataAll()
        {
            this.CreateRoot();

            try
            {
                // ユーザーデータロード.
                this.UserDataList = Directory.GetDirectories(RootPath)
                    .Select(folder => Path.GetFileName(folder))
                    .Select(user => UserData.Load(user))
                    .ToList();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("ユーザーデータの取得に失敗しました");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 全て保存
        /// </summary>
        /// <returns>成否</returns>
        public bool SaveAll()
        {
            this.CreateRoot();

            foreach (var userData in this.UserDataList)
            {
                if (!userData.Save())
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 個別に保存
        /// </summary>
        /// <returns>成否</returns>
        public bool Save(string name)
        {
            this.CreateRoot();

            var userData = this.UserDataList
                .Find(user => name.Equals(user.Name));

            if (null == userData)
            {
                MessageBox.Show("[{0}]のユーザーデータが存在しません".Fmt(name));
            }

            if (!userData.Save())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ユーザーデータの保存先が無ければ作成する.
        /// </summary>
        private void CreateRoot()
        {
            try
            {
                if (!Directory.Exists(RootPath))
                {
                    // 存在しない場合は生成.
                    Directory.CreateDirectory(RootPath);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("ユーザーデータディレクトリの作成に失敗しました。");
            }
        }
    }
}
