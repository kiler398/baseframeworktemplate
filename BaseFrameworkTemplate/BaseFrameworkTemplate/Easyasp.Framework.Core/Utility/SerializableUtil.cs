using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using NHibernate.Type;
using Powerasp.Enterprise.Core.Compress.SevenZip;

namespace Easyasp.Framework.Core.Utility
{
    /// <summary>
    /// 序列化帮助类
    /// </summary>
    public static class SerializableUtil
    {
        /// <summary>
        /// 可序列化类转化为二进制数组
        /// </summary>
        /// <typeparam name="T">可序列化类类型</typeparam>
        /// <param name="t">可序列化类实例</param>
        /// <returns>二进制数组</returns>
        private static byte[] ConvertObjectToByteArray<T>(T t)
        {
            using (MemoryStream msReader = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                try
                {
                    binaryFormatter.Serialize(msReader, t);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }

                byte[] buffer = new byte[msReader.Length];
                msReader.Position = 0;
                msReader.Read(buffer, 0, buffer.Length);
                msReader.Close();

                return buffer;
            }
        }
        /// <summary>
        /// Base64字符串转化为二进制数组
        /// </summary>
        /// <param name="base64String">Base64字符串</param>
        /// <returns>二进制数组</returns>
        private static byte[] ConvertBase64StringToByteArray(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                return null;

            return Convert.FromBase64String(base64String);
        }


        /// <summary>
        /// 将类转化为经过7zip压缩算法压缩的Base64编码
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="t">压缩类</param>
        /// <returns>Base64编码</returns>
        public static string ConvertObjectToZipedBase64String<T>(T t)
        {
            //对数据进行压缩减小体积
            byte[] zipedBuffer = SevenZipCodeHelper.Compress(ConvertObjectToByteArray<T>(t));
            return Convert.ToBase64String(zipedBuffer);
        }

        public static T ConvertZipedBase64StringToObject<T>(string base64String)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            if (string.IsNullOrEmpty(base64String))
                return default(T);

            byte[] buffer = ConvertBase64StringToByteArray(base64String);
            //解压数据
            byte[] unZipedBuffer = SevenZipCodeHelper.Decompress(buffer);

            MemoryStream msReader = new MemoryStream(unZipedBuffer);

            T t;
            //反序列化
            try
            {
                t = (T) binaryFormatter.Deserialize(msReader);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            return t;
        }



    }
}