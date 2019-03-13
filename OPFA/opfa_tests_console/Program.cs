using opfa_common_managed;
using System;

namespace opfa_common_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PathSpeedTest.RunSimpleTest();
            //PathSpeedTest.RunRandomTests(5);
            Console.Read();
        }
    }
}
