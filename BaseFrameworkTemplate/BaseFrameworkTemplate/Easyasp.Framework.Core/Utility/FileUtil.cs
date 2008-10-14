using System;
using System.IO;
using System.Text;

namespace Easyasp.Framework.Core.Utility
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileUtil
    {
        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>扩展名（带.）</returns>
        public static string GetFileExtName(string fileName)
        {
            return Path.GetExtension(fileName);
        }
        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="fullPath">文件路径</param>
        /// <returns>文件全名</returns>
        public static string GetFileName(string fullPath)
        {
            return Path.GetFileName(fullPath);
        }

        /// <summary>
        /// 以字符串形式读取文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件内容</returns>
        public static string ReadFileContent(string filePath)
        {
            return ReadFileContent(filePath, Encoding.Default);
        }

        /// <summary>
        /// 以字符串形式读取文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>文件内容</returns>
        public static string ReadFileContent(string filePath, Encoding encoding)
        {
            string fileContent = "";
            using (StreamReader sr = new StreamReader(filePath,encoding))
            {
                string line = sr.ReadLine();
                while(!string.IsNullOrEmpty(line))
                {
                    fileContent += line;
                    line = sr.ReadLine();
                }
            }
            return fileContent;
        }

        //public static byte[] ReadFileBtye(string filePath)
        //{

        //}

    }
}