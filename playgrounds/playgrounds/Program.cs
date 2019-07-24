using System;
using System.Threading;
using System.Timers;

namespace playgrounds
{
    class Program: Class1
    {
        static int elapsedTime = 0;
        // Given an upper bound, it searches for prime numbers up to that point.
        static void Main(string[] args)
        {
            Console.WriteLine("Run which program: PrimeDetector/ArrayCount/RootDetector/BasicAverager/Palindrome/NumApprox/StressTest/Benchmark");
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

                int[] subdivisions = new int[8]; //5 elements [4]

                Console.WriteLine("received: " + a);

                Console.WriteLine("Long/Optimized/MultiThreaded Mode? ");
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
                    case "MultiThreaded":
                        MultiThreaded();
                        break;
                    default:
                        Console.WriteLine("Error. Please Try Again");
                        break;
                }

                void MultiThreaded()
                {
                    int maxthreads = 2;
                    Console.WriteLine("How many threads: (Default 2) ");
                    bool b = Int32.TryParse(Console.ReadLine(), out maxthreads);
                    if ((maxthreads == 0)||(maxthreads > 7))
                    {
                        Console.WriteLine("Unexpected response: Defaulting to 2. ");
                        maxthreads = 2;
                    }

                    if (a < 1000)
                    {
                        Console.WriteLine("Multithreaded Prime generation not supported with bounds less than 1000.");

                    }
                    else
                    {
                        for (int i = 0; i <= maxthreads; i++)
                        {
                            if (i != 0)
                            {
                                subdivisions[i] = (a / maxthreads) * i;//{1, (a / 4) * 1, (a / 4) * 2, (a / 4) * 3, (a / 4) * 4 }
      
                            }
                            else
                            {
                                subdivisions[0] = 1;
                            }
                            Console.WriteLine("SD: " + subdivisions[i]);
                        }

                        //    for (int i = 0; i < maxthreads;i++) {

                        if (maxthreads > 1)
                        {
                          //  Console.WriteLine("Values(" + subdivisions[i] + ", " + subdivisions[i + 1] + ")");
                            Thread thread = new Thread(() => ThreadM8(subdivisions[0], subdivisions[1]));
                            thread.Start();
                            Thread thread2 = new Thread(() => ThreadM8(subdivisions[1], subdivisions[2]));
                            thread2.Start();
                        }
                        if (maxthreads > 2)
                        {
                            //  Console.WriteLine("Values(" + subdivisions[i] + ", " + subdivisions[i + 1] + ")");
                            Thread thread3 = new Thread(() => ThreadM8(subdivisions[2], subdivisions[3]));
                            thread3.Start();
                        }
                        if (maxthreads > 3)
                        {
                            //  Console.WriteLine("Values(" + subdivisions[i] + ", " + subdivisions[i + 1] + ")");
                            Thread thread4 = new Thread(() => ThreadM8(subdivisions[3], subdivisions[4]));
                            thread4.Start();
                        }
                        if (maxthreads > 4)
                        {
                            //  Console.WriteLine("Values(" + subdivisions[i] + ", " + subdivisions[i + 1] + ")");
                            Thread thread5 = new Thread(() => ThreadM8(subdivisions[4], subdivisions[5]));
                            thread5.Start();
                        }
                        if (maxthreads > 5)
                        {
                            //  Console.WriteLine("Values(" + subdivisions[i] + ", " + subdivisions[i + 1] + ")");
                            Thread thread6 = new Thread(() => ThreadM8(subdivisions[5], subdivisions[6]));
                            thread6.Start();
                        }
                        if (maxthreads > 6)
                        {
                            //  Console.WriteLine("Values(" + subdivisions[i] + ", " + subdivisions[i + 1] + ")");
                            Thread thread7 = new Thread(() => ThreadM8(subdivisions[6], subdivisions[7]));
                            thread7.Start();
                        }
                        if (maxthreads > 7)
                        {
                            //  Console.WriteLine("Values(" + subdivisions[i] + ", " + subdivisions[i + 1] + ")");
                            Thread thread8 = new Thread(() => ThreadM8(subdivisions[7], subdivisions[8]));
                            thread8.Start();
                        }

                        //   }
                    }

                }

                void ThreadM8(int start, int end)
                {
                    int endvar = 1;
                    if (start % 2 == 0)
                    {
                        endvar = start + 1;
                        // Console.WriteLine("EV: " + endvar);
                    }
                    else
                    {
                        endvar = start;
                        //  Console.WriteLine("EV: " + endvar);
                    }

                    int[] output = Class1.Test1OptimizedMT(end, endvar);
                    //   Console.WriteLine("OT: " + onThread);

                    foreach (int i in output)
                    {
                        if (i != 0)
                            Console.WriteLine("Prime: " + i);
                    }
                    /*    
                    if (onThread < (DetectSize(subdivisions, 1000) - 1))
                        onThread++;
                        */
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
                int threads = 2;
                Console.WriteLine("How many threads: (Default: 2)");
                bool x = Int32.TryParse(Console.ReadLine(), out threads);
                if (threads == 0)
                {
                    threads = 2;
                }
                Console.WriteLine("Stress Testing CPU... Quit application to stop.");
                for (int i=0; i<(threads - 1);i++)
                {
                    Thread threadM = new Thread(Stresser);
                    threadM.Start();
                }

                while (start == 0)
                {

                    Stresser();
                }

                void Stresser()
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
                System.Timers.Timer timer = new System.Timers.Timer(1000);
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
                Console.WriteLine("Brute Force: Multithreaded (4) Upper Limit: 1375000");
                Thread thread2 = new Thread(() => Class1.Test1OptimizedMT(687500, 343750));
                Thread thread3 = new Thread(() => Class1.Test1OptimizedMT(1031250, 687500));
                Thread thread4 = new Thread(() => Class1.Test1OptimizedMT(1375000, 1031250));
                thread2.Start();
                thread3.Start();
                thread4.Start();
                int[] samplearray = Class1.Test1OptimizedMT(343750, 1);
                Console.WriteLine("Finished in: " + elapsedTime + "s");
                Console.WriteLine("Palindromes: Prime Numbers. Upper Limit: 375000");
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
