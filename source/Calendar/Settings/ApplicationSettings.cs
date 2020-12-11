using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Calendar.Enums;
using Calendar.Utils;
using Library;

namespace Calendar.Settings
{
    /// <summary>
    /// アプリケーション設定クラス
    /// </summary>
    [Serializable]
    public class ApplicationSettings : SettingBase
    {
        #region properties

        /// <summary>
        /// カレンダーの言語
        /// </summary>
        public string CalendarLanguageStr { get; set; }

        /// <summary>
        /// カレンダー言語
        /// </summary>
        [XmlIgnore]
        public Language CalendarLanguage
        {
            get { return (Language)Enum.Parse(typeof(Language), CalendarLanguageStr); }

            set { CalendarLanguageStr = value.ToString(); }
        }

        private static ApplicationSettings instance;

        /// <summary>
        /// インスタンスを取得
        /// </summary>
        public static ApplicationSettings Instance
        {
            get
            {
                if (instance == null) instance = new ApplicationSettings();

                return instance;
            }
        }

        #endregion

        #region static

        /// <summary>
        /// 設定ファイルロード
        /// </summary>
        public static async void Load()
        {
            string path = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "fuga.xml");

            try
            {
                await FileUtil.Serialize(new ApplicationSettings(), path);
            }
            catch (Exception e)
            {
                SeriLogger.Error(e);

                
            }


        }


        #endregion

        #region public

        public void Reset()
        {
            CalendarLanguage = Language.de_DE;
        }

        #endregion

        #region private

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private ApplicationSettings()
        {
            Reset();
        }

        #endregion
    }
}
