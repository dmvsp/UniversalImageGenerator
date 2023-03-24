using System;
using System.Collections.Generic;
using System.Linq;

namespace UIG_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimension = 4;

            var demo = new DemoClass(1, dimension, false);

            demo.Processing();

            Console.WriteLine("Done 1");
            Console.ReadKey();

            var my_l = new List<List<string>>();

            for (int i=0; i< dimension; i++)
            {
                my_l.Add(demo.my_b);
            }

            int cc = 0;

            List<string> pixelCoords = new List<string>();
            
            foreach (var row in Cartesian.CartesianProduct(my_l)) 
            {
                cc++;

                //Console.WriteLine(String.Join(",", row));
                pixelCoords.Add(String.Join(",", row));
            }

            Console.WriteLine("Done 2" + " total" + cc.ToString());
            Console.ReadKey();

            var uig_gen = new UIG_ImageGenerator(pixelCoords, dimension, "d:\\uig\\");

            uig_gen.DoIt();

            Console.WriteLine("Done all");
        }

    }
}

