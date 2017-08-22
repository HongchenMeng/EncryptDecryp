//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Security.Cryptography;

//namespace UtilsEncryptDecryp
//{
//    public class EncryptDecryp
//    {
//        #region 对称加密 
//        private byte[] GetLegalKey(string Key)
//        {
//            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
//            mobjCryptoService.GenerateKey();
//            byte[] bytTemp = mobjCryptoService.Key;
//            int KeyLength = bytTemp.Length;
//            if (Key.Length > KeyLength)
//                Key = Key.Substring(0, KeyLength);
//            else if (Key.Length < KeyLength)
//                Key = Key.PadRight(KeyLength, ' ');
//            return ASCIIEncoding.ASCII.GetBytes(Key);
//        } 
//        private byte[] GetLegalIV(string IV)
//        {
//            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
//            mobjCryptoService.GenerateIV();
//            byte[] bytTemp = mobjCryptoService.IV;
//            int IVLength = bytTemp.Length;
//            if (IV.Length > IVLength)
//                IV = IV.Substring(0, IVLength);
//            else if (IV.Length < IVLength)
//                IV = IV.PadRight(IVLength, ' ');
//            return ASCIIEncoding.ASCII.GetBytes(IV);
//        }
//        /// <summary>
//        /// 对称加密
//        /// </summary>
//        /// <param name="SourceString">待加密字符串</param>
//        /// <param name="Key"> 如 Key= "Guz(%&hj7x89H$yuBI0456FtmaT5&fvHUFCy76*h%(HilJ$lhj!y6&(*jkP87jH7";</param>
//        /// <param name="IV">如 IV = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";</param>
//        /// <returns></returns>
//        public string EncryptSA(string SourceString,string Key,string IV)
//        {
//            //Key= "Guz(%&hj7x89H$yuBI0456FtmaT5&fvHUFCy76*h%(HilJ$lhj!y6&(*jkP87jH7";
//            //IV = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
//            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
//            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(SourceString);
//            MemoryStream ms = new MemoryStream();
//            mobjCryptoService.Key = GetLegalKey(Key);
//            mobjCryptoService.IV = GetLegalIV(IV);
//            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
//            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
//            cs.Write(bytIn, 0, bytIn.Length);
//            cs.FlushFinalBlock();
//            ms.Close();
//            byte[] bytOut = ms.ToArray();
//            return Convert.ToBase64String(bytOut);
//        }

//        /// <summary>
//        /// 对称解密
//        /// </summary>
//        /// <param name="TargetString">待解密字符串</param>
//        /// <param name="Key"> 如 Key= "Guz(%&hj7x89H$yuBI0456FtmaT5&fvHUFCy76*h%(HilJ$lhj!y6&(*jkP87jH7";</param>
//        /// <param name="IV">如 IV = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";</param>
//        /// <returns></returns>
//        public string DecrypSA(string TargetString, string Key, string IV)
//        {
//            //Key= "Guz(%&hj7x89H$yuBI0456FtmaT5&fvHUFCy76*h%(HilJ$lhj!y6&(*jkP87jH7";
//            //IV = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
//            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
//            byte[] bytIn = Convert.FromBase64String(TargetString);
//            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
//            mobjCryptoService.Key = GetLegalKey(Key);
//            mobjCryptoService.IV = GetLegalIV(IV);
//            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
//            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
//            StreamReader sr = new StreamReader(cs);
//            return sr.ReadToEnd();
//        }
//        #endregion
//        #region MD5加密,不可逆
//        /// <summary>
//        /// MD5加密，不可逆 
//        /// </summary>
//        /// <param name="SourceString">需要加密的字符串</param>
//        /// <param name="myEncoding">编码类型枚举</param>
//        /// <returns>MD5加密后字符串</returns>
//        public  string EncryptMD5(string SourceString, Encoding myEncoding)
//        {
//            MD5 md5 = new MD5CryptoServiceProvider();
//            byte[] source = md5.ComputeHash(myEncoding.GetBytes(SourceString));
//            StringBuilder sBuilder = new StringBuilder();
//            for (int i = 0; i < source.Length; i++)
//            {
//                sBuilder.Append(source[i].ToString("x"));
//            }
//            return sBuilder.ToString();
//        }
//        /// <summary>
//        /// MD5加密，不可逆
//        /// </summary>
//        /// <param name="SourceString">需要加密的字符串</param>
//        /// <param name="codeName">编码类型 如utf-32</param>
//        /// <returns>MD5加密后字符串</returns>
//        public string EncryptMD5(string SourceString, string codeName)
//        {
//            MD5 md5 = new MD5CryptoServiceProvider();
//            byte[] source = md5.ComputeHash(Encoding.GetEncoding(codeName).GetBytes(SourceString));
//            StringBuilder sBuilder = new StringBuilder();//或 string sBuilder = null;
//            for (int i = 0; i < source.Length; i++)
//            {
//                sBuilder.Append(source[i].ToString("x"));//或 sBuilder += source[i].ToString("x");
//            }
//            return sBuilder.ToString();// return sBuilder;
//        }
//        /// <summary>
//        /// MD5-32位加密
//        /// </summary>
//        /// <param name="SourceString">待加密字符串</param>
//        /// <param name="codeName">编码类型 如utf-32</param>
//        /// <returns></returns>
//        public string EncryptMD5Get32(string SourceString, string codeName)
//        {
//            MD5 md5 = new MD5CryptoServiceProvider();
//            byte[] t = md5.ComputeHash(Encoding.GetEncoding(codeName).GetBytes(SourceString));
//            StringBuilder sBuilder = new StringBuilder(32);
//            for (int i = 0; i < t.Length; i++)
//            {
//                sBuilder.Append(t[i].ToString("x").PadLeft(2, '0'));
//            }
//            return sBuilder.ToString();
//        }

