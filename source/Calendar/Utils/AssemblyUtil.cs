using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace Calendar.Utils
{
    /// <summary>
    /// アセンブリユーティリティ
    /// </summary>
    public static class AssemblyUtil
    {

        #region public

        /// <summary>
        /// バージョン番号を取得
        /// </summary>
        /// <returns>バージョン番号</returns>
        public static string GetVersion()
        {
            var info = Package.Current.Id.Version;

            return String.Format("v{0}.{1}.{2}.{3}", info.Major, info.Minor, info.Build, info.Revision);
        }

        /// <summary>
        /// アプリケーション名を取得
        /// </summary>
        /// <returns>アプリケーション名</returns>
        public static string GetAppName()
        {
            return Package.Current.DisplayName;
        }

        /// <summary>
        /// テーマ情報を取得
        /// </summary>
        /// <returns>テーマ定義（Light/Dark）</returns>
        public static ApplicationTheme GetTheme()
        {
            return Application.Current.RequestedTheme;
        }

        /// <summary>
        /// 言語設定を取得
        /// </summary>
        /// <returns>言語（en-US、等）</returns>
        public static String GetLanguage()
        {
            return CultureInfo.CurrentUICulture.Name;
        }

        #endregion
    }
}