using opfa_common_managed;
using System;

namespace opfa_common_console
{
    public static class PathSpeedTest
    {
        #region Run Simple Tests
        public static void RunSimpleTest()
        {
            TestSpeedSimple(2, 1);

            TestSpeedSimple(4, 1);
            TestSpeedSimple(4, 1, 2, 2);

            TestSpeedSimple(8, 1);
            TestSpeedSimple(8, 1, 4, 4);
            TestSpeedSimple(8, 1, 2, 2);

            TestSpeedSimple(16, 1);
            TestSpeedSimple(16, 1, 8, 8);
            TestSpeedSimple(16, 1, 4, 4);
            TestSpeedSimple(16, 1, 2, 2);

            TestSpeedSimple(32, 1);
            TestSpeedSimple(32, 1, 16, 16);
            TestSpeedSimple(32, 1, 8, 8);
            TestSpeedSimple(32, 1, 4, 4);
            TestSpeedSimple(32, 1, 2, 2);

            TestSpeedSimple(64, 1);
            TestSpeedSimple(64, 1, 32, 32);
            TestSpeedSimple(64, 1, 16, 16);
            TestSpeedSimple(64, 1, 8, 8);
            TestSpeedSimple(64, 1, 4, 4);
            TestSpeedSimple(64, 1, 2, 2);

            TestSpeedSimple(128, 1);
            TestSpeedSimple(128, 1, 64, 64);
            TestSpeedSimple(128, 1, 32, 32);
            TestSpeedSimple(128, 1, 16, 16);
            TestSpeedSimple(128, 1, 8, 8);
            TestSpeedSimple(128, 1, 4, 4);
            TestSpeedSimple(128, 1, 2, 2);

            TestSpeedSimple(256, 2);
            TestSpeedSimple(256, 1, 128, 128);
            TestSpeedSimple(256, 1, 64, 64);
            TestSpeedSimple(256, 1, 32, 32);
            TestSpeedSimple(256, 1, 16, 16);
            TestSpeedSimple(256, 1, 8, 8);
            TestSpeedSimple(256, 1, 4, 4);
            TestSpeedSimple(256, 1, 2, 2);

            TestSpeedSimple(512, 5);
            TestSpeedSimple(512, 2, 256, 256);
            TestSpeedSimple(512, 1, 128, 128);
            TestSpeedSimple(512, 1, 64, 64);
            TestSpeedSimple(512, 1, 32, 32);
            TestSpeedSimple(512, 1, 16, 16);
            TestSpeedSimple(512, 1, 8, 8);
            TestSpeedSimple(512, 1, 4, 4);
            TestSpeedSimple(512, 1, 2, 2);

            TestSpeedSimple(1024, 10);
            TestSpeedSimple(1024, 5, 512, 512);
            TestSpeedSimple(1024, 2, 256, 256);
            TestSpeedSimple(1024, 1, 128, 128);
            TestSpeedSimple(1024, 1, 64, 64);
            TestSpeedSimple(1024, 1, 32, 32);
            TestSpeedSimple(1024, 1, 16, 16);
            TestSpeedSimple(1024, 1, 8, 8);
            TestSpeedSimple(1024, 1, 4, 4);
            TestSpeedSimple(1024, 1, 2, 2);

            TestSpeedSimple(2048, 20);
            TestSpeedSimple(2048, 10, 1024, 1024);
            TestSpeedSimple(2048, 5, 512, 512);
            TestSpeedSimple(2048, 2, 256, 256);
            TestSpeedSimple(2048, 1, 128, 128);
            TestSpeedSimple(2048, 1, 64, 64);
            TestSpeedSimple(2048, 1, 32, 32);
            TestSpeedSimple(2048, 1, 16, 16);
            TestSpeedSimple(2048, 1, 8, 8);
            TestSpeedSimple(2048, 1, 4, 4);
            TestSpeedSimple(2048, 1, 2, 2);

            TestSpeedSimple(4096, 40);
            TestSpeedSimple(4096, 20, 2048, 2048);
            TestSpeedSimple(4096, 10, 1024, 1024);
            TestSpeedSimple(4096, 5, 512, 512);
            TestSpeedSimple(4096, 2, 256, 256);
            TestSpeedSimple(4096, 1, 128, 128);
            TestSpeedSimple(4096, 1, 64, 64);
            TestSpeedSimple(4096, 1, 32, 32);
            TestSpeedSimple(4096, 1, 16, 16);
            TestSpeedSimple(4096, 1, 8, 8);
            TestSpeedSimple(4096, 1, 4, 4);
            TestSpeedSimple(4096, 1, 2, 2);

            TestSpeedSimple(8192, 80);
            TestSpeedSimple(8192, 40, 4096, 4096);
            TestSpeedSimple(8192, 20, 2048, 2048);
            TestSpeedSimple(8192, 10, 1024, 1024);
            TestSpeedSimple(8192, 5, 512, 512);
            TestSpeedSimple(8192, 2, 256, 256);
            TestSpeedSimple(8192, 1, 128, 128);
            TestSpeedSimple(8192, 1, 64, 64);
            TestSpeedSimple(8192, 1, 32, 32);
            TestSpeedSimple(8192, 1, 16, 16);
            TestSpeedSimple(8192, 1, 8, 8);
            TestSpeedSimple(8192, 1, 4, 4);
            TestSpeedSimple(8192, 1, 2, 2);

            TestSpeedSimple(16384, 160);
            TestSpeedSimple(16384, 80, 8192, 8192);
            TestSpeedSimple(16384, 40, 4096, 4096);
            TestSpeedSimple(16384, 20, 2048, 2048);
            TestSpeedSimple(16384, 10, 1024, 1024);
            TestSpeedSimple(16384, 5, 512, 512);
            TestSpeedSimple(16384, 2, 256, 256);
            TestSpeedSimple(16384, 1, 128, 128);
            TestSpeedSimple(16384, 1, 64, 64);
            TestSpeedSimple(16384, 1, 32, 32);
            TestSpeedSimple(16384, 1, 16, 16);
            TestSpeedSimple(16384, 1, 8, 8);
            TestSpeedSimple(16384, 1, 4, 4);
            TestSpeedSimple(16384, 1, 2, 2);

            TestSpeedSimple(32768, 420);
            TestSpeedSimple(32768, 160, 16384, 16384);
            TestSpeedSimple(32768, 80, 8192, 8192);
            TestSpeedSimple(32768, 40, 4096, 4096);
            TestSpeedSimple(32768, 20, 2048, 2048);
            TestSpeedSimple(32768, 10, 1024, 1024);
            TestSpeedSimple(32768, 5, 512, 512);
            TestSpeedSimple(32768, 2, 256, 256);
            TestSpeedSimple(32768, 1, 128, 128);
            TestSpeedSimple(32768, 1, 64, 64);
            TestSpeedSimple(32768, 1, 32, 32);
            TestSpeedSimple(32768, 1, 16, 16);
            TestSpeedSimple(32768, 1, 8, 8);
            TestSpeedSimple(32768, 1, 4, 4);
            TestSpeedSimple(32768, 1, 2, 2);
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

        #region Test Speed Simple
        private static void TestSpeedSimple(ushort mapSize, int failTimeMillis)
        {
            Profile pManaged;
            Profile pNative;

            //dummy run
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));
            //result run
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));

            //dummy run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1),
                                                pathType: GridPathType.Normal, layout: null, enviromentType: EnviromentType.Native);
            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1),
                                                pathType: GridPathType.Normal, layout: null, enviromentType: EnviromentType.Native);


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Map :             " + mapSize + "x" + mapSize);
            Console.WriteLine("MapCreationTime : ~" + pManaged.MapCreationTime + "MS");
            Console.WriteLine("StartPos :        " + "[0, 0]");
            Console.WriteLine("TargetPos :       " + "[" + (mapSize - 1).ToString() + ", " + (mapSize - 1).ToString() +"]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enviroment :      " + "Managed");
            Console.WriteLine("PathLength :      " + pManaged.PathLength);
            if (pManaged.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + pManaged.PathRunTimeTicks + " Ticks");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enviroment :      " + "Native");
            Console.WriteLine("PathLength :      " + pNative.PathLength);
            if (pNative.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + pNative.PathRunTimeTicks + " Ticks");
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (pManaged.PathRunTimeTicks > pNative.PathRunTimeTicks)
            {
                Console.WriteLine("Winner :          Native");
            }
            else if (pManaged.PathRunTimeTicks < pNative.PathRunTimeTicks)
            {
                Console.WriteLine("Winner :          Managed");
            }
            else
            {
                Console.WriteLine("Winner :          Inconclusive");
            }
            Console.WriteLine();
        }
        private static void TestSpeedSimple(ushort mapSize, int failTimeMillis, ushort targetX, ushort targetY)
        {
            Profile pManaged;
            Profile pNative;

            //dummy run
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY);
            //result run
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY);

            //dummy run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY, pathType: GridPathType.Normal, layout: null,
                                                enviromentType: EnviromentType.Native);
            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY, pathType: GridPathType.Normal, layout: null,
                                                enviromentType: EnviromentType.Native);


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Map :             " + mapSize + "x" + mapSize);
            Console.WriteLine("MapCreationTime : ~" + pManaged.MapCreationTime + "MS");
            Console.WriteLine("StartPos :        " + "[0, 0]");
            Console.WriteLine("TargetPos :       " + "[" + targetX + ", " + targetY + "]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enviroment :      " + "Managed");
            Console.WriteLine("PathLength :      " + pManaged.PathLength);
            if (pManaged.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + pManaged.PathRunTimeTicks + " Ticks");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enviroment :      " + "Native");
            Console.WriteLine("PathLength :      " + pNative.PathLength);
            if (pNative.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + pNative.PathRunTimeTicks + " Ticks");
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (pManaged.PathRunTimeTicks > pNative.PathRunTimeTicks)
            {
                Console.WriteLine("Winner :          Native");
            }
            else if (pManaged.PathRunTimeTicks < pNative.PathRunTimeTicks)
            {
                Console.WriteLine("Winner :          Managed");
            }
            else
            {
                Console.WriteLine("Winner :          Inconclusive");
            }
            Console.WriteLine();
        }
        #endregion

        #region Test Speed Random
        private static void TestSpeedRandom(ushort mapSize, int failTimeMillis, byte blockFrequency)
        {
            Profile pManaged;
            Profile pNative;

            //dummy run
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));
            //result run
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: true, blockFrequency: blockFrequency, resistanceCap: 127,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));

            //dummy run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1),
                                                pathType: GridPathType.Normal, layout: null, enviromentType: EnviromentType.Native);
            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: true, blockFrequency: blockFrequency, resistanceCap: 127,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1),
                                                pathType: GridPathType.Normal, layout: null, enviromentType: EnviromentType.Native);


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Map :             " + mapSize + "x" + mapSize);
            Console.WriteLine("MapCreationTime : ~" + pManaged.MapCreationTime + "MS");
            Console.WriteLine("StartPos :        " + "[0, 0]");
            Console.WriteLine("TargetPos :       " + "[" + (mapSize - 1).ToString() + ", " + (mapSize - 1).ToString() + "]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enviroment :      " + "Managed");
            Console.WriteLine("PathLength :      " + pManaged.PathLength);
            if (pManaged.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + pManaged.PathRunTimeTicks + " Ticks");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enviroment :      " + "Native");
            Console.WriteLine("PathLength :      " + pNative.PathLength);
            if (pNative.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + pNative.PathRunTimeTicks + " Ticks");
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (pManaged.PathRunTimeTicks > pNative.PathRunTimeTicks)
            {
                Console.WriteLine("Winner :          Native");
            }
            else if (pManaged.PathRunTimeTicks < pNative.PathRunTimeTicks)
            {
                Console.WriteLine("Winner :          Managed");
            }
            else
            {
                Console.WriteLine("Winner :          Inconclusive");
            }
            Console.WriteLine();
        }
        private static void TestSpeedRandom(ushort mapSize, int failTimeMillis, ushort targetX, ushort targetY, byte blockFrequency)
        {
            Profile pManaged;
            Profile pNative;

            //dummy run
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY);
            //result run
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: true, blockFrequency: blockFrequency, resistanceCap: 127,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY);

            //dummy run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY, pathType: GridPathType.Normal, layout: null,
                                                enviromentType: EnviromentType.Native);
            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: true, blockFrequency: blockFrequency, resistanceCap: 127,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: targetX, targetY: targetY, pathType: GridPathType.Normal, layout: null,
                                                enviromentType: EnviromentType.Native);


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Map :             " + mapSize + "x" + mapSize);
            Console.WriteLine("MapCreationTime : ~" + pManaged.MapCreationTime + "MS");
            Console.WriteLine("StartPos :        " + "[0, 0]");
            Console.WriteLine("TargetPos :       " + "[" + targetX + ", " + targetY + "]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enviroment :      " + "Managed");
            Console.WriteLine("PathLength :      " + pManaged.PathLength);
            if (pManaged.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + pManaged.PathRunTimeTicks + " Ticks");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enviroment :      " + "Native");
            Console.WriteLine("PathLength :      " + pNative.PathLength);
            if (pNative.PathRunTime > failTimeMillis)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PathRuntime :     " + pNative.PathRunTimeTicks + " Ticks");
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (pManaged.PathRunTimeTicks > pNative.PathRunTimeTicks)
            {
                Console.WriteLine("Winner :          Native");
            }
            else if (pManaged.PathRunTimeTicks < pNative.PathRunTimeTicks)
            {
                Console.WriteLine("Winner :          Managed");
            }
            else
            {
                Console.WriteLine("Winner :          Inconclusive");
            }
            Console.WriteLine();
        }
        #endregion
    }
}