//        /// <summary>
//        /// MD5-16位加密
//        /// </summary>
//        /// <param name="SourceString">待加密字符串</param>
//        /// <returns></returns>
//        public  string EncryptMD5Get16(string SourceString)
//        {
//            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
//            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(SourceString)), 4, 8);
//            t2 = t2.Replace("-", "");
//            return t2;
//        }
//        #endregion

//        #region DES加密&解密
//        /// <summary>
//        /// DES加密字符串
//        /// </summary>
//        /// <param name="SourceString">待加密字符串</param>
//        /// <param name="KEY_64">是8个字符，64位</param>
//        /// <param name="IV_64">是8个字符，64位</param>
//        /// <returns></returns>
//        public string EncryptDES(string SourceString, string KEY_64, string IV_64)
//        {
//            //将秘钥、向量转换成字节数组
//            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
//            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);
//            //声明1个新的DES对象
//            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
//            //int i = cryptoProvider.KeySize;
//            MemoryStream msEncrypt = new MemoryStream();//开辟一块内存流
//            //把内存流对象包装成加密流对象
//            CryptoStream csEncrypt = new CryptoStream(msEncrypt, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

//            StreamWriter swEncrypt = new StreamWriter(csEncrypt);//把加密流对象包装成写入流对象
//            swEncrypt.Write(SourceString);//写入流对象写入明文
//            swEncrypt.Flush();//关闭写入流
//            csEncrypt.FlushFinalBlock();
//            swEncrypt.Flush();
//            return Convert.ToBase64String(msEncrypt.GetBuffer(), 0, (int)msEncrypt.Length);

//        }
//        /// <summary> 
//        /// DES加密字符串 
//        /// </summary> 
//        /// <param name="SourceString">待加密的字符串</param> 
//        /// <param name="encryptKey">加密密钥,要求为8位</param>
//        /// <param name="Keys">秘钥向量，如 byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF } </param>
//        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns> 
//        public string EncryptDES(string SourceString, string encryptKey, byte[] Keys)
//        {
//            //private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
//            try
//            {
//                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
//                byte[] rgbIV = Keys;
//                byte[] inputByteArray = Encoding.UTF8.GetBytes(SourceString);
//                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
//                MemoryStream mStream = new MemoryStream();
//                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
//                cStream.Write(inputByteArray, 0, inputByteArray.Length);
//                cStream.FlushFinalBlock();
//                return Convert.ToBase64String(mStream.ToArray());
//            }
//            catch
//            {
//                return SourceString;
//            }
//        }
//        /// <summary>
//        /// DES解密字符串
//        /// </summary>
//        /// <param name="TargetString">待解密字符串</param>
//        /// <param name="KEY_64">是8个字符，64位</param>
//        /// <param name="IV_64">是8个字符，64位</param>
//        /// <returns></returns>
//        public string DecryptDES(string TargetString, string KEY_64, string IV_64)
//        {
//            //把秘钥、向量转换成字节数组
//            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
//            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

