using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TypingExercise.Common.Extentions;

namespace TypingExercise.Forms
{
    /// <summary>
    /// キーボードパネル.
    /// </summary>
    public partial class KeyboardPanel : UserControl
    {
        /// <summary>
        /// テーブルレイアウトリスト(上段～下段の４つ)
        /// </summary>
        private List<TableLayoutPanel> TableSections { get; set; }

        /// <summary>
        /// KEYテーブル.
        /// </summary>
        private static readonly List<List<string>> KeyTable = new List<List<string>>
        {
            // 上段
            new List<string>
            {
                @"1",
                @"2",
                @"3",
                @"4",
                @"5",
                @"6",
                @"7",
                @"8",
                @"9",
                @"0",
                @"-",
                @"^",
                @"\",
            },

            // 中段上
            new List<string>
            {
                null,
                @"q",
                @"w",
                @"e",
                @"r",
                @"t",
                @"y",
                @"u",
                @"i",
                @"o",
                @"p",
                @"@",
                @"[",
            },

            // 中段下
            new List<string>
            {
                null,
                @"a",
                @"s",
                @"d",
                @"f",
                @"g",
                @"h",
                @"j",
                @"k",
                @"l",
                @";",
                @":",
                @"]",
            },

            // 下段
            new List<string>
            {
                null,
                @"z",
                @"x",
                @"c",
                @"v",
                @"b",
                @"n",
                @"m",
                @",",
                @".",
                @"/",
                @"_",
            },
        };

        /// <summary>
        /// KEYマップ.
        /// </summary>
        private Dictionary<string, Label> KeyMap { get; set; }

        /// <summary>
        /// 最後に点燈したKEY.
        /// </summary>
        private Label LastLightKey { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public KeyboardPanel()
        {
            InitializeComponent();

            this.TableSections = new List<TableLayoutPanel>
            {
                this.tableKeyboard1,
                this.tableKeyboard2,
                this.tableKeyboard3,
                this.tableKeyboard4,
            };

            this.KeyMap = new Dictionary<string, Label>();

            this.LastLightKey = null;

            this.TabStop = false;
        }

        /// <summary>
        /// KeyMapをセットする.
        /// </summary>
        /// <param name="upper"></param>
        public void SetKeyMap(bool upper = false)
        {
            // ラベルをセット.
            var font = PCUIT.GetFont(PCUIT.TypExc.Conf.KeyBoardFontSize);
            for (var ii = 0; ii < KeyTable.Count; ii++)
            {
                var section = KeyTable[ii];
                var table = this.TableSections[ii];
                for (var jj = 0; jj < section.Count; jj++)
                {
                    var key = section[jj];
                    if (null != key)
                    {
                        var keyLabel = new Label();
                        if (upper)
                        {
                            keyLabel.Text = key.ToUpper();
                        }
                        else
                        {
                            keyLabel.Text = key;
                        }
                        keyLabel.Dock = DockStyle.Fill;
                        keyLabel.Font = font;
                        keyLabel.TextAlign = ContentAlignment.MiddleCenter;
                        keyLabel.ForeColor = Color.Black;
                        SetLight(keyLabel, false);
                        table.Controls.Add(keyLabel, jj, 0);

                        // マップに登録しておく.
                        this.KeyMap.Add(key, keyLabel);
                    }
                }
            }
        }

        /// <summary>
        /// 有効なKEYを点燈.
        /// </summary>
        /// <param name="spelling">スペル</param>
        public void SetLightKey(string spelling)
        {
            if (null != this.LastLightKey)
            {
                SetLight(this.LastLightKey, false);
            }

            if (spelling.IsEmpty())
            {
                return;
            }

            var key = spelling.Substring(0, 1);
            var label = new Label();
            if (this.KeyMap.TryGetValue(key, out label))
            {
                SetLight(label, true);
                this.LastLightKey = label;
            }
        }

        /// <summary>
        /// KEYの点燈.
        /// </summary>
        /// <param name="label"><対象KEYのLabel/param>
        /// <param name="light">点燈状態.</param>
        private static void SetLight(Label label, bool light)
        {
            if (light)
            {
                label.BackColor = Color.Yellow;
            }
            else
            {
                label.BackColor = Color.DimGray;
            }
        }
    }
}
