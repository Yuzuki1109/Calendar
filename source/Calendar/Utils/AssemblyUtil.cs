using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Library;
using Windows.Storage;

namespace Calendar.Utils
{
    /// <summary>
    /// アセンブリユーティリティ
    /// </summary>
    public static class AssemblyUtil
    {

        #region public

        // <summary>
        /// バージョン番号
        /// </summary>
        public static string Version
        {
            get
            {
                var hoge = ApplicationData.Current.Version;

                var info = Package.Current.Id.Version;

                return String.Format("v{0}.{1}.{2}.{3}", info.Major, info.Minor, info.Build, info.Revision);
            }
        }

        /// <summary>
        /// バージョン番号
        /// </summary>
        public static ApplicationVersion VersionEnum
        {
            get
            {
                return (ApplicationVersion)Enum.Parse(typeof(ApplicationVersion), Version.Replace(".", "_"));
            }
        }

        /// <summary>
        /// アプリケーション名
        /// </summary>
        public static string AppName { get { return Package.Current.DisplayName; } }

        /// <summary>
        /// テーマ情報
        /// </summary>
        public static ApplicationTheme Theme { get { return Application.Current.RequestedTheme; } }

        /// <summary>
        /// 言語設定
        /// </summary>
        public static String Language { get { return CultureInfo.CurrentUICulture.Name; } }

        #endregion
    }
}