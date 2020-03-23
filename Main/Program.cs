using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        public event EventHandler eventHandler;
        // delegate pentru eveniment
        public delegate void InfoDelegate(object obj);
        // event ce foloseste delegate InfoDelegate
        public event InfoDelegate InfoChanged;
        // data membru
        object _obiect;
        public object SetInfo
        {
            set
            {
                _obiect = value;
                // genereaza eveniment
                InfoChanged(_obiect);
            }
        }
        private int input_number = 1000000;
        public void BiggestPrimeNumberSmallerThanNumberGiven1()
        {
            int number = input_number;
            while (number > 1)
            {
                number--;
                bool ok = true;
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok == true)
                {
                    Console.WriteLine("Rezultat fir de executie 1 este: " + number + " la timpul: " + DateTime.Now + DateTime.Now.Millisecond);
                    break;
                }
            }
        }

        public void BiggestPrimeNumberSmallerThanNumberGiven2()
        {
            int biggestPrimeNum = 2;
            var random = new Random();
            for (int i = 0; i < 500; i++)
            {
                int num = random.Next(input_number);
                if (num > biggestPrimeNum)
                {
                    bool ok = true;
                    for (int j = 2; j < num; j++)
                    {
                        if (num % j == 0)
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok == true && num > biggestPrimeNum)
                    {
                        biggestPrimeNum = num;
                    }

                }
            }
            Console.WriteLine("Rezultat fir de executie 2 : " + biggestPrimeNum + " la timpul: "+DateTime.Now + DateTime.Now.Millisecond);
        }
        static void Main(string[] args)
        {
            Print();
        }

        private static void Print()
        {
            Console.WriteLine();
            Console.Write("Start fir de executie 1, ");
            Console.Write("Start fir de executie 2: ");
            Console.WriteLine(DateTime.Now +" "+ DateTime.Now.Millisecond);
            Thread t1 = new Thread(new Program().BiggestPrimeNumberSmallerThanNumberGiven1);
            Thread t2 = new Thread(new Program().BiggestPrimeNumberSmallerThanNumberGiven2);
            t1.Start();
            t2.Start();
            var ok1 = false;
            var ok2 = false;

            while (t1.IsAlive || t2.IsAlive)
            {
                if (!t1.IsAlive && ok1 == false)
                {
                    ok1 = true;
                    Console.WriteLine("firul de executie 1 s-a oprit");
                }  
                if (!t2.IsAlive && ok2 == false)
                {
                    ok2 = true;
                    Console.WriteLine("firul de executie 2 s-a oprit");
                }

            }


            Console.WriteLine("stare fir de executie 1 " + t1.ThreadState);
            Console.WriteLine("stare fir de executie 2 "  + t2.ThreadState);
            // Console.WriteLine("Task 1 terminat Rezultat: "  + " :"+ DateTime.Now.Millisecond);
            // Console.WriteLine("Task 2 terminat Rezultat: "  + " :"+ DateTime.Now.Millisecond);
        }
    }
}
