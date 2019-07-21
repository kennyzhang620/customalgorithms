using System;
using System.Collections.Generic;
using System.Text;

namespace playgrounds
{
    public class Class1
    {
       
    public static int[] isPalidrome(int[] inputarray)
        {
            int[] output = new int[DetectSize(inputarray, 1000)];
            int index = 0;
      //      Console.WriteLine(Palindrome(10101010101010101));
            foreach (int c in inputarray)
            {
                if (Palindrome(c))
                {
                    if (index != (DetectSize(inputarray, 1000) - 1))
                    {
                        output[index] = c;
                        index++;
                    }
                }
             //   Console.WriteLine("Char:" + c);
            }
            return output;  

        }

    public static bool Palindrome(long input)
        {
            string check = input.ToString();
            int numberofElements = 0;

            foreach (char c in check)
            {
                numberofElements++;
            }

            string[] returned = new string[numberofElements];
            int index = 0;

            foreach (char c in check)
            {
                returned[index] = c.ToString();
                index++;
            }

            string confirm = "";
            for (int i = (index - 1); i>=0;i--)
            {
                confirm = confirm + returned[i];
             //   Console.WriteLine(confirm);
            }

            if (confirm == check)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    

    public static int Average(int[] inputarray)
        {
            int[] output = new int[DetectSize(inputarray, 1000)];

            for (int i = 0; i < (DetectSize(inputarray, 1000)); i++)
            {
              //  if (i != 3)
                output[0] = output[0] + inputarray[i];
              //  Console.WriteLine(output[0]);
            }
            output[1] = output[0] / DetectSize(inputarray, 1000);

            return output[1];
        }
      public static int[] Test2(int[] inputarray)
        {
            int[] output = new int[DetectSize(inputarray, 1000)];
            int maximum = inputarray[DetectSize(inputarray, 1000) - 1];
            int outputIndex = 0;

            if (maximum > inputarray[0])
            {
                //  Console.WriteLine("max: " +maximum + " indexM: " + DetectSize(inputarray, 1000));
                for (int i = 0; i < (DetectSize(inputarray, 1000) - 1); i++)
                {
                    for (int a = 1; a < maximum; a++)
                    {
                        //   Console.WriteLine("index: " + i);

                        if (i != DetectSize(inputarray, 1000))
                        {
                            //    Console.WriteLine(a * a + " as to: " + inputarray[i]);

                            if (a * a == inputarray[i])
                            {
                                output[outputIndex] = inputarray[i];
                                //   Console.WriteLine(output[outputIndex]);
                                i++;
                                a = 1;
                                if (outputIndex < maximum)
                                    outputIndex++;
                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Illegal input: End element is less than first element");
            }
            return output;
        }
        
      public static int DetectSize(int[] inputarray, int Guess)
        {
            int testint = 0;
            int output = 0;
            for (int i = 0;i < Guess; i++)
            {
                try
                {
                    testint = inputarray[i];
                }
                catch (Exception)
                {
                    output = i;
                    break;
                }
            }
            return output;
        }

       public static int[] Test1(int Maximum)
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
       public static int[] Test1Optimized(int Maximum)
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
