using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilsEncryptDecryp
{
    class Program
    {
        static void Main(string[] args)
        {
            AES aes = new AES();
            MD5 md5 = new MD5();
            SHA sha = new SHA();

            string path = @"F:\旧迅雷下载\cn_visual_studio_enterprise_2015_with_update_2_x86_x64_dvd_8510289.iso";

            //string md = md5.GetMD5WithFilePath(path);
            string sh = sha.GetSHA1WithFilePath(path);
            //string sh2 = sha.GetSHA256WithFilePath(path);
            //string sh3 = sha.GetSHA384WithFilePath(path);
            //string sh5 = sha.GetSHA512WithFilePath(path);

            //Console.WriteLine(md);
            //Console.WriteLine(md.Length);
            //Console.WriteLine("=================================");
            Console.WriteLine(sh);
            Console.WriteLine(sh.Length);
            Console.WriteLine("=================================");
            //Console.WriteLine(sh2);
            //Console.WriteLine(sh2.Length);
            //Console.WriteLine("=================================");
            //Console.WriteLine(sh3);
            //Console.WriteLine(sh3.Length);
            //Console.WriteLine("=================================");
            //Console.WriteLine(sh5);
            //Console.WriteLine(sh5.Length);
            Console.ReadLine();

        }
       static void RefreshDirProgress(int max, int value)
        {

        }
    }
}
