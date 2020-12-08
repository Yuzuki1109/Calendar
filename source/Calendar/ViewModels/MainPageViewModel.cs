using Calendar.Utils;
using Calendar.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Calendar.ViewModels
{
    /// <summary>
    /// MainPage用ViewModel
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="mainPage">メインページ</param>
        public void Initialize(MainPage mainPage)
        {
            View = mainPage;

            CalendarDisplayMode = CalendarViewDisplayMode.Month;
        }

        #region view

        /// <summary>
        /// 対象view
        /// </summary>
        public MainPage View { get; private set; } = null;

        #endregion

        #region Binding

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title
        {
            get
            {
                return String.Format("{0} - {1}", AssemblyUtil.GetAppName(), AssemblyUtil.GetVersion());
            }
        }

        private string calendarLanguage;
        /// <summary>
        /// カレンダーの言語設定
        /// </summary>
        public string CalendarLanguage
        {
            get { return AssemblyUtil.GetLanguage(); }

            set { Set(ref this.calendarLanguage, value, nameof(CalendarLanguage)); }
        }

        private CalendarViewDisplayMode calendarDisplayMode;

        /// <summary>
        /// カレンダー表示モード
        /// </summary>
        public CalendarViewDisplayMode CalendarDisplayMode
        {
            get { return calendarDisplayMode; }

            set
            {
                Set(ref this.calendarDisplayMode, value, nameof(CalendarDisplayMode));

                switch (value)
                {
                    case CalendarViewDisplayMode.Month:
                        CalendarHeaderHeight = 85;
                        break;

                    default:
                        CalendarHeaderHeight = 50;
                        break;
                }
            }
        }

        private int calendarHeaderHeight;
        /// <summary>
        /// カレンダーヘッダー部分高さ
        /// </summary>
        public int CalendarHeaderHeight
        {
            get { return calendarHeaderHeight; }

            set { Set(ref this.calendarHeaderHeight, value, nameof(CalendarHeaderHeight)); }
        }

        #endregion
    }
}
