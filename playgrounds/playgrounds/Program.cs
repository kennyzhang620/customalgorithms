﻿using System;
using System.Timers;

namespace playgrounds
{
    class Program: Class1
    {
        static int elapsedTime = 0;
        // Given an upper bound, it searches for prime numbers up to that point.
        static void Main(string[] args)
        {
            Console.WriteLine("Run which program: PrimeDetector/ArrayCount/RootDetector/BasicAverager/Palindrome/NumApprox/StressTest");
            string input = Console.ReadLine();

            switch (input) {
                case "PrimeDetector":
                    PrimeDetector();
                    break;
                case "ArrayCount":
                    ArrayDetector();
                    break;
                case "RootDetector":
                    RootDetector();
                    break;
                case "BasicAverager":
                    Averager();
                    break;
                case "Palindrome":
                    Palindrome();
                    break;
                case "Benchmark":
                    Benchmark();
                    break;
                case "NumApprox":
                    NumberApprox();
                    break;
                case "StressTest":
                    StressTest();
                    break;
                default:
                    Console.WriteLine("Error. Please Try Again");
                    break;

            }

            void PrimeDetector()
            {
                        Console.WriteLine("Enter your maximum: ");
                bool x = Int32.TryParse(Console.ReadLine(), out int a);

                Console.WriteLine("received: " + a);

                Console.WriteLine("Long or Optimized Mode? ");
                string input2 = Console.ReadLine();
                int[] primes = new int[a];

                switch (input2)
                {
                    case "Long":
                        primes = Class1.Test1(a);
                        break;
                    case "Optimized":
                        primes = Class1.Test1Optimized(a);
                        break;
                    default:
                        Console.WriteLine("Error. Please Try Again");
                        break;
                }

                for (int ab = 0; ab < (a - 1); ab++)
                {
                    Console.WriteLine("Prime: " + primes[ab]);

                    if (primes[ab] == 0)
                        break;
                }
                //   Console.WriteLine("Primes: " + Test1(a));

            }

            void ArrayDetector() {
                Console.WriteLine("Enter your array: ");
                try
                {
                    int[] arrayinput = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);

                    Console.WriteLine("Detected Size: " + Class1.DetectSize(arrayinput, 1000));
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to detect array.");
                }
            }

            void Averager()
            {
                Console.WriteLine("Enter your array: ");
                try
                {
                    int[] arrayinput = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);

                    Console.WriteLine("Calculated Average: " + Class1.Average(arrayinput));
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to detect array.");
                }
            }

            void RootDetector()
            {
                Console.WriteLine("Enter your array: ");
        
                    int[] arrayinput = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);
                    int[] outputarray = Class1.Test2(arrayinput);

                    Console.WriteLine( "Size: "+Class1.DetectSize(arrayinput, 1000));
                    for (int ab = 0; ab < (Class1.DetectSize(arrayinput, 1000)); ab++)
                    {
                        Console.WriteLine("Rootable: " + outputarray[ab]);

                        if (outputarray[ab] == 0)
                            break;
                    }

                
   
            }

            void Palindrome()
            {
                Console.WriteLine("Enter your array: ");

                int[] arrayinput = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);
                int[] outputarray = Class1.isPalidrome(arrayinput);

                Console.WriteLine("Size: " + Class1.DetectSize(arrayinput, 1000));
                for (int ab = 0; ab < (Class1.DetectSize(arrayinput, 1000)); ab++)
                {
                    Console.WriteLine("Palindromes: " + outputarray[ab]);

                    if (outputarray[ab] == 0)
                        break;
                }

            }

            void NumberApprox()
            {
                Console.WriteLine("Enter your array: ");

                int[] arrayinput = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);
                int average = Average(arrayinput);

                int[] outputarray = NumericalApprox(arrayinput,average);

                Console.WriteLine("Size: " + Class1.DetectSize(arrayinput, 1000));
                for (int ab = 0; ab < (Class1.DetectSize(arrayinput, 1000)); ab++)
                {
                    Console.WriteLine("Approximates to Average - " + average + ": " + outputarray[ab]);

                    if (outputarray[ab] == 0)
                        break;
                }

            }

            void StressTest()
            {
                int start = 0;
                Console.WriteLine("Stress Testing CPU... Quit application to stop.");
                while (start == 0)
                {
                    Console.WriteLine("Brute Force: Prime Numbers (Optimized). Upper Limit: 1000000000");
                    int[] testarray = Test1Optimized(1000000000);
                    Console.WriteLine("Palindromes: Previous Setup. Upper Limit: 1000000000");
                    int[] testarray2 = isPalidrome(testarray);
                }
            }

            void Benchmark()
            {
                Console.WriteLine("Initalizing System...");
                Timer timer = new Timer(1000);
                timer.Elapsed += RecordTime;
                timer.Enabled = true;
                timer.AutoReset = true;
                timer.Start();

                Console.WriteLine("Benchmarking...");
                Console.WriteLine("Brute Force: Prime Numbers. Upper Limit: 2500");
                Test1(2500);
                Console.WriteLine("Finished in: " + elapsedTime + "s");
                Console.WriteLine("Brute Force: Prime Numbers. Upper Limit: 75000");
                Test1(75000);
                Console.WriteLine("Finished in: " + elapsedTime + "s");
                Console.WriteLine("Brute Force: Prime Numbers. Upper Limit: 125000");
                Test1(125000);
                Console.WriteLine("Finished in: " + elapsedTime + "s");
                Console.WriteLine("Brute Force: Prime Numbers (Optimized). Upper Limit: 375000");
                int[] testarray = Test1Optimized(375000);
                Console.WriteLine("Finished in: " + elapsedTime + "s");
                Console.WriteLine("Palindromes: Previous Setup. Upper Limit: 375000");
                int[] testarray2 = isPalidrome(testarray);
                Console.WriteLine("Finished in: " + elapsedTime + "s");
                Console.WriteLine("Average Value Function: Palindromes.");
                int average = Average(testarray2);
                Console.WriteLine(average);
                Console.WriteLine("Finished in: " + elapsedTime + "s");
                Console.WriteLine("Numerical Average Approximation: Palindromes");
                int[] testarrayf = NumericalApprox(testarray2, average);
                Console.WriteLine("Finished in: " + elapsedTime + "s");
                Console.WriteLine("Benchmarking Complete. Elapsed Time: " + elapsedTime + "s");
                timer.Stop();
            }


        }

        private static void RecordTime(Object source, ElapsedEventArgs e)
        {
          // Console.WriteLine(elapsedTime);
            elapsedTime++;
        }
    }
}
