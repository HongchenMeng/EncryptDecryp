using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace UtilsEncryptDecryp
{
    public class EncryptDecryp
    {
        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }
            return byte2String;
        }
        /// 字符串MD5加密
        /// </summary>
        /// <param name="codeName">编码类型</param>
        /// <param name="sourceString">需要加密的字符串</param>
        /// <returns>MD5加密后字符串</returns>
        public static string HashString(string sourceString, string codeName)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] source = md5.ComputeHash(Encoding.GetEncoding(codeName).GetBytes(sourceString));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                sBuilder.Append(source[i].ToString("x"));
            }
            return sBuilder.ToString();
        }
    }
}
