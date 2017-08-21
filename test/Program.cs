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
            //int x = 1;
            //int y = 2;
            //aes.thisEncoding = Encoding.ASCII;
            string s = "我是中国人！！@@";
            string s0 = @"C:\Users\Administrator\Desktop\EncryptFile\jb51.net.txt";
            string s1 = aes.AESEncrypt(s);
           // aes.AESEncrypt(s0, RefreshDirProgress);
          //  aes.AESDecrypt(s0, RefreshDirProgress);
            string s2 = aes.AESDecrypt(s1);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
           // Console.WriteLine("===================");
            Console.ReadLine();
            //EncryptDecryp ed = new EncryptDecryp();
            //string a = "19880814";
            //Console.WriteLine(a);
            //string a1 = ed.EncryptMD5(a, Encoding.UTF32);
            //Console.WriteLine(a1);
            //string a2 = ed.EncryptMD5Get32(a, "utf-32");
            //string a22 = ed.EncryptMD5(a, "utf-32");
            //string a222 = ed.EncryptMD5Get16(a);
            //Console.WriteLine(a2);
            //Console.WriteLine(a22);
            //Console.WriteLine(a222);
            //string a3 = ed.EncryptMD5Get16(a);
            //Console.WriteLine(a3);
            //Console.WriteLine("===================");
            //string Key= "Guz(%&hj7x89H$yuBI0456FtmaT5&fvHUFCy76*h%(HilJ$lhj!y6&(*jkP87jH7";
            //string IV = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";

            //string a4 = ed.EncryptSA(a, Key, IV);
            //string a5 = ed.DecrypSA(a4, Key, IV);
            //Console.WriteLine(a4);
            //Console.WriteLine(a5);

            //Console.WriteLine("===================");

            //string a6 = ed.EncryptDES(a, "guandlu9", "guandlu9");
            //string a7=ed.DecryptDES(a6, "guandlu9", "guandlu9");
            //Console.WriteLine(a6);
            //Console.WriteLine(a7);

            //Console.WriteLine("===========*******************========");
            //Console.ReadLine();
        }
       static void RefreshDirProgress(int max, int value)
        {

        }
    }
}
