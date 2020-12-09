using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Managers
{
    /// <summary>
    /// アプリケーション管理クラス
    /// </summary>
    public class ApplicationManager
    {
        #region properties


        private static ApplicationManager instance;
        /// <summary>
        /// インスタンスを取得
        /// </summary>
        public static ApplicationManager Instance
        {
            get
            {
                if (instance == null) instance = new ApplicationManager();

                return instance;
            }
        }

        #endregion

        #region public

        #endregion

        #region private

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private ApplicationManager()
        {

        }

        #endregion
    }
}
