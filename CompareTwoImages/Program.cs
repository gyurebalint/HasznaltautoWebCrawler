using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CompareTwoImages
{
    class Program
    {
        static void Main(string[] args)
        {
            string GetHash(Bitmap bmpSource)
            {

                string stringResult = "";
                List<bool> lResult = new List<bool>();
                //create new image with 16x16 pixel
                Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
                for (int j = 0; j < bmpMin.Height; j++)
                {
                    for (int i = 0; i < bmpMin.Width; i++)
                    {
                        //reduce colors to true / false 
                        bool trueOrFalse = bmpMin.GetPixel(i, j).GetBrightness() < 0.5f;
                        lResult.Add(trueOrFalse);
                        if (trueOrFalse)
                        {
                            stringResult += "1";
                        }
                        else
                        {
                            stringResult += "0";
                        }
                    }
                }

                return stringResult;
            }
            //16038004_1.jpg
            string iHash1 = GetHash(new Bitmap(@"C:\Users\Gyure Balint\Documents\MyOwn\Repos\HasznaltAuto\16038004_1.jpg"));
            string iHash2 = GetHash(new Bitmap(@"C:\Users\Gyure Balint\Documents\MyOwn\Repos\HasznaltAuto\16038004_2.jpg"));


            //determine the number of equal pixel (x of 256)
            int equalElements = iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq);

            Console.WriteLine(equalElements);
            Console.WriteLine();
            Console.ReadKey();
            //string blah = "";
            //string trueVar = "1";
            //string falseVar = "0";
            //foreach (var item in iHash1)
            //{
            //    if (item==true)
            //    {
            //        blah += trueVar;
            //    }
            //    else
            //    {
            //        blah += falseVar;
            //    }
            //}
        }
    }
}
