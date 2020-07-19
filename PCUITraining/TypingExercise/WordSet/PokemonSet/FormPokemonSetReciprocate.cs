using Common.Controls;
using Common.Extentions;
using PCUITCommon.Users;
using PCUITCommon.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static PCUITCommon.Views.UserIcon;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケモンタイプ－データ交換ダイアログ.
    /// </summary>
    public partial class FormPokemonSetReciprocate : Form
    {
        /// <summary>
        /// ユーザーアイコングループ左.
        /// </summary>
        private UserIconGrp UserIconGrpLeft { get; set; }

        /// <summary>
        /// ユーザーアイコングループ右.
        /// </summary>
        private UserIconGrp UserIconGrpRight { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FormPokemonSetReciprocate()
        {
            InitializeComponent();

            // ユーザーアイコンをセット.
            this.UserIconGrpLeft = this.userSelectorLeft.SetUserIcons(this.userIcon_ClickLeft);
            this.UserIconGrpRight = this.userSelectorRight.SetUserIcons(this.userIcon_ClickRight);
        }

        /// <summary>
        /// ユーザーアイコンクリック
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        private void userIcon_ClickLeft(UserData userData)
        {
            // ゲームデータロード.
            this.LoadGameData(this.ctrlPokemonListLeft, userData);
        }

        /// <summary>
        /// ユーザーアイコンクリック
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        private void userIcon_ClickRight(UserData userData)
        {
            // ゲームデータロード.
            this.LoadGameData(this.ctrlPokemonListRight, userData);
        }

        /// <summary>
        /// 表示に反映する.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        private void LoadGameData(CtrlPokemonSetDataViewerList ctrlList, UserData userData)
        {
            var gameData = PokemonSetGameData.Load(userData);
            if (null == gameData)
            {
                return;
            }

            // リストにデータを反映.
            ctrlList.SetNewList(gameData.RecordList);

            // 相互に持っているポケモンの色を変える
            this.ctrlPokemonListLeft.SetOtherSideList(this.ctrlPokemonListRight.OrgList);
            this.ctrlPokemonListRight.SetOtherSideList(this.ctrlPokemonListLeft.OrgList);
        }

        /// <summary>
        /// 交換ボタン.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReciprocate_Click(object sender, EventArgs e)
        {
            var errMsg = string.Empty;

            // 選択状態確認.
            var leftUser = this.UserIconGrpLeft.GetSelectedUserData();
            var leftRec = this.ctrlPokemonListLeft.GetSelected();
            if ((null == leftUser) || (null == leftRec))
            {
                errMsg += "← 左がわのポケモンをえらんでね！\n";
            }

            var rightUser = this.UserIconGrpRight.GetSelectedUserData();
            var rightRec = this.ctrlPokemonListRight.GetSelected();
            if ((null == rightUser) || (null == rightRec))
            {
                errMsg += "右がわのポケモンをえらんでね！ →\n";
            }

            if (!errMsg.IsEmpty())
            {
                FormMessageBox.Show(errMsg);
                return;
            }

            // 両方同じか確認.
            if (leftUser.Name.Equals(rightUser.Name))
            {
                FormMessageBox.Show("どっちも[{0}]だよ！\nちがう人をえらんでね！".Fmt(leftUser.Name));
                return;
            }

            if (leftRec.Name.Equals(rightRec.Name))
            {
                FormMessageBox.Show("どっちも[{0}]だよ！\nちがうポケモンをえらんでね！".Fmt(leftRec.Name));
                return;
            }

            // 確認メッセージ.
            var consent = "{0}の[{1}]と\n{2}の[{3}]を\nこうかんします\n本当にいいですか？".Fmt(
                leftUser.Name,
                leftRec.Name,
                rightUser.Name,
                rightRec.Name);
            if (DialogResult.Yes != FormMessageBox.YesNo(consent))
            {
                return;
            }

            // ダミーの動画.
            var md = new FormMediaPlayer();
            md.Play(@"./TypExcResorce/loading.mp4", 3);

            // 交換処理.
            if (this.DoReciprocate(leftUser, leftRec, rightUser, rightRec))
            {
                // ゲームデータロード.
                this.LoadGameData(this.ctrlPokemonListLeft, leftUser);
                this.LoadGameData(this.ctrlPokemonListRight, rightUser);

                // 交換したポケモンを選択する.
                this.ctrlPokemonListLeft.SetSelected(rightRec.Name);
                this.ctrlPokemonListRight.SetSelected(leftRec.Name);

                // 交換完了
                FormMessageBox.Show("※※※※※※※※※※※※※※※※\n ※※※ 交換が完了しました ※※※\n※※※※※※※※※※※※※※※※");
            }
            else
            {
                // 交換完了
                FormMessageBox.Show("交換に失敗しました！");
            }
        }

        /// <summary>
        /// 交換処理.
        /// </summary>
        /// <param name="leftUser">左ユーザー</param>
        /// <param name="leftRec">左ポケモン</param>
        /// <param name="rightUser">右ユーザー</param>
        /// <param name="rightRec">右ポケモン</param>
        /// <returns>成否</returns>
        private bool DoReciprocate(
            UserData leftUser,
            PokemonSetGameDataRecord leftRec,
            UserData rightUser,
            PokemonSetGameDataRecord rightRec)
        {
            // ゲームデータ取得.
            var leftGame = PokemonSetGameData.Load(leftUser);
            var rightGame = PokemonSetGameData.Load(rightUser);
            if (null == leftGame || null == rightGame)
            {
                return false;
            }

            // 左のユーザーの対象をインクリメント.
            // 右のユーザーの対象をインクリメント.
            // 左のユーザーの対象をデクリメント.
            // 右のユーザーの対象をでクリメント.
            if (!this.Increment(leftGame.RecordList, rightRec.Name) ||
                !this.Increment(rightGame.RecordList, leftRec.Name) ||
                !this.Decrement(leftGame.RecordList, leftRec.Name) ||
                !this.Decrement(rightGame.RecordList, rightRec.Name))
            {
                return false;
            }

            // ゲームデータ保存.
            if (!leftGame.Save(leftUser) || !rightGame.Save(rightUser))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 増加させる.
        /// </summary>
        /// <param name="list">対象ユーザーデータリスト</param>
        /// <param name="name">対象ポケモン</param>
        /// <returns>成否</returns>
        private bool Increment(List<PokemonSetGameDataRecord> list, string name)
        {
            var target = list.Find(rec => name.Equals(rec.Name));
            if (null == target)
            {
                // 新規追加.
                list.Add(new PokemonSetGameDataRecord
                {
                    Name = name,
                    CapturCount = 1,
                    ShortestTime = 0,
                });
            }
            else
            {
                // 既に持っている.
                target.CapturCount++;
            }

            return true;
        }

        /// <summary>
        /// 減少させる.
        /// </summary>
        /// <param name="list">対象ユーザーデータリスト</param>
        /// <param name="name">対象ポケモン</param>
        /// <returns>成否</returns>
        private bool Decrement(List<PokemonSetGameDataRecord> list, string name)
        {
            var target = list.Find(rec => name.Equals(rec.Name));
            if (null == target)
            {
                return false;
            }
            else
            {
                // 既に持っている.
                target.CapturCount--;
            }

            return true;
        }

        /// <summary>
        /// 閉じるボタン.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
