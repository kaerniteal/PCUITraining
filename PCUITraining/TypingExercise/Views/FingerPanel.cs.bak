using Common.Extentions;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static TypingExercise.Definitions.TypExcEnums;

namespace TypingExercise.Views
{
    /// <summary>
    /// 指パネル
    /// </summary>
    public partial class FingerPanel : UserControl
    {
        /// <summary>
        /// KEY-指対応リスト
        /// </summary>
        private static List<KeyFinger> KeyFingerList = new List<KeyFinger>
        {
            // 上段.
            new KeyFinger(@"1", FINGER.LEFT_LITTLE),
            new KeyFinger(@"2", FINGER.LEFT_RING),
            new KeyFinger(@"3", FINGER.LEFT_MIDDLE),
            new KeyFinger(@"4", FINGER.LEFT_INDEX),
            new KeyFinger(@"5", FINGER.LEFT_INDEX),
            new KeyFinger(@"6", FINGER.RIGHT_INDEX),
            new KeyFinger(@"7", FINGER.RIGHT_INDEX),
            new KeyFinger(@"8", FINGER.RIGHT_MIDDLE),
            new KeyFinger(@"9", FINGER.RIGHT_RING),
            new KeyFinger(@"0", FINGER.RIGHT_LITTLE),
            new KeyFinger(@"-", FINGER.RIGHT_LITTLE),
            new KeyFinger(@"^", FINGER.RIGHT_LITTLE),
            new KeyFinger(@"\", FINGER.RIGHT_LITTLE),

            // 中断上
            new KeyFinger(@"q", FINGER.LEFT_LITTLE),
            new KeyFinger(@"w", FINGER.LEFT_RING),
            new KeyFinger(@"e", FINGER.LEFT_MIDDLE),
            new KeyFinger(@"r", FINGER.LEFT_INDEX),
            new KeyFinger(@"t", FINGER.LEFT_INDEX),
            new KeyFinger(@"y", FINGER.RIGHT_INDEX),
            new KeyFinger(@"u", FINGER.RIGHT_INDEX),
            new KeyFinger(@"i", FINGER.RIGHT_MIDDLE),
            new KeyFinger(@"o", FINGER.RIGHT_RING),
            new KeyFinger(@"p", FINGER.RIGHT_LITTLE),
            new KeyFinger(@"@", FINGER.RIGHT_LITTLE),
            new KeyFinger(@"[", FINGER.RIGHT_LITTLE),

            // 中段下
            new KeyFinger(@"a", FINGER.LEFT_LITTLE),
            new KeyFinger(@"s", FINGER.LEFT_RING),
            new KeyFinger(@"d", FINGER.LEFT_MIDDLE),
            new KeyFinger(@"f", FINGER.LEFT_INDEX),
            new KeyFinger(@"g", FINGER.LEFT_INDEX),
            new KeyFinger(@"h", FINGER.RIGHT_INDEX),
            new KeyFinger(@"j", FINGER.RIGHT_INDEX),
            new KeyFinger(@"k", FINGER.RIGHT_MIDDLE),
            new KeyFinger(@"l", FINGER.RIGHT_RING),
            new KeyFinger(@";", FINGER.RIGHT_LITTLE),
            new KeyFinger(@":", FINGER.RIGHT_LITTLE),
            new KeyFinger(@"]", FINGER.RIGHT_LITTLE),

            // 下段
            new KeyFinger(@"z", FINGER.LEFT_LITTLE),
            new KeyFinger(@"x", FINGER.LEFT_RING),
            new KeyFinger(@"c", FINGER.LEFT_MIDDLE),
            new KeyFinger(@"v", FINGER.LEFT_INDEX),
            new KeyFinger(@"b", FINGER.LEFT_INDEX),
            new KeyFinger(@"n", FINGER.RIGHT_INDEX),
            new KeyFinger(@"m", FINGER.RIGHT_INDEX),
            new KeyFinger(@",", FINGER.RIGHT_MIDDLE),
            new KeyFinger(@".", FINGER.RIGHT_RING),
            new KeyFinger(@"/", FINGER.RIGHT_LITTLE),
            new KeyFinger(@"_", FINGER.RIGHT_LITTLE),
        };

        /// <summary>
        /// 指画像表示ピクチャーボックスリスト.
        /// </summary>
        private List<FingerPicture> FingerPictureList = new List<FingerPicture>
        {
            new FingerPicture(FINGER.LEFT_LITTLE,  @"TypExcResorce\left1on.png",  @"TypExcResorce\left1off.png"),
            new FingerPicture(FINGER.LEFT_RING,    @"TypExcResorce\left2on.png",  @"TypExcResorce\left2off.png"),
            new FingerPicture(FINGER.LEFT_MIDDLE,  @"TypExcResorce\left3on.png",  @"TypExcResorce\left3off.png"),
            new FingerPicture(FINGER.LEFT_INDEX,   @"TypExcResorce\left4on.png",  @"TypExcResorce\left4off.png"),
            new FingerPicture(FINGER.RIGHT_INDEX,  @"TypExcResorce\right1on.png", @"TypExcResorce\right1off.png"),
            new FingerPicture(FINGER.RIGHT_MIDDLE, @"TypExcResorce\right2on.png", @"TypExcResorce\right2off.png"),
            new FingerPicture(FINGER.RIGHT_RING,   @"TypExcResorce\right3on.png", @"TypExcResorce\right3off.png"),
            new FingerPicture(FINGER.RIGHT_LITTLE, @"TypExcResorce\right4on.png", @"TypExcResorce\right4off.png"),
        };

        /// <summary>
        /// KEYマップ.
        /// </summary>
        private Dictionary<string, FingerPicture> KeyMap { get; set; }

        /// <summary>
        /// 最後に点燈した指.
        /// </summary>
        private FingerPicture LastLightFinger { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FingerPanel()
        {
            InitializeComponent();

            this.KeyMap = new Dictionary<string, FingerPicture>();
            this.LastLightFinger = null;

            // 指画像表示ピクチャーボックスリストを作る.
            foreach (var fp in this.FingerPictureList)
            {
                switch (fp.Finger)
                {
                    case FINGER.LEFT_LITTLE:  fp.PBox = this.pBoxLeft1; break;
                    case FINGER.LEFT_RING:    fp.PBox = this.pBoxLeft2; break;
                    case FINGER.LEFT_MIDDLE:  fp.PBox = this.pBoxLeft3; break;
                    case FINGER.LEFT_INDEX:   fp.PBox = this.pBoxLeft4; break;
                    case FINGER.RIGHT_INDEX:  fp.PBox = this.pBoxRight1; break;
                    case FINGER.RIGHT_MIDDLE: fp.PBox = this.pBoxRight2; break;
                    case FINGER.RIGHT_RING:   fp.PBox = this.pBoxRight3; break;
                    case FINGER.RIGHT_LITTLE: fp.PBox = this.pBoxRight4; break;
                }
            }
        }

        /// <summary>
        /// KeyMapをセットする.
        /// </summary>
        public void SetKeyMap()
        {
            this.KeyMap.Clear();

            foreach (var keyFinger in KeyFingerList)
            {
                var fpBox = this.FingerPictureList
                    .Find(fp => fp.Finger == keyFinger.Finger);
                if (null == fpBox)
                {
                    continue;
                }

                this.KeyMap.Add(keyFinger.Key, fpBox);
            }

            foreach(var fp in this.FingerPictureList)
            {
                fp.Off();
            }
        }

        /// <summary>
        /// 有効なKEYを点燈.
        /// </summary>
        /// <param name="spelling">スペル</param>
        public void SetLightFinger(string spelling)
        {
            if (null != this.LastLightFinger)
            {
                LastLightFinger.Off();
            }

            if (spelling.IsEmpty())
            {
                return;
            }

            // KEYと一致する指を点灯.
            var key = spelling.Substring(0, 1);
            if (this.KeyMap.ContainsKey(key))
            {
                this.LastLightFinger = this.KeyMap[key];
                this.LastLightFinger.On();
            }
        }


        /// <summary>
        /// KEYと指の対応を格納するインナークラス.
        /// </summary>
        private class KeyFinger
        {
            /// <summary>
            /// KEY文字列.
            /// </summary>
            public string Key { get; set; }

            /// <summary>
            /// 対象指.
            /// </summary>
            public FINGER Finger { get; set; }

            /// <summary>
            /// コンストラクタ.
            /// </summary>
            /// <param name="key">KEY文字列</param>
            /// <param name="finger">対応指</param>
            public KeyFinger(string key, FINGER finger)
            {
                this.Key = key;
                this.Finger = finger;
            }
        }

        /// <summary>
        /// 指画像を表示するパネル.
        /// </summary>
        private class FingerPicture
        {
            /// <summary>
            /// 指.
            /// </summary>
            public FINGER Finger { get; set; }

            /// <summary>
            /// ON画像
            /// </summary>
            public string OnImage { get; set; }

            /// <summary>
            /// ON画像
            /// </summary>
            public string OffImage { get; set; }

            /// <summary>
            /// 指画像を表示.
            /// </summary>
            public PictureBox PBox { get; set; }

            /// <summary>
            /// コンストラクタ.
            /// </summary>
            /// <param name="finger">指</param>
            /// <param name="onImage">ONイメージ</param>
            /// <param name="offImage">OFFイメージ</param>
            public FingerPicture(FINGER finger, string onImage, string offImage)
            {
                this.Finger = finger;
                this.OnImage = onImage;
                this.OffImage = offImage;
                this.PBox = null;
            }

            /// <summary>
            /// ONにする.
            /// </summary>
            public void On()
            {
                if (null == this.PBox)
                {
                    return;
                }

                this.PBox.Image = new Bitmap(this.OnImage);
            }

            /// <summary>
            /// OFFにする.
            /// </summary>
            public void Off()
            {
                if (null == this.PBox)
                {
                    return;
                }

                this.PBox.Image = new Bitmap(this.OffImage);
            }
        }
    }
}
