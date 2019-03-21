using opfa_common_managed;
using System;

namespace opfa_common_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            //PathSpeedTest.RunRandomTests(5);
            PathSpeedTest.RunSimpleTest();
            if (PathSpeedTest.ManagedResults > PathSpeedTest.NativeResults)
            {
                Console.WriteLine("Final winner is Native by: " + (float)PathSpeedTest.ManagedResults / PathSpeedTest.NativeResults);
            }
            else if (PathSpeedTest.NativeResults < PathSpeedTest.ManagedResults)
            {
                Console.WriteLine("Final winner is Native by: " + (float)PathSpeedTest.NativeResults / PathSpeedTest.ManagedResults);
            }
            else
            {
                Console.WriteLine("Final winner: Incoclusive");
            }
            Console.Read();
            */
            //Profiler.ProfileGridRun(5, 64, true, GridPathType.Normal, EnviromentType.Managed);
            Profiler.ProfileGridRun(3, 64, true, GridPathType.Normal, EnviromentType.Native);
        }
    }
}
