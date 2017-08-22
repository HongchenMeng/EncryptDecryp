using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace UtilsEncryptDecryp
{
  public  class MD5
    {
         public string GetMD5WithString(string sDataIn)
         {
              string str = "";
              byte[] data = Encoding.GetEncoding("utf-8").GetBytes(str);
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(data);
              for (int i = 0; i<bytes.Length; i++)
              {
                  str += bytes[i].ToString("x2");
             }
             return str;
         }

      //  方式一：
public string GetMD5String(string pwd)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(pwd);
            byte[] md5data = md5.ComputeHash(data);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < md5data.Length - 1; i++)
            {
                builder.Append(md5data[i].ToString("X2"));
            }
            return builder.ToString();
        }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="msg"></param>
      /// <returns></returns>
public string GetMd5(string msg)
        {
            string cryptStr = "";
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            byte[] cryptBytes = md5.ComputeHash(bytes);
            for (int i = 0; i < cryptBytes.Length; i++)
            {
                cryptStr += cryptBytes[i].ToString("X2");
            }
            return cryptStr;
        }
        public string GetMD5WithFilePath(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash_byte = md5.ComputeHash(file);
            string str = System.BitConverter.ToString(hash_byte);
            str = str.Replace("-", "");
            return str;
        }
       public string GetFileMd5(string path)
        {
            string ctyptStr = "";
            byte[] cryptBytes;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                cryptBytes = md5.ComputeHash(fs);
            }
            for (int i = 0; i < cryptBytes.Length; i++)
            {
                ctyptStr += cryptBytes[i].ToString("X2");
            }
            return ctyptStr;
        }
    }
}
