﻿using Calendar.Utils;
using Calendar.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Calendar.Settings;
using Calendar.Enums;

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

            CalendarLanguage = ApplicationSettings.Instance.CalendarLanguage;


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
                return String.Format("{0} - {1}", AssemblyUtil.AppName, AssemblyUtil.Version);
            }
        }

        private string calendarLanguage;
        /// <summary>
        /// カレンダーの言語設定
        /// </summary>
        public string CalendarLanguage
        {
            get
            {
                if (calendarLanguage == Language.de_DE.ToString())
                {
                    return AssemblyUtil.Language;
                }
                else
                {
                    return calendarLanguage.Replace("_", "-");
                }
            }

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
