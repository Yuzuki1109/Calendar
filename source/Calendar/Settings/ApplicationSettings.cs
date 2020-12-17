using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Calendar.Enums;
using Calendar.Utils;
using Library;
using Windows.Storage;

namespace Calendar.Settings
{
    /// <summary>
    /// アプリケーション設定クラス
    /// </summary>
    public class ApplicationSettings
    {
        #region properties

        /// <summary>
        /// カレンダー言語
        /// </summary>
        public string CalendarLanguage { get; set; }

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
        /// 設定ロード
        /// </summary>
        public static void Load()
        {
            ApplicationDataContainer container = ApplicationData.Current.LocalSettings;

            Type type = typeof(ApplicationSettings);

            foreach (var field in type.GetProperties())
            {
                if (!field.CanWrite) continue;

                if (!container.Values.ContainsKey(field.Name)) continue;

                field.SetValue(Instance, container.Values[field.Name]);
            }

        }

        /// <summary>
        /// 設定保存
        /// </summary>
        public static void Save()
        {
            ApplicationDataContainer container = ApplicationData.Current.LocalSettings;

            container.Values.Clear();

            Type type = typeof(ApplicationSettings);

            foreach (var field in type.GetProperties())
            {
                if (!field.CanWrite) continue;

                container.Values[field.Name] = field.GetValue(Instance);
            }
        }


        #endregion

        #region public

        /// <summary>
        /// 設定リセット
        /// </summary>
        public void Reset()
        {
            CalendarLanguage = Language.de_DE.ToString();
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
