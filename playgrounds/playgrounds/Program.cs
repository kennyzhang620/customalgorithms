using System;

namespace playgrounds
{
    class Program
    {
        // Given an upper bound, it searches for prime numbers up to that point.
        static void Main(string[] args)
        {
            Console.WriteLine("Run which program: PrimeDetector/ArrayCount/RootDetector/BasicAverager");
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
                        primes = Test1(a);
                        break;
                    case "Optimized":
                        primes = Test1Optimized(a);
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

            int[] Test1(int Maximum)
            {
                Console.WriteLine("Computing..." + " Upper Bound: " + Maximum);
                int[] output = new int[Maximum];
                int outputIndex = 0;

                output[0] = 1;
                for (int i = 1; i < Maximum; i++)
                {
                  //  Console.WriteLine("On: " + i);
                    for (int index = 1; index < i; index++)
                    {
                       // Console.WriteLine(i + " divided by " + index);
                        if ((index != 1))
                        {
                            if (i % index != 0)
                            {
                                output[outputIndex] = i;
                                 //  Console.WriteLine(i + " is Prime.");
                            }
                            else
                            {
                                output[outputIndex] = 0;
                                 // Console.WriteLine(i + " is not Prime");
                                i++;
                                index = 1;
                            }    
                        }
                        else
                        {
                                output[outputIndex] = i;
                        }
                    }
                    if (outputIndex < (Maximum - 1))
                        outputIndex++;
                }
                return output;
            }
            int[] Test1Optimized(int Maximum)
            {
                Console.WriteLine("Computing..." + " Upper Bound: " + Maximum);
                int[] output = new int[Maximum];
                int outputIndex = 0;

                output[0] = 1;
                for (int i = 1; i < Maximum; i = i + 2)
                {
                    //  Console.WriteLine("On: " + i);
                    for (int index = 1; index < i; index = index + 2)
                    {
                        // Console.WriteLine(i + " divided by " + index);
                        if ((index != 1))
                        {
                            if (i % index != 0)
                            {
                                output[outputIndex] = i;
                                //  Console.WriteLine(i + " is Prime.");
                            }
                            else
                            {
                                output[outputIndex] = 0;
                                // Console.WriteLine(i + " is not Prime");
                                i++;
                                index = 1;
                            }
                        }
                        else
                        {
                            output[outputIndex] = i;
                        }
                    }
                    if (outputIndex < (Maximum - 1))
                        outputIndex++;
                }
                return output;
            }

        }
    }
}
