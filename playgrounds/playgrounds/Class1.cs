using System;
using System.Collections.Generic;
using System.Text;

namespace playgrounds
{
    public class Class1
    {
       
    public static int[] isPalidrome(int[] inputarray)
        {
            int[] output;

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
    }
}
