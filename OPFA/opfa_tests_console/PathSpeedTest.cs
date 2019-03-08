using opfa_common_managed;
using System;

namespace opfa_common_console
{
    public static class PathSpeedTest
    {
        #region Run Static Tests
        public static void RunStaticTest()
        {
            TestSpeedStatic(2, 1);

            TestSpeedStatic(4, 1);
            TestSpeedStatic(4, 1, 2, 2);

            TestSpeedStatic(8, 1);
            TestSpeedStatic(8, 1, 4, 4);
            TestSpeedStatic(8, 1, 2, 2);

            TestSpeedStatic(16, 1);
            TestSpeedStatic(16, 1, 8, 8);
            TestSpeedStatic(16, 1, 4, 4);
            TestSpeedStatic(16, 1, 2, 2);

            TestSpeedStatic(32, 1);
            TestSpeedStatic(32, 1, 16, 16);
            TestSpeedStatic(32, 1, 8, 8);
            TestSpeedStatic(32, 1, 4, 4);
            TestSpeedStatic(32, 1, 2, 2);

            TestSpeedStatic(64, 1);
            TestSpeedStatic(64, 1, 32, 32);
            TestSpeedStatic(64, 1, 16, 16);
            TestSpeedStatic(64, 1, 8, 8);
            TestSpeedStatic(64, 1, 4, 4);
            TestSpeedStatic(64, 1, 2, 2);

            TestSpeedStatic(128, 1);
            TestSpeedStatic(128, 1, 64, 64);
            TestSpeedStatic(128, 1, 32, 32);
            TestSpeedStatic(128, 1, 16, 16);
            TestSpeedStatic(128, 1, 8, 8);
            TestSpeedStatic(128, 1, 4, 4);
            TestSpeedStatic(128, 1, 2, 2);

            TestSpeedStatic(256, 2);
            TestSpeedStatic(256, 1, 128, 128);
            TestSpeedStatic(256, 1, 64, 64);
            TestSpeedStatic(256, 1, 32, 32);
            TestSpeedStatic(256, 1, 16, 16);
            TestSpeedStatic(256, 1, 8, 8);
            TestSpeedStatic(256, 1, 4, 4);
            TestSpeedStatic(256, 1, 2, 2);

            TestSpeedStatic(512, 5);
            TestSpeedStatic(512, 2, 256, 256);
            TestSpeedStatic(512, 1, 128, 128);
            TestSpeedStatic(512, 1, 64, 64);
            TestSpeedStatic(512, 1, 32, 32);
            TestSpeedStatic(512, 1, 16, 16);
            TestSpeedStatic(512, 1, 8, 8);
            TestSpeedStatic(512, 1, 4, 4);
            TestSpeedStatic(512, 1, 2, 2);

            TestSpeedStatic(1024, 10);
            TestSpeedStatic(1024, 5, 512, 512);
            TestSpeedStatic(1024, 2, 256, 256);
            TestSpeedStatic(1024, 1, 128, 128);
            TestSpeedStatic(1024, 1, 64, 64);
            TestSpeedStatic(1024, 1, 32, 32);
            TestSpeedStatic(1024, 1, 16, 16);
            TestSpeedStatic(1024, 1, 8, 8);
            TestSpeedStatic(1024, 1, 4, 4);
            TestSpeedStatic(1024, 1, 2, 2);

            TestSpeedStatic(2048, 20);
            TestSpeedStatic(2048, 10, 1024, 1024);
            TestSpeedStatic(2048, 5, 512, 512);
            TestSpeedStatic(2048, 2, 256, 256);
            TestSpeedStatic(2048, 1, 128, 128);
            TestSpeedStatic(2048, 1, 64, 64);
            TestSpeedStatic(2048, 1, 32, 32);
            TestSpeedStatic(2048, 1, 16, 16);
            TestSpeedStatic(2048, 1, 8, 8);
            TestSpeedStatic(2048, 1, 4, 4);
            TestSpeedStatic(2048, 1, 2, 2);

            TestSpeedStatic(4096, 40);
            TestSpeedStatic(4096, 20, 2048, 2048);
            TestSpeedStatic(4096, 10, 1024, 1024);
            TestSpeedStatic(4096, 5, 512, 512);
            TestSpeedStatic(4096, 2, 256, 256);
            TestSpeedStatic(4096, 1, 128, 128);
            TestSpeedStatic(4096, 1, 64, 64);
            TestSpeedStatic(4096, 1, 32, 32);
            TestSpeedStatic(4096, 1, 16, 16);
            TestSpeedStatic(4096, 1, 8, 8);
            TestSpeedStatic(4096, 1, 4, 4);
            TestSpeedStatic(4096, 1, 2, 2);

            TestSpeedStatic(8192, 80);
            TestSpeedStatic(8192, 40, 4096, 4096);
            TestSpeedStatic(8192, 20, 2048, 2048);
            TestSpeedStatic(8192, 10, 1024, 1024);
            TestSpeedStatic(8192, 5, 512, 512);
            TestSpeedStatic(8192, 2, 256, 256);
            TestSpeedStatic(8192, 1, 128, 128);
            TestSpeedStatic(8192, 1, 64, 64);
            TestSpeedStatic(8192, 1, 32, 32);
            TestSpeedStatic(8192, 1, 16, 16);
            TestSpeedStatic(8192, 1, 8, 8);
            TestSpeedStatic(8192, 1, 4, 4);
            TestSpeedStatic(8192, 1, 2, 2);

            TestSpeedStatic(16384, 160);
            TestSpeedStatic(16384, 80, 8192, 8192);
            TestSpeedStatic(16384, 40, 4096, 4096);
            TestSpeedStatic(16384, 20, 2048, 2048);
            TestSpeedStatic(16384, 10, 1024, 1024);
            TestSpeedStatic(16384, 5, 512, 512);
            TestSpeedStatic(16384, 2, 256, 256);
            TestSpeedStatic(16384, 1, 128, 128);
            TestSpeedStatic(16384, 1, 64, 64);
            TestSpeedStatic(16384, 1, 32, 32);
            TestSpeedStatic(16384, 1, 16, 16);
            TestSpeedStatic(16384, 1, 8, 8);
            TestSpeedStatic(16384, 1, 4, 4);
            TestSpeedStatic(16384, 1, 2, 2);

            TestSpeedStatic(32768, 420);
            TestSpeedStatic(32768, 160, 16384, 16384);
            TestSpeedStatic(32768, 80, 8192, 8192);
            TestSpeedStatic(32768, 40, 4096, 4096);
            TestSpeedStatic(32768, 20, 2048, 2048);
            TestSpeedStatic(32768, 10, 1024, 1024);
            TestSpeedStatic(32768, 5, 512, 512);
            TestSpeedStatic(32768, 2, 256, 256);
            TestSpeedStatic(32768, 1, 128, 128);
            TestSpeedStatic(32768, 1, 64, 64);
            TestSpeedStatic(32768, 1, 32, 32);
            TestSpeedStatic(32768, 1, 16, 16);
            TestSpeedStatic(32768, 1, 8, 8);
            TestSpeedStatic(32768, 1, 4, 4);
            TestSpeedStatic(32768, 1, 2, 2);
        }
        #endregion

