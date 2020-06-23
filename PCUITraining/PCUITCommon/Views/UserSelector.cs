using PCUITCommon.Users;
using System;
using System.Windows.Forms;
using static PCUITCommon.Views.UserIcon;

namespace PCUITCommon.Views
{
    /// <summary>
    /// ユーザー選択コントロール.
    /// </summary>
    public partial class UserSelector : UserControl
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public UserSelector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ユーザーアイコンをセット.
        /// </summary>
        /// <returns>ユーザーアイコングループ</returns>
        public UserIconGrp SetUserIcons(Action<UserData> action = null)
        {
            var userIconGrp = CreateUserIconGrp();

            foreach (var user in PCUIT.UserDataManager.UserDataList)
            {
                var userIcon = userIconGrp.CreateUserIcon(user);
                if (null != action)
                {
                    userIcon.OnSelected += action;
                }
                this.flowUserSelect.Controls.Add(userIcon);
            }

            return userIconGrp;
        }
    }
}

