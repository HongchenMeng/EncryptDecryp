using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace UtilsEncryptDecryp
{
    class Program
    {
        static void Main(string[] args)
        {
            AES aes = new AES();
            MD5 md5 = new MD5();
            SHA sha = new SHA();
            Stopwatch stopwatch = new Stopwatch();
            string path = @"F:\旧迅雷下载\cn_visual_studio_enterprise_2015_with_update_2_x86_x64_dvd_8510289.iso";

            stopwatch.Reset();
            stopwatch.Start();
            string md = md5.GetMD5WithFilePath(path);
            stopwatch.Stop();
           long mds = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            string md2 = md5.MD5Stream(path);
            stopwatch.Stop();
            long md2s = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            string md3 = md5.MD5File(path);
            stopwatch.Stop();
            long md3s = stopwatch.ElapsedMilliseconds;

            //string sh = sha.GetSHA1WithFilePath(path);
            //string sh2 = sha.GetSHA256WithFilePath(path);
            //string sh3 = sha.GetSHA384WithFilePath(path);
            //string sh5 = sha.GetSHA512WithFilePath(path);

            Console.WriteLine(md);
            Console.WriteLine(mds);
            Console.WriteLine("=================================");

            Console.WriteLine(md2);
            Console.WriteLine(md2s);
            Console.WriteLine("=================================");

            Console.WriteLine(md3);
            Console.WriteLine(md3s);
            Console.WriteLine("=================================");

            //Console.WriteLine(sh);
            //Console.WriteLine(sh.Length);
            //Console.WriteLine("=================================");
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
