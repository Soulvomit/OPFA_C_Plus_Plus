using System;
using System.Threading;

namespace opfa_common_managed
{
    #if !v35
    internal static class StaticRandom
    {
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        public static int Rand()
        {
            return random.Value.Next();
        }

        public static int Rand(int minVal, int maxVal)
        {
            return random.Value.Next(minVal, maxVal);
        }
    }
    #endif
}
