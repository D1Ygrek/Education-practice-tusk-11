using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\Users\Demid\Desktop\курсовая\практика\11.txt"; //адрес кодирующего набора
            char[,] arr = SetTable(filename);
            Console.WriteLine("What to code?");
            string s = Console.ReadLine();
            Console.WriteLine("Coded:");
            Console.WriteLine(Code(s,arr));   //закодировать
            Console.WriteLine("What to decode?");
            s = Console.ReadLine();
            Console.WriteLine("Decoded:");
            Console.WriteLine(DeCode(s, arr));  //раскодировать
            Console.ReadLine();
        }
        static char[,] SetTable(string filename)
        {
            char[,] arr = new char[0, 0];
            string[] fil = File.ReadAllLines(filename, Encoding.GetEncoding(1251));
            arr = new char[2, fil.Length];
            for (int i = 0; i < fil.Length; i++)
            {
                string[] s = fil[i].Split(' ');
                arr[0, i] = s[0][0];
                arr[1, i] = s[1][0];
            }
            return arr;
        }
        static string Code(string text,char[,] codetable)
        {
            char[] letters = text.ToCharArray();
            for(int i = 0; i < text.Length; i++)
            {
                for(int j = 0; j < codetable.GetLength(1); j++)
                {
                    if (text[i] == codetable[0, j]) letters[i] = codetable[1, j];
                }
            }
            string str = new string(letters);
            return str;
        }
        static string DeCode(string text, char[,] codetable)
        {
            char[] letters = text.ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < codetable.GetLength(1); j++)
                {
                    if (text[i] == codetable[1, j]) letters[i] = codetable[0, j];
                }
            }
            string str = new string(letters);
            return str;
        }
    }
}
