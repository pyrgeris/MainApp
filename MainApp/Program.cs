using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MainApp
{
    class Program
    {
        [DllImport("BraidDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void braidcorrelation(string inputfile, int length, int sequences, int maxb, int interval);

        [DllImport("BraidDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void print_line(string str);
        static void Main(string[] args)
        {
            string inputfile = "C:\\Users\\riris\\Documents\\Visual Studio 2013\\Projects\\BraidDll\\BraidDll\\input.dat";
            int length = 131072;
            int interval = 50000;
            int maxb = 16;
            int sequences = 2;

            print_line("wooohooo");
            Console.ReadLine();
            braidcorrelation(inputfile, length, sequences, maxb, interval);
            
            Console.ReadLine();
        }
    }
}