//            byte[] byEnc;
//            try
//            {
//                byEnc = Convert.FromBase64String(TargetString);//把密文转换字节数组
//            }
//            catch
//            {
//                return null;
//            }
            
//            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
//            //开辟内存，并存放密文字节数组
//            MemoryStream msDecrypt = new MemoryStream(byEnc);
//            //把内存流对象包装成读出流对象
//            CryptoStream csDecrypt = new CryptoStream(msDecrypt, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
//            //把解密流对象包装成读出流对象
//            StreamReader srDecrypt = new StreamReader(csDecrypt);


//            return srDecrypt.ReadToEnd();
//        }

//        /// <summary> 
//        /// DES解密字符串 
//        /// </summary> 
//        /// <param name="TargetString">待解密的字符串</param> 
//        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param> 
//        /// <param name="Keys">秘钥向量，如 byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF } </param>
//        /// <returns>解密成功返回解密后的字符串，失败返源串</returns> 
//        public string DecryptDES(string TargetString, string decryptKey, byte[] Keys)
//        {
//            //private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
//            try
//            {
//                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
//                byte[] rgbIV = Keys;
//                byte[] inputByteArray = Convert.FromBase64String(TargetString);
//                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
//                MemoryStream mStream = new MemoryStream();
//                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
//                cStream.Write(inputByteArray, 0, inputByteArray.Length);
//                cStream.FlushFinalBlock();
//                return Encoding.UTF8.GetString(mStream.ToArray());
//            }
//            catch
//            {
//                return TargetString;
//            }
//        }

//        #endregion

//        #region 加密解密文件
//        //加密文件 
//        private void EncryptData(string inPath, string outPath, byte[] desKey, byte[] desIV)
//        {
//            //Create the file streams to handle the input and output files. 
//            FileStream fin = new FileStream(inPath, FileMode.Open, FileAccess.Read);
//            FileStream fout = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.Write);
//            fout.SetLength(0);

//            //Create variables to help with read and write. 
//            byte[] bin = new byte[100]; //This is intermediate storage for the encryption. 
//            long rdlen = 0;              //This is the total number of bytes written. 
//            long totlen = fin.Length;    //This is the total length of the input file. 
//            int len;                     //This is the number of bytes to be written at a time. 

//            DES des = new DESCryptoServiceProvider();
//            CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);

//            //Read from the input file, then encrypt and write to the output file. 
//            while (rdlen < totlen)
//            {
//                len = fin.Read(bin, 0, 100);
//                encStream.Write(bin, 0, len);
//                rdlen = rdlen + len;
//            }

//            encStream.Close();
//            fout.Close();
//            fin.Close();
//        }

//        //解密文件 
//        private  void DecryptData(string inPath, string outPath, byte[] desKey, byte[] desIV)
//        {
//            //Create the file streams to handle the input and output files. 
//            FileStream fin = new FileStream(inPath, FileMode.Open, FileAccess.Read);
//            FileStream fout = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.Write);
//            fout.SetLength(0);

//            //Create variables to help with read and write. 
//            byte[] bin = new byte[100]; //This is intermediate storage for the encryption. 
//            long rdlen = 0;              //This is the total number of bytes written. 
//            long totlen = fin.Length;    //This is the total length of the input file. 
//            int len;                     //This is the number of bytes to be written at a time. 

//            DES des = new DESCryptoServiceProvider();
//            CryptoStream encStream = new CryptoStream(fout, des.CreateDecryptor(desKey, desIV), CryptoStreamMode.Write);

//            //Read from the input file, then encrypt and write to the output file. 
//            while (rdlen < totlen)
//            {
//                len = fin.Read(bin, 0, 100);
//                encStream.Write(bin, 0, len);
//                rdlen = rdlen + len;
//            }

//            encStream.Close();
//            fout.Close();
//            fin.Close();

//        }

//        #endregion
//    }
//}
