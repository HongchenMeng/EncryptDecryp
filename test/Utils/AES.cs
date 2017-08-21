using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace UtilsEncryptDecryp
{
    /// <summary>
    /// AES 加密/解密(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
    /// </summary>
    public class AES
    {
        private Encoding _thisEncoding = Encoding.UTF8;
        public Encoding thisEncoding
        {
            set
            {
                _thisEncoding = value;
            }
            get
            {
                return _thisEncoding;
            }
        }

        private string _Key = @"sdf523#@%g^[ds0]{dsds=-ED>sfsw<9.>?$!2gdrtydgh";
        /// <summary>
        /// 获取密钥
        /// </summary>
        public  string Key
        {
            set
            {
                _Key = value;
            }
            
            get
            {
                return _Key;
            }
        }
        private string _IV= @"=-f30976DFGE!`dfg|}{dfds9?sdf81FDGE|[;876wer";

        /// <summary>
        /// 获取向量
        /// </summary>
       public string IV
        {
            set
            {
                _IV = value;
            }
            get
            {
                return _IV;
            }
        }

        private string _Sotl = @"#sfRTSfsd,.,lkgks|]./ewr:FDGT124yurtdf";
        public string Sotl
        {
            set
            {
                _Sotl = value;
            }
            get
            {
                return _Sotl;
            }
        }
        #region AES加密/解密 字节数组

        #region 加密字节数组
        /// <summary>
        /// AES 加密 字节数组(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="EncryptByte">明文数组</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="iv">向量字符串</param>
        /// <returns></returns>
        public byte[] AESEncrypt(byte[] EncryptByte, string key,string iv)
        {
            
            if (EncryptByte.Length == 0) { throw (new Exception("明文不得为空")); }
            if (string.IsNullOrEmpty(key)) { throw (new Exception("密钥不得为空")); }
            byte[] resultArray;//返回的数组


            PasswordDeriveBytes pdb1 = new PasswordDeriveBytes(key, thisEncoding.GetBytes(Sotl));
            byte[] _bIV = pdb1.GetBytes(16);
            //byte[] _bIV = _bIV = UTF8Encoding.UTF8.GetBytes(iv);

            //byte[] _btheKey = new byte[32];
            //_btheKey = UTF8Encoding.UTF8.GetBytes(key);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(key, _bIV);
            byte[] _btheKey= pdb.GetBytes(32);
            //Rijndael aes = Rijndael.Create();

            RijndaelManaged aes = new RijndaelManaged();
            try
            {
               
                aes.Key = _btheKey;
                aes.IV = _bIV;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = aes.CreateEncryptor();

               resultArray = cTransform.TransformFinalBlock(EncryptByte, 0, EncryptByte.Length);


                //MemoryStream mStream = new MemoryStream();
                //ICryptoTransform transform = aes.CreateEncryptor(_btheKey, _bIV);//
                //CryptoStream cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);
                //cStream.Write(plainByte, 0, plainByte.Length);
                //cStream.FlushFinalBlock();

                //m_strEncrypt = mStream.ToArray();
                //mStream.Close();
                //mStream.Dispose();
                //cStream.Close();
                //cStream.Dispose();
            }
            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { aes.Clear(); }
            return resultArray;

        }
        /// <summary>
        /// AES 加密 字节数组(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="EncryptByte">明文数组</param>
        /// <param name="key">密钥字符串</param>
        /// <returns></returns>
        public byte[] AESEncrypt(byte[] EncryptByte, string key)
        {
            string iv = IV;
            return AESEncrypt(EncryptByte, key,iv);
        }
        /// <summary>
        /// AES 加密 字节数组(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="EncryptByte">明文数组</param>
        /// <returns></returns>
        public byte[] AESEncrypt(byte[] EncryptByte)
        {
            string key = Key;
            string iv = IV;
            return AESEncrypt(EncryptByte, key,iv);
        }
        #endregion
       
        #region 解密字节数组
        /// <summary>
        ///  AES 解密 字节数组(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="DecryptByte">密文数组</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="iv">向量字符串</param>
        /// <returns></returns>
        public byte[] AESDecrypt(byte[] DecryptByte,string key,string iv)
        {

            if (DecryptByte.Length == 0) { throw (new Exception("密文不得为空")); }
            if (string.IsNullOrEmpty(key)) { throw (new Exception("密钥不得为空")); }
            byte[] resultArray;//返回的数组


            PasswordDeriveBytes pdb1 = new PasswordDeriveBytes(key, thisEncoding.GetBytes(Sotl));
            byte[] _bIV = pdb1.GetBytes(16);
            // byte[] _bIV = _bIV = UTF8Encoding.UTF8.GetBytes(iv);

            //byte[] _btheKey = new byte[32];
            //_btheKey = UTF8Encoding.UTF8.GetBytes(key);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(key, _bIV);
            byte[] _btheKey = pdb.GetBytes(32);
            //Rijndael aes = Rijndael.Create();

            //Rijndael aes = Rijndael.Create();
            RijndaelManaged aes = new RijndaelManaged();

            try
            {
                aes.Key = _btheKey;
                aes.IV = _bIV;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = aes.CreateDecryptor();
                resultArray = cTransform.TransformFinalBlock(DecryptByte, 0, DecryptByte.Length);

                //MemoryStream mStream = new MemoryStream();
                //ICryptoTransform transform = aes.CreateEncryptor(_btheKey, _bIV);//
                //CryptoStream m_csstream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);
                //m_csstream.Write(DecryptByte, 0, DecryptByte.Length);
                //m_csstream.FlushFinalBlock();
                //resultArray = mStream.ToArray();
                //mStream.Close();
                //mStream.Dispose();
                //m_csstream.Close();
                //m_csstream.Dispose();
            }
            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { aes.Clear(); }
            return resultArray;

        }
        /// <summary>
        /// AES 解密 字节数组(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="DecryptByte">密文数组</param>
        /// <param name="key">密钥字符串</param>
        /// <returns></returns>
        public byte[] AESDecrypt(byte[] DecryptByte, string key)
        {
            string iv = IV;
            return AESDecrypt(DecryptByte, key, iv);
        }
        /// <summary>
        /// AES 解密 字节数组(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="DecryptByte">待解密密文密文数组</param>
        /// <returns></returns>
        public byte[] AESDecrypt(byte[] DecryptByte)
        {
            string key = Key;
            string iv = IV;
            return AESDecrypt(DecryptByte, key,iv);
        }
        #endregion

        #endregion

        #region AES加密/解密 字符串

        #region 加密字符串
        /// <summary>
        /// AES 加密 字节数组(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="EncryptSting">明文字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="iv">向量字符串</param>
        /// <returns></returns>
        public string AESEncrypt(string EncryptSting, string key, string iv)
        {
            byte[] EncryptArray = _thisEncoding.GetBytes(EncryptSting);
            byte[] resultArray= AESEncrypt(EncryptArray, key, iv);
            return Convert.ToBase64String(resultArray);
        }
        /// <summary>
        /// AES 加密 字符串(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="EncryptSting">明文字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <returns></returns>
        public string AESEncrypt(string EncryptSting, string key)
        {
            string iv = IV;
            return AESEncrypt(EncryptSting, key, iv);
        }
        /// <summary>
        /// AES 加密 字符串(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="EncryptSting">明文字符串</param>
        /// <returns></returns>
        public string AESEncrypt(string EncryptSting)
        {
            string key = Key;
            string iv = IV;
            return AESEncrypt(EncryptSting, key, iv);
        }

        /// <summary>
        /// AES 加密 字符串(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="EncryptSting">明文字符串</param>
        /// <param name="returnNull">加密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>密文</returns>
        public string AESEncrypt(string EncryptSting, bool returnNull)
        {
            string key = Key;
            return AESEncrypt(EncryptSting, key, returnNull);
        }
        /// <summary>
        ///  AES 加密 字符串(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="EncryptSting">明文字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="returnNull">加密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns></returns>
        public string AESEncrypt(string EncryptSting, string key, bool returnNull)
        {
            string encrypt = AESEncrypt(EncryptSting, key);
            return returnNull ? encrypt : (encrypt == null ? String.Empty : encrypt);
        }
        #endregion

        #region 解密字符串
        /// <summary>
        /// AES 解密 字符串(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="DecryptString">密文字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="iv">向量字符串</param>
        /// <returns></returns>
        public string AESDecrypt(string DecryptString, string key,string iv)
        {

            byte[] DecryptArray = Convert.FromBase64String(DecryptString);
            byte[] resultArray = AESDecrypt(DecryptArray, key, iv);
            return _thisEncoding.GetString(resultArray);
        }
        /// <summary>
        /// AES 解密 字符串(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="DecryptString">密文字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <returns></returns>
        public string AESDecrypt(string DecryptString, string key)
        {

            string iv = IV;
            return AESDecrypt(DecryptString, key, iv);
        }
        /// <summary>
        ///  AES 解密 字符串(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="DecryptString">密文字符串</param>
        /// <returns></returns>
        public string AESDecrypt(string DecryptString)
        {
            string key = Key;
            string iv = IV;
            return AESDecrypt(DecryptString, key, iv);
        }

        /// <summary>
        /// AES 解密 字符串(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="DecryptString">密文字符串</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>明文</returns>
        public string AESDecrypt(string DecryptString, bool returnNull)
        {
            string theKey = Key;
            return AESDecrypt(DecryptString, theKey, returnNull);
        }
        /// <summary>
        /// AES 解密 字符串(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="DecryptString">密文字符串</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns></returns>
        public string AESDecrypt(string DecryptString, string key, bool returnNull)
        {
            string decrypt = AESDecrypt(DecryptString, key);
            return returnNull ? decrypt : (decrypt == null ? String.Empty : decrypt);
        }
        #endregion

        #endregion

        #region  AES加密/解密 文件
        #region 变量
        /// <summary>
        /// 一次处理的明文字节数
        /// </summary>
        private int encryptSize = 10000000;
        /// <summary>
        /// 一次处理的密文字节数
        /// </summary>
        private int decryptSize = 10000016;
        /// <summary>
        /// 临时文件扩展名
        /// </summary>
        private string tempFileExt = ".eftemp";
        #endregion
    /// <summary>
    /// 更新文件加密进度
    /// </summary>
    public delegate void RefreshFileProgress(int max, int value);
        #region 加密 文件
        /// <summary>
        /// AES 加密 文件 (高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="path">待加密的文件路径</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="iv">向量字符串</param>
        /// <param name="refreshFileProgress"></param>
        public void AESEncrypt(string path, string key, string iv, RefreshFileProgress refreshFileProgress)
        {
            try
            {
                if (File.Exists(path + tempFileExt)) File.Delete(path + tempFileExt);
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    if (fs.Length > 0)
                    {
                        using (FileStream fsnew = new FileStream(path + tempFileExt, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            if (File.Exists(path + tempFileExt)) File.SetAttributes(path + tempFileExt, FileAttributes.Hidden);
                            int blockCount = ((int)fs.Length - 1) / encryptSize + 1;
                            for (int i = 0; i < blockCount; i++)
                            {
                                int size = encryptSize;
                                if (i == blockCount - 1) size = (int)(fs.Length - i * encryptSize);
                                byte[] bArr = new byte[size];
                                fs.Read(bArr, 0, size);
                                byte[] result = AESEncrypt(bArr, key,iv);
                                fsnew.Write(result, 0, result.Length);
                                fsnew.Flush();
                                refreshFileProgress(blockCount, i + 1); //更新进度
                            }
                            fsnew.Close();
                            fsnew.Dispose();
                        }
                        fs.Close();
                        fs.Dispose();
                        FileAttributes fileAttr = File.GetAttributes(path);
                        File.SetAttributes(path, FileAttributes.Archive);
                        File.Delete(path);
                        File.Move(path + tempFileExt, path);
                        File.SetAttributes(path, fileAttr);
                    }
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(path + tempFileExt)) File.Delete(path + tempFileExt);
                throw ex;
            }
        }
        /// <summary>
        /// AES 加密 文件 (高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="path">待加密的文件路径</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="refreshFileProgress"></param>
        public void AESEncrypt(string path, string key, RefreshFileProgress refreshFileProgress)
        {
            string iv = IV;
            AESEncrypt(path, key, iv, refreshFileProgress);
        }
        /// <summary>
        /// AES 加密 文件 (高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="path">待加密的文件路径</param>
        /// <param name="refreshFileProgress"></param>
        public void AESEncrypt(string path,  RefreshFileProgress refreshFileProgress)
        {
            string key = Key;
            string iv = IV;
            AESEncrypt(path, key, iv, refreshFileProgress);
        }
        #endregion
        #region 解密 文件
        /// <summary>
        /// AES 解密 文件(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="path">待解密的文件路径</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="iv">向量字符串</param>
        /// <param name="refreshFileProgress"></param>
        public void AESDecrypt(string path, string key,string iv, RefreshFileProgress refreshFileProgress)
        {
            try
            {
                if (File.Exists(path + tempFileExt)) File.Delete(path + tempFileExt);
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    if (fs.Length > 0)
                    {
                        using (FileStream fsnew = new FileStream(path + tempFileExt, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            if (File.Exists(path + tempFileExt)) File.SetAttributes(path + tempFileExt, FileAttributes.Hidden);
                            int blockCount = ((int)fs.Length - 1) / decryptSize + 1;
                            for (int i = 0; i < blockCount; i++)
                            {
                                int size = decryptSize;
                                if (i == blockCount - 1) size = (int)(fs.Length - i * decryptSize);
                                byte[] bArr = new byte[size];
                                fs.Read(bArr, 0, size);
                                byte[] result = AESDecrypt(bArr, key,iv);
                                fsnew.Write(result, 0, result.Length);
                                fsnew.Flush();
                                refreshFileProgress(blockCount, i + 1); //更新进度
                            }
                            fsnew.Close();
                            fsnew.Dispose();
                        }
                        fs.Close();
                        fs.Dispose();
                        FileAttributes fileAttr = File.GetAttributes(path);
                        File.SetAttributes(path, FileAttributes.Archive);
                        File.Delete(path);
                        File.Move(path + tempFileExt, path);
                        File.SetAttributes(path, fileAttr);
                    }
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(path + tempFileExt)) File.Delete(path + tempFileExt);
                throw ex;
            }
        }
        /// <summary>
        /// AES 解密 文件(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="path">待解密的文件路径</param>
        /// <param name="key">密钥字符串</param>
        /// <param name="refreshFileProgress"></param>
        public void AESDecrypt(string path, string key, RefreshFileProgress refreshFileProgress)
        {
            string iv = IV;
            AESDecrypt(path, key, iv, refreshFileProgress);
        }
        /// <summary>
        /// AES 解密 文件(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="path">待解密的文件路径</param>
        /// <param name="refreshFileProgress"></param>
        public void AESDecrypt(string path, RefreshFileProgress refreshFileProgress)
        {
            string key = Key;
            string iv = IV;
            AESDecrypt(path, key, iv, refreshFileProgress);
        }
        #endregion
        #endregion
        #region AES加密/解密 文件夹
        /// <summary>
        /// 更新文件夹加密进度
        /// </summary>
        public delegate void RefreshDirProgress(int max, int value);
        /// <summary>
        /// AES 加密 文件夹及其子文件夹中的所有文件
        /// AES 加密解密算法(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)；
        /// </summary>
        /// <param name="dirPath">待加密的文件夹路径</param>
        /// <param name="theKey">密钥字符串</param>
        /// <param name="refreshDirProgress"></param>
        /// <param name="refreshFileProgress"></param>
        public void EncryptDirectory(string dirPath, string theKey, RefreshDirProgress refreshDirProgress, RefreshFileProgress refreshFileProgress)
        {
            string[] filePaths = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (!File.Exists(filePaths[i])) continue;
                AESEncrypt(filePaths[i], theKey, refreshFileProgress);
                refreshDirProgress(filePaths.Length, i + 1);
            }
        }
        /// <summary>
        /// AES 解密 文件夹及其子文件夹中的所有文件
        /// AES 加密解密算法(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)；
        /// </summary>
        /// <param name="dirPath">待解密的文件夹路径</param>
        /// <param name="theKey">密钥字符串</param>
        /// <param name="refreshDirProgress"></param>
        /// <param name="refreshFileProgress"></param>
        public void DecryptDirectory(string dirPath, string theKey, RefreshDirProgress refreshDirProgress, RefreshFileProgress refreshFileProgress)
        {
            string[] filePaths = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (!File.Exists(filePaths[i])) continue;
                AESDecrypt(filePaths[i], theKey, refreshFileProgress);
                refreshDirProgress(filePaths.Length, i + 1);
            }
        }
        /// <summary>
        /// 判断文件夹是否是自己所在的文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool IsSelf(string path)
        {
            if (path.ToLower().IndexOf(".exe") + 4 == path.Length) //如果是exe文件
            {
                int pos = path.LastIndexOf(@"\");
                string exeName = path.Substring(pos + 1);
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == exeName.Substring(0, exeName.Length - 4))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// AES 加密 当前文件夹
        /// AES 加密解密算法(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)；
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="pwd"></param>
        /// <param name="refreshDirProgress"></param>
        /// <param name="refreshFileProgress"></param>
        public void EncryptCurrentDirectory(string dirPath, string pwd, RefreshDirProgress refreshDirProgress, RefreshFileProgress refreshFileProgress)
        {
            int delta = 0;
            string[] filePaths = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (!File.Exists(filePaths[i])) continue;
                if (IsSelf(filePaths[i]))
                {
                    delta = -1;
                    continue;
                }
                AESEncrypt(filePaths[i], pwd, refreshFileProgress);
                refreshDirProgress(filePaths.Length - 1, i + 1 + delta);
            }
        }
        /// <summary>
        /// AES解密当前文件夹
        /// AES 加密解密算法(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)；
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="pwd"></param>
        /// <param name="refreshDirProgress"></param>
        /// <param name="refreshFileProgress"></param>
        public void DecryptCurrentDirectory(string dirPath, string pwd, RefreshDirProgress refreshDirProgress, RefreshFileProgress refreshFileProgress)
        {
            int delta = 0;
            string[] filePaths = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (!File.Exists(filePaths[i])) continue;
                if (IsSelf(filePaths[i]))
                {
                    delta = -1;
                    continue;
                }
                AESDecrypt(filePaths[i], pwd, refreshFileProgress);
                refreshDirProgress(filePaths.Length - 1, i + 1 + delta);
            }
        }
        #endregion
    }
}
