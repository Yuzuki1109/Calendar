using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Calendar.Settings;
using Library;
using Library.Interfaces;
using Library.Base;

namespace Calendar.Utils
{
    /// <summary>
    /// ファイルユーティリティクラス
    /// </summary>
    public static class FileUtil
    {
        #region properties

        /// <summary>
        /// 排他ロック用SemaphoreSlimオブジェクト
        /// </summary>
        private static SemaphoreSlim SemaphoreSlimObj = new SemaphoreSlim(1, 1);

        #endregion

        #region public

        /// <summary>
        /// シリアライズ
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <param name="data">保存データ</param>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>タスク</returns>
        public static async Task Serialize<T>(T data, string filePath)
        {
            await SemaphoreSlimObj.WaitAsync();

            var fb = data as FileBase;

            if (fb != null)
            {
                fb.ConvertSerialize(AssemblyUtil.VersionEnum);

                data = (T)(object)fb;
            }

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));


                if (File.Exists(filePath)) File.Delete(filePath);

                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                using (var streamWriter = new StreamWriter(fs, Encoding.UTF8))
                {
                    await Task.Run(() => xmlSerializer.Serialize(streamWriter, fb));

                    await streamWriter.FlushAsync();
                }
            }
            catch (Exception e)
            {
                SeriLogger.Error(e);
            }
            finally
            {
                SemaphoreSlimObj.Release();
            }
        }

        /// <summary>
        /// デシリアライズ
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>タスク</returns>
        public static async Task<T> Deserialize<T>(string filePath)
        {
            await SemaphoreSlimObj.WaitAsync();

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                var xmlSettings = new XmlReaderSettings() { CheckCharacters = false };

                using (var streamReader = new StreamReader(filePath, Encoding.UTF8))
                using (var xmlReader = XmlReader.Create(streamReader, xmlSettings))
                {
                    return await Task.Run(() => (T)xmlSerializer.Deserialize(xmlReader));
                }
            }
            finally
            {
                SemaphoreSlimObj.Release();
            }
        }

        #endregion

        #region private

        #endregion

    }
}
