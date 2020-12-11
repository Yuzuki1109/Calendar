using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Library.Interfaces;

namespace Library.Base
{
    /// <summary>
    /// ファイル基底クラス
    /// </summary>
    public class FileBase : IFile
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

        /// <summary>
        /// デシリアライズ用コンバーター
        /// </summary>
        /// <param name="appver">アプリバージョン</param>
        public virtual void ConvertDeserialize(ApplicationVersion appver)
        {
            Version = appver;
        }

        /// <summary>
        /// シリアライズ用コンバーター
        /// </summary>
        /// <param name="appver">アプリバージョン</param>
        public virtual void ConvertSerialize(ApplicationVersion appver)
        {
            Version = appver;
        }
    }
}
