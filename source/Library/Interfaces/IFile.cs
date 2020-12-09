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
        /// アプリバージョン
        /// </summary>
        String AppVer { get; set; }
    }
}
