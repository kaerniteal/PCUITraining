using Common.Extentions;
using System;
using System.IO;

namespace MouseExercise.Configs
{
    /// <summary>
    /// MusExcの設定.
    /// </summary>
    public class MusExcConf
    {
        /// <summary>
        /// 設定ファイルパス.
        /// </summary>
        private const string MusExcConfFile = @".\MusExc.conf";

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MusExcConf()
        {
            SetDefault();
        }

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        private void SetDefault()
        {
            // デフォルトはここで与える.
            this.IsOffice = false;
            this.ShowDebugShot = false;
            this.ViewUpdateWait = 100;
            this.UnitMax = 10;
            this.DefaultGameSec = 60000;
            this.RespawnWait = 500;
            this.IncreaseTime = 1000;
            this.AppearanceProbabilityEqual = false;
            this.DiffcultyLvUpCount = 3;
            this.EnableDifficultyVeryEasy = true;
            this.EnableDifficultyEasy = true;
            this.EnableDifficultyNormal = true;
            this.EnableDifficultyHard = true;
            this.EnableDifficultyVeryHard = true;
        }

        /// <summary>
        /// 仕事中モード.
        /// </summary>
        public bool IsOffice { get; set; }

        /// <summary>
        /// デバッグ情報を画面に表示するかどうか.
        /// </summary>
        public bool ShowDebugShot { get; set; }

        /// <summary>
        /// 描画更新Wait(ms)
        /// </summary>
        public int ViewUpdateWait { get; set; }

        /// <summary>
        /// 描画オブジェクト最大数.
        /// </summary>
        public int UnitMax { get; set; }

        /// <summary>
        /// 初期ゲーム時間(ミリ秒)
        /// </summary>
        public int DefaultGameSec { get; set; }

        /// <summary>
        /// リスポーンのウェイト時間(ミリ秒)
        /// </summary>
        public int RespawnWait { get; set; }

        /// <summary>
        /// クリック成功時の増加時間(ミリ秒).
        /// </summary>
        public int IncreaseTime { get; set; }

        /// <summary>
        /// 全てのユニットの出現確立を等しくするかどうか.
        /// </summary>
        public bool AppearanceProbabilityEqual { get; set; }

        /// <summary>
        /// 何設問クリアで難易度が上昇するか.
        /// </summary>
        public int DiffcultyLvUpCount { get; set; }

        /// <summary>
        /// 難易度ベリーイージーが有効かどうか.
        /// </summary>
        public bool EnableDifficultyVeryEasy { get; set; }

        /// <summary>
        /// 難易度イージーが有効かどうか.
        /// </summary>
        public bool EnableDifficultyEasy { get; set; }

        /// <summary>
        /// 難易度ノーマルが有効かどうか.
        /// </summary>
        public bool EnableDifficultyNormal { get; set; }

        /// <summary>
        /// 難易度ハードが有効かどうか.
        /// </summary>
        public bool EnableDifficultyHard { get; set; }

        /// <summary>
        /// 難易度ベリーハードが有効かどうか.
        /// </summary>
        public bool EnableDifficultyVeryHard { get; set; }


        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <remarks>失敗時にはNULLを返す</remarks>
        /// <returns>正答テーブル</returns>
        public static MusExcConf Load()
        {
            var config = new MusExcConf();

            // ファイルの存在をチェックし、存在する場合のみ読み込む。
            if (File.Exists(MusExcConfFile))
            {
                try
                {
                    config = MusExcConfFile.JsonLoad<MusExcConf>();
                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox(@"ファイル[{0}]の読み込みに失敗しました".Fmt(MusExcConfFile));
                }
            }

            // 下記の２ケースを想定して毎回出力する
            // ・読み込んだ設定ファイルに項目が不足している場合.
            // ・設定ファイルが存在しない場合.
            config.Save();

            return config;
        }

        /// <summary>
        /// セーブ処理.
        /// </summary>
        public bool Save()
        {
            try
            {
                this.JsonSave(MusExcConfFile);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox(@"ファイル[{0}]の保存に失敗しました".Fmt(MusExcConfFile));
                return false;
            }

            return true;
        }
    }
}