        #region Run Random Tests
        public static void RunRandomTests(byte blockFrequency)
        {
            TestSpeedRandom(2, 1, blockFrequency);

            TestSpeedRandom(4, 1, blockFrequency);
            TestSpeedRandom(4, 1, 2, 2, blockFrequency);

            TestSpeedRandom(8, 1, blockFrequency);
            TestSpeedRandom(8, 1, 4, 4, blockFrequency);
            TestSpeedRandom(8, 1, 2, 2, blockFrequency);

            TestSpeedRandom(16, 1, blockFrequency);
            TestSpeedRandom(16, 1, 8, 8, blockFrequency);
            TestSpeedRandom(16, 1, 4, 4, blockFrequency);
            TestSpeedRandom(16, 1, 2, 2, blockFrequency);

            TestSpeedRandom(32, 1, blockFrequency);
            TestSpeedRandom(32, 1, 16, 16, blockFrequency);
            TestSpeedRandom(32, 1, 8, 8, blockFrequency);
            TestSpeedRandom(32, 1, 4, 4, blockFrequency);
            TestSpeedRandom(32, 1, 2, 2, blockFrequency);

            TestSpeedRandom(64, 1, blockFrequency);
            TestSpeedRandom(64, 1, 32, 32, blockFrequency);
            TestSpeedRandom(64, 1, 16, 16, blockFrequency);
            TestSpeedRandom(64, 1, 8, 8, blockFrequency);
            TestSpeedRandom(64, 1, 4, 4, blockFrequency);
            TestSpeedRandom(64, 1, 2, 2, blockFrequency);

            TestSpeedRandom(128, 1, blockFrequency);
            TestSpeedRandom(128, 1, 64, 64, blockFrequency);
            TestSpeedRandom(128, 1, 32, 32, blockFrequency);
            TestSpeedRandom(128, 1, 16, 16, blockFrequency);
            TestSpeedRandom(128, 1, 8, 8, blockFrequency);
            TestSpeedRandom(128, 1, 4, 4, blockFrequency);
            TestSpeedRandom(128, 1, 2, 2, blockFrequency);

            TestSpeedRandom(256, 2, blockFrequency);
            TestSpeedRandom(256, 1, 128, 128, blockFrequency);
            TestSpeedRandom(256, 1, 64, 64, blockFrequency);
            TestSpeedRandom(256, 1, 32, 32, blockFrequency);
            TestSpeedRandom(256, 1, 16, 16, blockFrequency);
            TestSpeedRandom(256, 1, 8, 8, blockFrequency);
            TestSpeedRandom(256, 1, 4, 4, blockFrequency);
            TestSpeedRandom(256, 1, 2, 2, blockFrequency);

            TestSpeedRandom(512, 5, blockFrequency);
            TestSpeedRandom(512, 2, 256, 256, blockFrequency);
            TestSpeedRandom(512, 1, 128, 128, blockFrequency);
            TestSpeedRandom(512, 1, 64, 64, blockFrequency);
            TestSpeedRandom(512, 1, 32, 32, blockFrequency);
            TestSpeedRandom(512, 1, 16, 16, blockFrequency);
            TestSpeedRandom(512, 1, 8, 8, blockFrequency);
            TestSpeedRandom(512, 1, 4, 4, blockFrequency);
            TestSpeedRandom(512, 1, 2, 2, blockFrequency);

            TestSpeedRandom(1024, 10, blockFrequency);
            TestSpeedRandom(1024, 5, 512, 512, blockFrequency);
            TestSpeedRandom(1024, 2, 256, 256, blockFrequency);
            TestSpeedRandom(1024, 1, 128, 128, blockFrequency);
            TestSpeedRandom(1024, 1, 64, 64, blockFrequency);
            TestSpeedRandom(1024, 1, 32, 32, blockFrequency);
            TestSpeedRandom(1024, 1, 16, 16, blockFrequency);
            TestSpeedRandom(1024, 1, 8, 8, blockFrequency);
            TestSpeedRandom(1024, 1, 4, 4, blockFrequency);
            TestSpeedRandom(1024, 1, 2, 2, blockFrequency);

            TestSpeedRandom(2048, 20, blockFrequency);
            TestSpeedRandom(2048, 10, 1024, 1024, blockFrequency);
            TestSpeedRandom(2048, 5, 512, 512, blockFrequency);
            TestSpeedRandom(2048, 2, 256, 256, blockFrequency);
            TestSpeedRandom(2048, 1, 128, 128, blockFrequency);
            TestSpeedRandom(2048, 1, 64, 64, blockFrequency);
            TestSpeedRandom(2048, 1, 32, 32, blockFrequency);
            TestSpeedRandom(2048, 1, 16, 16, blockFrequency);
            TestSpeedRandom(2048, 1, 8, 8, blockFrequency);
            TestSpeedRandom(2048, 1, 4, 4, blockFrequency);
            TestSpeedRandom(2048, 1, 2, 2, blockFrequency);

            TestSpeedRandom(4096, 40, blockFrequency);
            TestSpeedRandom(4096, 20, 2048, 2048, blockFrequency);
            TestSpeedRandom(4096, 10, 1024, 1024, blockFrequency);
            TestSpeedRandom(4096, 5, 512, 512, blockFrequency);
            TestSpeedRandom(4096, 2, 256, 256, blockFrequency);
            TestSpeedRandom(4096, 1, 128, 128, blockFrequency);
            TestSpeedRandom(4096, 1, 64, 64, blockFrequency);
            TestSpeedRandom(4096, 1, 32, 32, blockFrequency);
            TestSpeedRandom(4096, 1, 16, 16, blockFrequency);
            TestSpeedRandom(4096, 1, 8, 8, blockFrequency);
            TestSpeedRandom(4096, 1, 4, 4, blockFrequency);
            TestSpeedRandom(4096, 1, 2, 2, blockFrequency);

            TestSpeedRandom(8192, 80, blockFrequency);
            TestSpeedRandom(8192, 40, 4096, 4096, blockFrequency);
            TestSpeedRandom(8192, 20, 2048, 2048, blockFrequency);
            TestSpeedRandom(8192, 10, 1024, 1024, blockFrequency);
            TestSpeedRandom(8192, 5, 512, 512, blockFrequency);
            TestSpeedRandom(8192, 2, 256, 256, blockFrequency);
            TestSpeedRandom(8192, 1, 128, 128, blockFrequency);
            TestSpeedRandom(8192, 1, 64, 64, blockFrequency);
            TestSpeedRandom(8192, 1, 32, 32, blockFrequency);
            TestSpeedRandom(8192, 1, 16, 16, blockFrequency);
            TestSpeedRandom(8192, 1, 8, 8, blockFrequency);
            TestSpeedRandom(8192, 1, 4, 4, blockFrequency);
            TestSpeedRandom(8192, 1, 2, 2, blockFrequency);

            TestSpeedRandom(16384, 160, blockFrequency);
            TestSpeedRandom(16384, 80, 8192, 8192, blockFrequency);
            TestSpeedRandom(16384, 40, 4096, 4096, blockFrequency);
            TestSpeedRandom(16384, 20, 2048, 2048, blockFrequency);
            TestSpeedRandom(16384, 10, 1024, 1024, blockFrequency);
            TestSpeedRandom(16384, 5, 512, 512, blockFrequency);
            TestSpeedRandom(16384, 2, 256, 256, blockFrequency);
            TestSpeedRandom(16384, 1, 128, 128, blockFrequency);
            TestSpeedRandom(16384, 1, 64, 64, blockFrequency);
            TestSpeedRandom(16384, 1, 32, 32, blockFrequency);
            TestSpeedRandom(16384, 1, 16, 16, blockFrequency);
            TestSpeedRandom(16384, 1, 8, 8, blockFrequency);
            TestSpeedRandom(16384, 1, 4, 4, blockFrequency);
            TestSpeedRandom(16384, 1, 2, 2, blockFrequency);

            TestSpeedRandom(32768, 420, blockFrequency);
            TestSpeedRandom(32768, 160, 16384, 16384, blockFrequency);
            TestSpeedRandom(32768, 80, 8192, 8192, blockFrequency);
            TestSpeedRandom(32768, 40, 4096, 4096, blockFrequency);
            TestSpeedRandom(32768, 20, 2048, 2048, blockFrequency);
            TestSpeedRandom(32768, 10, 1024, 1024, blockFrequency);
            TestSpeedRandom(32768, 5, 512, 512, blockFrequency);
            TestSpeedRandom(32768, 2, 256, 256, blockFrequency);
            TestSpeedRandom(32768, 1, 128, 128, blockFrequency);
            TestSpeedRandom(32768, 1, 64, 64, blockFrequency);
            TestSpeedRandom(32768, 1, 32, 32, blockFrequency);
            TestSpeedRandom(32768, 1, 16, 16, blockFrequency);
            TestSpeedRandom(32768, 1, 8, 8, blockFrequency);
            TestSpeedRandom(32768, 1, 4, 4, blockFrequency);
            TestSpeedRandom(32768, 1, 2, 2, blockFrequency);
        }
        #endregion

