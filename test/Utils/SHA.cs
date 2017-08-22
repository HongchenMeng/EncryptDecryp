using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace UtilsEncryptDecryp
{
    public class SHA
    {
        /// <summary>
        /// 基于Sha1的自定义加密字符串方法：输入一个字符串，返回一个由40个字符组成的十六进制的哈希散列（字符串）。
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密后的十六进制的哈希散列（字符串）</returns>
        public string GetSHA1WithString2(string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = SHA1.Create().ComputeHash(buffer);

            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
        public string GetSHA1WithString(string strIN)
        {
            //string strIN = getstrIN(strIN);
            byte[] tmpByte;
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            tmpByte = sha1.ComputeHash(getKeyByteArray(strIN));
            sha1.Clear();

            return getStringValue(tmpByte);

        }
        public string GetSHA256WithString(string strIN)
        {
            //string strIN = getstrIN(strIN);
            byte[] tmpByte;
            SHA256 sha256 = new SHA256Managed();

            tmpByte = sha256.ComputeHash(getKeyByteArray(strIN));
            sha256.Clear();

            return getStringValue(tmpByte);
        }
        public string GetSHA384WithString(string strIN)
        {
            //string strIN = getstrIN(strIN);
            byte[] tmpByte;
            SHA384 sha384 = new SHA384Managed();

            tmpByte = sha384.ComputeHash(getKeyByteArray(strIN));
            sha384.Clear();

            return getStringValue(tmpByte);
        }
        public string GetSHA512WithString(string strIN)
        {
            //string strIN = getstrIN(strIN);
            byte[] tmpByte;
            SHA512 sha512 = new SHA512Managed();

            tmpByte = sha512.ComputeHash(getKeyByteArray(strIN));
            sha512.Clear();

            return getStringValue(tmpByte);

        }

        public string GetSHA1WithFilePath(string filePath, string fengge = null)
        {
            string ctyptStr = "";
            byte[] cryptBytes;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            cryptBytes = sha1.ComputeHash(fs);
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
        public string GetSHA256WithFilePath(string filePath, string fengge = null)
        {
            string ctyptStr = "";
            byte[] cryptBytes;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            cryptBytes = sha256.ComputeHash(fs);
            ctyptStr = System.BitConverter.ToString(cryptBytes);

            //using (FileStream fs = new FileStream(filePath, FileMode.Open))
            //{
            //    SHA256 sha256 = new SHA256CryptoServiceProvider();
            //    cryptBytes = sha256.ComputeHash(fs);
            //}
            //for (int i = 0; i < cryptBytes.Length; i++)
            //{
            //    ctyptStr += cryptBytes[i].ToString("X2");
            //}

            ctyptStr = ctyptStr.Replace("-", fengge);
            return ctyptStr;
        }
        public string GetSHA384WithFilePath(string filePath, string fengge = null)
        {
            string ctyptStr = "";
            byte[] cryptBytes;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            SHA384 sha384 = new SHA384CryptoServiceProvider();
            cryptBytes = sha384.ComputeHash(fs);
            ctyptStr = System.BitConverter.ToString(cryptBytes);

            //using (FileStream fs = new FileStream(filePath, FileMode.Open))
            //{
            //    SHA384 sha384 = new SHA384CryptoServiceProvider();
            //    cryptBytes = sha384.ComputeHash(fs);
            //}
            //for (int i = 0; i < cryptBytes.Length; i++)
            //{
            //    ctyptStr += cryptBytes[i].ToString("X2");
            //}

            ctyptStr = ctyptStr.Replace("-", fengge);
            return ctyptStr;
        }
        public string GetSHA512WithFilePath(string filePath, string fengge = null)
        {
            string ctyptStr = "";
            byte[] cryptBytes;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            cryptBytes = sha512.ComputeHash(fs);
            ctyptStr = System.BitConverter.ToString(cryptBytes);

            //using (FileStream fs = new FileStream(filePath, FileMode.Open))
            //{
            //    SHA512 sha512 = new SHA512CryptoServiceProvider();
            //    cryptBytes = sha512.ComputeHash(fs);
            //}
            //for (int i = 0; i < cryptBytes.Length; i++)
            //{
            //    ctyptStr += cryptBytes[i].ToString("X2");
            //}

            ctyptStr = ctyptStr.Replace("-", fengge);
            return ctyptStr;
        }
        private string getStringValue(byte[] Byte)
        {
            string tmpString = "";
            ASCIIEncoding Asc = new ASCIIEncoding();
            tmpString = Asc.GetString(Byte);
            return tmpString;
        }

        private byte[] getKeyByteArray(string strKey)
        {
            ASCIIEncoding Asc = new ASCIIEncoding();

            int tmpStrLen = strKey.Length;
            byte[] tmpByte = new byte[tmpStrLen - 1];

            tmpByte = Asc.GetBytes(strKey);

            return tmpByte;
        }
    }
}