using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1a
{
    public class Program
    {
        static void Main(string[] args)
        {
            int length = 0;
            int start = 0;
            string ans;

            while (true)
            {
                Console.Write("How many times:");
                try
                {
                    length = Math.Abs(Int32.Parse(Console.ReadLine()));
                }
                catch (FormatException e)
                {
                    length = 10;
                    Console.WriteLine(e.Message);
                }
                Console.Write("Where to start?");
                try
                {
                    start = Math.Abs(Int32.Parse(Console.ReadLine()));
                }
                catch (FormatException e)
                {
                    start = 0;
                    Console.WriteLine(e.Message);
                }
                Fibonacci(length,start);
                Console.Write("End? (y/n):");
                ans = Console.ReadLine();
                if (ans.Trim().Length == 1 && ans.ToLower() == "y")
                {
                    break;
                }
            }
        }
        public static int Fibonacci(int length, int start)
        {
            int last = 0;
            int current = 1;
            int temp;
            int index = 0;
            string filepath = @"C:\TEMP\FIBONACCI.TXT";
            string dirpath = @"C:\TEMP";


            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            using (StreamWriter sw = File.CreateText(filepath))
            {
                while (true)
                {
                    if (current >= start)
                    {
                        if (index == length)
                        {
                            return index;
                        }
                        index++;
                        sw.WriteLine(current);
                    }
                    temp = current;
                    current += last;
                    last = temp;
                }
            }
        }
    }
}
