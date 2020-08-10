using System;
using System.Collections.Generic;
using System.Drawing;

namespace PCUITCommon.Views
{
    /// <summary>
    /// Bool値を表すラベル.
    /// </summary>
    public partial class BoolLabel : System.Windows.Forms.Label
    {
        /// <summary>
        /// タイプ.
        /// </summary>
        public enum BOOL_LABEL_TYPE
        {
            TYPE_YES_NO,
            TYPE_DO_DONOT,
        }

        /// <summary>
        /// タイプリスト.
        /// </summary>
        private static readonly List<TypeRec> TypeRecList = new List<TypeRec>
        {
            new TypeRec
            {
                Type = BOOL_LABEL_TYPE.TYPE_YES_NO,
                True = @"はい",
                False = @"いいえ"
            },
            new TypeRec
            {
                Type = BOOL_LABEL_TYPE.TYPE_DO_DONOT,
                True = @"する",
                False = @"しない"
            },
        };

        /// <summary>
        /// タイプ.
        /// </summary>
        private TypeRec Type { get; set; }

        /// <summary>
        /// 値.
        /// </summary>
        public bool Value { get; private set; }

        /// <summary>
        /// Trueの色.
        /// </summary>
        public Color TrueColor { get; set; }

        /// <summary>
        /// Falseの色
        /// </summary>
        public Color FalseColor { get; set; }

        /// <summary>
        /// 値変更時のアクション.
        /// </summary>
        private Action<bool> Act { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public BoolLabel() : base()
        {
            this.Type = TypeRecList[0];
            this.TrueColor = Color.Aqua;
            this.FalseColor = Color.Red;
            this.Set(false);
            this.Act = null;

            this.Click += this.OnClick;
        }

        /// <summary>
        /// アイコン使用クリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, EventArgs e)
        {
            this.Set(!this.Value);
        }

        /// <summary>
        /// 初期化.
        /// </summary>
        /// <param name="type">文字列タイプ</param>
        /// <param name="value">値</param>
        /// <param name="act">アクション</param>
        public void Init(BOOL_LABEL_TYPE type, bool value, Action<bool> act = null)
        {
            this.Type = TypeRecList.Find(rec => type == rec.Type);
            this.Act = act;

            this.Set(value);
        }

        /// <summary>
        /// 値のセット.
        /// </summary>
        /// <param name="value">値</param>
        public void Set(bool value)
        {
            this.Value = value;
            this.Text = value
                ? this.Type.True
                : this.Type.False;

            this.ForeColor = value
                ? this.TrueColor
                : this.FalseColor;

            this.Act?.Invoke(this.Value);
        }

        /// <summary>
        /// タイプ毎定義クラス.
        /// </summary>

        private class TypeRec
        {
            /// <summary>
            /// タイプ.
            /// </summary>
            public BOOL_LABEL_TYPE Type { get; set; }

            /// <summary>
            /// True文字列.
            /// </summary>
            public string True { get; set; }

            /// <summary>
            /// False文字列.
            /// </summary>
            public string False { get; set; }
        }
    }
}
