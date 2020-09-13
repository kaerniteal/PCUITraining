using Common.Conf;

namespace MouseExercise.Configs
{
    /// <summary>
    /// MusExcの設定.
    /// </summary>
    public class MusExcConf : JsonConfBase<MusExcConf>
    {
        /// <summary>
        /// 設定ファイルパスを返す.
        /// </summary>
        /// <returns>設定ファイルのパス</returns>
        public override string GetConfFilePath()
        {
            return @".\Conf\MusExc.conf";
        }

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        public override void SetDefault()
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
    }
}
