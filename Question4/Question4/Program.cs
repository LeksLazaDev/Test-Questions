using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number you would like to find all the prime numbers for...");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("You have chosen {0} as a value to find all prime number for.\n", n);
            int sumEratosthenes=PrimeEratosthenes(n);
            int sumCustom= PrimeCustom(n);

            Console.WriteLine("total sum for the prime numbers of: {0}\nUsing the 'Sieve of Eratosthenes algorithm' {1}\nUsing a custom algorithm {2}",n, sumEratosthenes,sumCustom);
            
            Console.Read();
        }

        private static int PrimeEratosthenes(int n)//using //using Sieve of Eratosthenes algorithm
        {
            bool[] prime = new bool[n + 1];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                prime[i] = true;//set all values to be true...
            }

            for (int p = 2; p * p <= n; p++)
            {
                if (prime[p] == true)
                {
                    for (int j = p * p; j <= n; j += p)
                    {
                        prime[j] = false;
                    }
                }
            }


            for (int i = 2; i < n; i++)
            {
                if (prime[i] == true)
                    sum += i;
            }
            return sum;
        }

        private static int PrimeCustom(int n)// algorithm that iterates the position of the value and check whether the value is a whole number.
        {
            int[] primeArray = new int[n];
            int sum = 0;

            for (int i = 2; i < n; i++)//iterate the position from position 2
            {
                int p = i;
                if (p == 2)// don't use mod because even-> exception
                    primeArray[i] = p;
                else if (p > 2)
                {
                    bool flag = true;
                    for (int j = 2; j < p; j++)// iterate to check mod against position
                    {
                        if (p % j == 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if(flag==true)
                        primeArray[i] = p;
                }
                
            }

            foreach (int item in primeArray)
            {
                if (item > 0)
                    sum += item;
            }
            return sum;
        }
    }
}

