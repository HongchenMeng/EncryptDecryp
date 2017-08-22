using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UtilsEncryptDecryp
{
    public class MD5
    {
        /// <summary>
        /// 计算字符串的MD5值
        /// </summary>
        /// <param name="Str">字符串</param>
        /// <param name="DaXie">输出的MD5值是否为大写字母，默认是大写</param>
        /// <returns>返回 加密后的十六进制的哈希散列（字符串）</returns>
        public string GetMD5WithString(string Str, bool DaXie = true)
        {
            Encoding encoding = Encoding.UTF8;
            return GetMD5WithString(Str, encoding,DaXie);
        }
        /// <summary>
        /// 计算字符串的MD5值
        /// </summary>
        /// <param name="Str">字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="DaXie">输出的MD5值是否为大写字母，默认是大写</param>
        /// <returns>返回 加密后的十六进制的哈希散列（字符串）</returns>
        public string GetMD5WithString(string Str,Encoding encoding,bool DaXie=true)
        {
            string dx ;
            if(DaXie)
            {
                dx = "X2";
            }
            else
            {
                dx = "x2";
            }

            //string resultStr = "";
            StringBuilder resultStr = new StringBuilder();

            byte[] StrBytes = encoding.GetBytes(Str);

            //System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] EncryptByte = md5.ComputeHash(StrBytes);

            for (int i = 0; i < EncryptByte.Length; i++)
            {
                //resultStr += EncryptByte[i].ToString(dx);
                resultStr.Append(EncryptByte[i].ToString("X2"));
            }
            return resultStr.ToString();
        }
        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件的MD5值 加密后的十六进制的哈希散列（字符串）</returns>
        public string GetMD5WithFilePath(string filePath,string fengge=null)
        {
            string ctyptStr = "";
            byte[] cryptBytes;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            cryptBytes = md5.ComputeHash(fs);
            ctyptStr = System.BitConverter.ToString(cryptBytes);

            //using (FileStream fs = new FileStream(filePath, FileMode.Open))
            //{
            //    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //    cryptBytes = md5.ComputeHash(fs);
            //}
            //for (int i = 0; i < cryptBytes.Length; i++)
            //{
            //    ctyptStr += cryptBytes[i].ToString("X2");
            //}

            ctyptStr = ctyptStr.Replace("-", fengge);
            return ctyptStr;
        }

    }
}