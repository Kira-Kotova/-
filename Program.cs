using System;
using System.IO;


namespace LabWork6_1_8
{
    internal class Program
    {
        public static void Main()
        {
            string path1 = @"C:\путь.имя файла.формат";
            string path2 = @"D:\куды сохранять будем";
            var tr = new StreamReader(path1);
            var test = new StreamWriter(path2);
            string oldStr = "\t";//что меняем
            string newStr = "^";//на что меняем
            while (tr.Peek() >= 0)
            {
                var line = tr.ReadLine();
                var newLine = line.Replace(oldStr, newStr);
                test.WriteLine(newLine);
            }
            
            Console.WriteLine("ok");
        }
    }
}