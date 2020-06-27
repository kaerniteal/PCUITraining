using Common.Extentions;
using Common.Utilities;
using MouseExercise.Interfaces;
using MouseExercise.MusExcSet;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc実行クラス.
    /// </summary>
    public class MusExcExecutor : IMusExcExecutor
    {
        /// <summary>
        /// 表示インタフェース.
        /// </summary>
        private IMusExcViewer Viewer { get; set; }

        /// <summary>
        /// 共有データ.
        /// </summary>
        private MusExcSharedData SharedData { get; set; }

        /// <summary>
        /// 処理継続フラグ.
        /// </summary>
        private bool Continue { get; set; }

        /// <summary>
        /// ゲーム開始時間.
        /// </summary>
        private DateTime BeginTime { get; set; }

        /// <summary>
        /// プレイ可能時間(ms)
        /// </summary>
        private int GameTime { get; set; }

        /// <summary>
        /// 設問カウント.
        /// </summary>
        private int QuestionCount { get; set; }

        /// <summary>
        /// 現在の設問データ.
        /// </summary>
        private CurrentQData Current { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="viewer">表示インタフェース</param>
        public MusExcExecutor(IMusExcViewer viewer)
        {
            this.Viewer = viewer;
            this.SharedData = new MusExcSharedData();
            this.Continue = true;
            this.BeginTime = DateTime.Now;
            this.GameTime = 0;
            this.QuestionCount = 0;
            this.Current = new CurrentQData(new MusExcQuestionDef());
        }

        /// <summary>
        /// 処理開始.
        /// </summary>
        /// <param name="sharedData">共有データ</param>
        public void Start(MusExcSharedData sharedData)
        {
            // 共有データをセット.
            this.SharedData = sharedData;

            // ゲーム時間をセット.
            this.GameTime = MusExc.Conf.DefaultGameSec;

            // 実行パラメータを生成.
            var param = new Tuple<IMusExcViewer, MusExcSharedData>(
                this.Viewer,
                this.SharedData);

            // 読み込み処理を別スレッドで実行.
            var thread = new Thread(new ParameterizedThreadStart(this.MusExcExecMain));
            thread.Start(param);

            // 初回の設問定義を取得.
            this.SetQuestion();
        }

        /// <summary>
        /// 入力されたクリック
        /// </summary>
        /// <param name="unitIndex">ユニットIndex</param>
        public void InputClick(int unitIndex)
        {
            var stateList = this.SharedData.UnitStateArray;
            if (stateList.Length <= unitIndex)
            {
                return;
            }

            // クリックされたユニットがDEADなら即リターン.
            var state = stateList[unitIndex];
            if (LIFE_STATE.DEAD == state.LifeState)
            {
                return;
            }

            // クリックされたユニットの情報を結果に格納.
            var deadUnit = stateList[unitIndex];
            this.SharedData.Result.DeadUnitList.Add(deadUnit.DefUnit);

            // 死亡数をインクリメント.
            this.Current.DeadCount++;

            // クリックされたユニットをDethにして、削除時刻をセット
            stateList[unitIndex] = new MusExcSharedDataUnitState();

            // 時間を増加させる.
            var increase = MusExc.Conf.IncreaseTime;
            this.GameTime += increase;
            this.Viewer.ShowClickResult(unitIndex, increase / 1000);

            // 今のクリックが最後の一匹の場合、新しい設問へ.
            if (this.Current.IsFinished())
            {
                this.SetQuestion();
            }
        }

        /// <summary>
        /// 処理停止.
        /// </summary>
        public void Stop()
        {
            this.Continue = false;
        }

        /// <summary>
        /// 設問セット.
        /// </summary>
        public void SetQuestion()
        {
            // クリア回数をインクリメント.
            this.QuestionCount++;

            // クリア回数に応じて難易度を変更.
            var difcIndex = this.QuestionCount / MusExc.Conf.DiffcultyLvUpCount;
            var difficulty = this.GetDifficulty(difcIndex);

            // 設問を取得してセット.
            var qDef = this.Viewer.GetNextQuestionDef(difficulty);
            this.Current = new CurrentQData(qDef);

            // 共有データのユニットデータを初期化.
            var unitStateArray = new MusExcSharedDataUnitState[qDef.UnitNum];
            for (var ii = 0; ii < unitStateArray.Length; ii++)
            {
                // 死亡状態で生成しておく.
                // スレッド処理側で蘇生して貰う.
                unitStateArray[ii] = new MusExcSharedDataUnitState();
            }
            this.SharedData.UnitStateArray = unitStateArray;
        }

        /// <summary>
        /// 難易度を取得.
        /// </summary>
        /// <param name="baseIndex">現在のクリア回数から基準となるIndex</param>
        /// <returns></returns>
        private DIFFICULTY GetDifficulty(int baseIndex)
        {
            // 難易度テーブル.
            var difficultyList = new Tuple<DIFFICULTY, bool>[]
            {
                new Tuple<DIFFICULTY, bool>(DIFFICULTY.VERY_EASY,   MusExc.Conf.EnableDifficultyVeryEasy),
                new Tuple<DIFFICULTY, bool>(DIFFICULTY.EASY,        MusExc.Conf.EnableDifficultyEasy),
                new Tuple<DIFFICULTY, bool>(DIFFICULTY.NORMAL,      MusExc.Conf.EnableDifficultyNormal),
                new Tuple<DIFFICULTY, bool>(DIFFICULTY.HARD,        MusExc.Conf.EnableDifficultyHard),
                new Tuple<DIFFICULTY, bool>(DIFFICULTY.VERY_HARD,   MusExc.Conf.EnableDifficultyVeryHard),
            };

            // 基準を基に、有効な難易度を上げていく.
            for (var ii = baseIndex; ii < difficultyList.Length; ii++)
            {
                var elem = difficultyList[ii];
                if (elem.Item2)
                {
                    return elem.Item1;
                }
            }

            // 有効な難易度がない場合は下げていく.
            for (var ii = baseIndex; 0 < ii; ii--)
            {
                var elem = difficultyList[ii];
                if (elem.Item2)
                {
                    return elem.Item1;
                }
            }

            // 全て無効な場合はランダム.
            return DIFFICULTY.NON;
        }

        /// <summary>
        /// 別スレッドメイン処理.
        /// </summary>
        /// <param name="paramater">パラメータ</param>
        private void MusExcExecMain(object paramater)
        {
            // パラメータを取得.
            var param = paramater as Tuple<IMusExcViewer, MusExcSharedData>;
            if (null == param)
            {
                return;
            }

            var viewer = param.Item1;
            var sharedData = param.Item2;

            // 開始時間を取得.
            this.BeginTime = DateTime.Now;

            // メインループ.
            for (int counter = 0; counter < int.MaxValue && this.Continue; counter++)
            {
                sharedData.Counter = counter;

                // 時刻をセット.
                var now = DateTime.Now;                                     // 現在時刻.
                var span = (int)(now - this.BeginTime).TotalMilliseconds;   // 経過時間(ms)
                var remaining = this.GameTime - span;                       // 残り時間.
                if (remaining <= 0)
                {
                    // 終了処理.
                    sharedData.Result = new MusExcSharedDataResult();
                    this.Viewer.ShowSetResult();
                    break;
                }

                // ゲーム残り時間をセット.
                sharedData.Remaining = remaining;

                // ユニットステータスリストを走査して更新.
                var stateList = this.SharedData.UnitStateArray;
                for (var ii = 0; ii < stateList.Length; ii++)
                {
                    var state = stateList[ii];
                    if (null == state)
                    {
                        continue;
                    }

                    // 蘇生フェーズ.
                    this.Respawn(state);

                    // 移動フェーズ.
                    // 前回値からの移動量を計算して、新しい座標を設定する.
                    // TODO:他のユニットとの重複チェック、重複する場合には移動させない.
                    var mover = MusExcExecutorMovementBase.GetMovement(state.DefUnit.Movement);
                    mover.SetNextPoint(state, this.Viewer.GetSize());

                    // 挙動分を加味して実際の表示位置を決定する.
                    var behavior = MusExcExecutorBehaviorBase.GetBehavior(state.DefUnit.Behavior);
                    behavior.SetViewPoint(state);
                }

                // 描画の更新中でなければ.
                if (this.Viewer.CanViewUpdated())
                {
                    // 描画更新を通知.
                    this.Viewer.ViewUpdate();
                }

                Thread.Sleep(MusExc.Conf.ViewUpdateWait);
            }
        }

        /// <summary>
        /// 蘇生処理.
        /// </summary>
        /// <param name="state">ユニットステータス</param>
        private void Respawn(MusExcSharedDataUnitState state)
        {
            var qDef = this.Current.QDef;

            // 下記条件を満たしていたらユニットを蘇生.
            // ・生成ユニット最大数未満である.
            // ・DEADユニットである
            // ・死亡時刻からリスポーンウェイトを経過している.
            if ((this.Current.CanCreate()) &&
                (LIFE_STATE.DEAD == state.LifeState) &&
                (MusExc.Conf.RespawnWait < (DateTime.Now - state.DeadTime).TotalMilliseconds))
            {
                // 生成カウンタをインクリメント.
                this.Current.CreateCount++;

                // ステータスを生に変更して新しいIDを付与.
                state.LifeState = LIFE_STATE.LIVING;
                state.Id = "{0}:{1}".Fmt(this.QuestionCount, this.Current.CreateCount);

                // どのユニットを生成するのか確率に沿って決定する.
                // 0-99の当たり値を生成する.
                var lottNum = UtilRandom.Next(100);

                // 発生確率の低いものから順に並べる.
                var sorted = qDef.UnitList
                    .OrderBy(u => u.Appearance)
                    .ToList();

                // 確率の低いものから検索して、最初に当たり値を上回ったものを当選とみなす.
                var defUnit = sorted.Find(u => lottNum < u.Appearance);
                if (null == defUnit)
                {
                    defUnit = sorted.Last();
                }

                if (MusExc.Conf.AppearanceProbabilityEqual)
                {
                    // デバッグの際は単純にランダムで選出する.
                    defUnit = qDef.UnitList.GetRandom();
                }

                // 定義を設定.
                state.DefUnit = defUnit;

                // 画像を生成.
                if (MusExc.Conf.IsOffice)
                {
                    state.Image = new Bitmap(@".\MusExcResorce\dummy.jpg");
                }
                else
                {
                    state.Image = new Bitmap(defUnit.UnitImageFilePath);
                }
                state.ImageSize = new Size(
                    state.Image.Size.Width,
                    state.Image.Size.Height);

                // 座標の初期値を設定する.
                // TODO:重複判定、重複した場合には初期位置の再抽選を行う.
                var calculator = MusExcExecutorMovementBase.GetMovement(state.DefUnit.Movement);
                calculator.SetInitPoint(state, this.Viewer.GetSize());
            }
        }

        /// <summary>
        /// 現在の設問中データインナークラス.
        /// </summary>
        private class CurrentQData
        {
            /// <summary>
            /// 設問定義.
            /// </summary>
            public MusExcQuestionDef QDef { get; set; }

            /// <summary>
            /// 生成したユニット数.
            /// </summary>
            public int CreateCount { get; set; }

            /// <summary>
            /// 死亡したユニット数.
            /// </summary>
            public int DeadCount { get; set; }

            /// <summary>
            /// コンストラクタ.
            /// </summary>
            public CurrentQData(MusExcQuestionDef qDef)
            {
                this.QDef = qDef;
                this.CreateCount = 0;
                this.DeadCount = 0;
            }

            /// <summary>
            /// 蘇生可能かどうか.
            /// </summary>
            /// <returns>蘇生可能かどうか</returns>
            public bool CanCreate()
            {
                return this.CreateCount < this.QDef.MaxNum;
            }

            /// <summary>
            /// 終了かどうか.
            /// </summary>
            /// <returns>終了かどうか</returns>
            public bool IsFinished()
            {
                return this.QDef.MaxNum <= this.DeadCount;
            }
        }
    }
}
