using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    /// <summary>
    /// ファイル用インタフェース
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// アプリバージョン（記録用）
        /// </summary>
        String AppVer { get; set; }

        /// <summary>
        /// アプリバージョン
        /// </summary>
        ApplicationVersion Version { get; set; }

        /// <summary>
        /// シリアライズ時用コンバーター
        /// </summary>
        /// <param name="appver">アプリバージョン</param>
        void ConvertSerialize(ApplicationVersion appver);

        /// <summary>
        /// デシリアライズ用コンバーター
        /// </summary>
        /// <param name="appver">アプリバージョン</param>
        void ConvertDeserialize(ApplicationVersion appver);
    }
}