        #region Test Speed Static
        private static void TestSpeedStatic(ushort mapSize, int failTimeMillis)
        {
            Profile p;

            //dummy run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));
            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Map :             " + mapSize + "x" + mapSize);
            Console.WriteLine("MapCreationTime : " + p.MapCreationTime);
            Console.WriteLine("PathLength :      " + p.PathLength);
            if (p.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + p.PathRunTime);
            Console.WriteLine();
        }
        private static void TestSpeedStatic(ushort mapSize, int failTimeMillis, ushort targetX, ushort targetY)
        {
            Profile p;

            //dummy run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY);
            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Map :             " + mapSize + "x" + mapSize);
            Console.WriteLine("MapCreationTime : " + p.MapCreationTime);
            Console.WriteLine("PathLength :      " + p.PathLength);
            if (p.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + p.PathRunTime);
            Console.WriteLine();
        }
        #endregion

        #region Test Speed Random
        private static void TestSpeedRandom(ushort mapSize, int failTimeMillis, byte blockFrequency)
        {
            Profile p;

            //dummy run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));
            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: true, blockFrequency: blockFrequency, resistanceCap: 127,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Map :             " + mapSize + "x" + mapSize);
            Console.WriteLine("MapCreationTime : " + p.MapCreationTime);
            Console.WriteLine("PathLength :      " + p.PathLength);
            if (p.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + p.PathRunTime);
            Console.WriteLine();
        }
        private static void TestSpeedRandom(ushort mapSize, int failTimeMillis, ushort targetX, ushort targetY, byte blockFrequency)
        {
            Profile p;

            //dummy run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY);
            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: blockFrequency, resistanceCap: 127,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Map :             " + mapSize + "x" + mapSize);
            Console.WriteLine("MapCreationTime : " + p.MapCreationTime);
            Console.WriteLine("PathLength :      " + p.PathLength);
            if (p.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + p.PathRunTime);
            Console.WriteLine();
        }
        #endregion
    }
}
