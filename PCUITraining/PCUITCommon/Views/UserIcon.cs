using PCUITCommon.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PCUITCommon.Views
{
    /// <summary>
    /// ユーザーアイコン表示コントロール.
    /// </summary>
    public partial class UserIcon : UserControl
    {
        /// <summary>
        /// 自身が所属するグループ.
        /// </summary>
        private UserIconGrp Grp { get; set; }

        /// <summary>
        /// ユーザーデータ.
        /// </summary>
        public UserData UserData { get; private set; }

        /// <summary>
        /// 選択状態.
        /// </summary>
        private bool Selected { get; set; }

        /// <summary>
        /// 選択されたときに呼び出される.
        /// </summary>
        public Action<UserData> OnSelected { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        private UserIcon(UserIconGrp grp, UserData userData)
        {
            InitializeComponent();

            this.Grp = grp;
            this.UserData = userData;
            this.Selected = false;

            var lblName = new Label();
            lblName.BackColor = Color.Transparent;
            lblName.Font = PCUIT.GetFont(18);
            lblName.Dock = DockStyle.Fill;
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            lblName.Click += new EventHandler(this.pBox_Click);
            this.pBox.Controls.Add(lblName);

            lblName.Text = this.UserData.Name;
            lblName.ForeColor = this.UserData.GetFontColor();
            if (this.UserData.UseCustomIcon)
            {
                this.pBox.Image = userData.LoadIcon();
            }
        }

        /// <summary>
        /// 選択状態をセットする.
        /// </summary>
        /// <param name="selected">選択状態</param>
        public void SetSelected(bool selected)
        {
            this.Selected = selected;
            this.BackColor = (selected)
                ? Color.Gold
                : Color.DimGray;

            if (selected && null != this.OnSelected)
            {
                this.OnSelected(this.UserData);
            }
        }

        /// <summary>
        /// クリックイベントの取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBox_Click(object sender, EventArgs e)
        {
            // 全てを一度非選択にしてから
            this.Grp.Clear();

            // 自分を選択にする.
            this.SetSelected(true);
        }

        /// <summary>
        /// ユーザーアイコングループを生成する.
        /// </summary>
        /// <returns></returns>
        public static UserIconGrp CreateUserIconGrp()
        {
            return new UserIconGrp();
        }

        /// <summary>
        /// UserIcon管理クラス.
        /// </summary>
        public class UserIconGrp
        {
            /// <summary>
            /// ユーザーアイコンクラスリスト.
            /// </summary>
            private List<UserIcon> UserIconList { get; set; }

            /// <summary>
            /// コンストラクタ.
            /// </summary>
            public UserIconGrp()
            {
                UserIconList = new List<UserIcon>();
            }

            /// <summary>
            /// ユーザーアイコンを生成する.
            /// </summary>
            /// <param name="userData">ユーザーデータ</param>
            /// <returns>ユーザーアイコン</returns>
            public UserIcon CreateUserIcon(UserData userData)
            {
                var userIcon = new UserIcon(this, userData);
                this.UserIconList.Add(userIcon);
                return userIcon;
            }

            /// <summary>
            /// グループの選択状態を全て解除する.
            /// </summary>
            public void Clear()
            {
                foreach (var icon in this.UserIconList)
                {
                    icon.SetSelected(false);
                }
            }

            /// <summary>
            /// 選択されているユーザーを取得する.
            /// </summary>
            /// <returns>選択されているユーザーデータ</returns>
            public UserData GetSelectedUserData()
            {
                foreach (var userIcon in UserIconList)
                {
                    if (userIcon.Selected)
                    {
                        return userIcon.UserData;
                    }
                }

                return null;
            }

            /// <summary>
            /// ユーザーデータを指定して選択状態にする.
            /// </summary>
            /// <param name="userData">選択状態にしたいユーザー</param>
            public void SetSelected(UserData userData)
            {
                this.Clear();

                foreach (var userIcon in UserIconList)
                {
                    if (userIcon.UserData.Equals(userData))
                    {
                        userIcon.SetSelected(true);
                        return;
                    }
                }
            }
        }
    }
}
