using Common.Extentions;
using MouseExercise.Interfaces;
using MouseExercise.MusExcSet;
using System;
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
            var stateList = this.SharedData.UnitStateList;
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

            // 死亡数をインクリメント.
            this.Current.DeadCount++;

            // クリックされたユニットをDethにして、削除時刻をセット
            stateList[unitIndex] = new MusExcSharedDataUnitState();

            // 時間を増加させる.
            // TODO:基本値をConfigへ出す。難易度で変化させる？
            var increase = 1000;
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
            this.QuestionCount++;

            // クリア回数に応じて難易度を変更.
            var difficulty = DIFFICULTY.VERY_EASY;
            if (5 < this.QuestionCount)
            {
                difficulty = DIFFICULTY.EASY;
            }
            if (10 < this.QuestionCount)
            {
                difficulty = DIFFICULTY.NORMAL;
            }
            if (15 < this.QuestionCount)
            {
                difficulty = DIFFICULTY.HARD;
            }
            if (20 < this.QuestionCount)
            {
                difficulty = DIFFICULTY.VERY_HARD;
            }

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
            this.SharedData.UnitStateList = unitStateArray;
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
            for (int counter =0; counter < int.MaxValue && this.Continue; counter++)
            {
                sharedData.Counter = counter;

                // 現在時刻.
                var now = DateTime.Now;

                // 経過時間(ms)
                var span = (int)(now - this.BeginTime).TotalMilliseconds;

                // 残り時間.
                var remaining = this.GameTime - span;
                if (remaining <= 0)
                {
                    // 終了処理.
                    sharedData.Result = new MusExcSharedDataResult();
                    this.Viewer.ShowSetResult();
                    break;
                }

                // 残り時間をセット.
                sharedData.Remaining = remaining;

                // ユニットステータスリストを捜査.
                var stateList = this.SharedData.UnitStateList;
                for (var ii = 0; ii < stateList.Length; ii++ )
                {
                    var state = stateList[ii];
                    if (null == state)
                    {
                        continue;
                    }

                    // 蘇生フェーズ.
                    // 下記条件を満たしていたらユニットを蘇生.
                    // ・最大数未満.
                    // ・DEADユニット
                    // ・死亡時刻から0.5秒経過している.
                    if ((this.Current.CanCreate()) &&
                        (LIFE_STATE.DEAD == state.LifeState) &&
                        (500 < (DateTime.Now - state.DeadTime).TotalMilliseconds))
                    {
                        // TODO:蘇生をメソッド化する.
                        this.Current.CreateCount++;
                        state.LifeState = LIFE_STATE.LIVING;
                        state.Id = "{0}:{1}".Fmt(this.QuestionCount, this.Current.CreateCount);

                        // TODO:透過度を0にする.
                    }

                    // TODO:未実装
                    // 可能なら透過度を徐々に増加させる
                    // 透過度を変更可能なPictureBoxを作る
                    // フェードイン、フェードアウト機能を実装する.
                    // https://dobon.net/vb/dotnet/graphics/hadeinimage.html

                    // TODO:前回値からの移動量を計算して、新しい座標を設定する.
                    var size = this.Viewer.GetSize();
                    var h = size.Height;
                    var w = size.Width;

                    state.X = w - this.SharedData.Counter * 10 % w;
                    state.Y = this.SharedData.Counter / h + (ii * 50);
                }

                // 描画の更新中でなければ.
                if (this.Viewer.CanViewUpdated())
                {
                    // 描画更新を通知.
                    this.Viewer.ViewUpdate();
                }
                else
                {
                    // 描画更新中.
                    Console.WriteLine("not update >> " + counter);
                }

                Thread.Sleep(MusExc.Conf.ViewUpdateWait);
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
