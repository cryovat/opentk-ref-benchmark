using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using OpenToolkit.Mathematics;

namespace opentk_ref_benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random(12345);

            Quaternion q1 = new Quaternion((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble()), q2;
            Vector4 v1 = new Vector4((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble()), v2;

            var sum = 0f;

            var sw = new Stopwatch();
            sw.Start();

            for (float i = 0; i < 16777216; i++)
            {
                Quaternion.Multiply(ref q1, i, out q2);
                Vector4.Transform(ref v1, ref q2, out v2);

                sum += v2.LengthFast;
            }

            sw.Stop();

            Console.WriteLine("Elapsed time (ref): {0}, sum: {1:N1}", sw.Elapsed, sum);
        }
    }
}
