using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Library.Interfaces;
using Library;

namespace Calendar.Settings
{
    public class SettingBase : IFile
    {
        /// <summary>
        /// アプリバージョン
        /// </summary>
        public string AppVer { get; set; }

        /// <summary>
        /// アプリバージョン
        /// </summary>
        [XmlIgnore]
        public ApplicationVersion Version
        {
            get
            {
                return (ApplicationVersion)Enum.Parse(typeof(ApplicationVersion), AppVer);
            }

            set
            {
                AppVer = value.ToString();
            }
        }
    }
}
