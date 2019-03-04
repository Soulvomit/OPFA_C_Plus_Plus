using opfa_common_managed;

namespace opfa_common_managed_test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Profiler.ProfileCubic(onThread: true, random: true, blockFrequency: 2, resistanceCap: 10);
            //Profiler.ProfileGrid(onThread: true, random: true, blockFrequency: 10, resistanceCap: 20);
            Profiler.ProfileGridRun(blockFrequency: 3, resistanceCap: 10, random: false);
        }
    }
}
