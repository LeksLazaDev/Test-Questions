using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question5
{
    class Program
    {
        
        static void Main(string[] args)
        {
            double fibPosition = 50;
            
            Console.WriteLine("Test");
            RecursiveFib(0,1,1,fibPosition);
            Console.Read();
        }

        public static void RecursiveFib(double first,double second, double count, double pos)
        {
            Console.Write(first+";");
            if (count<pos)
            {
                RecursiveFib(second, first + second, count+1,pos);
            }
        }
    }
}
