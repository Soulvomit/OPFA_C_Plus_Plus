using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opfa_common_managed;

namespace opfa_common_test
{
    [TestClass]
    public class PathSpeedTest
    {
        [TestMethod]
        public void Map2x2_SpeedTest()
        {
            TestSpeed(2, 1);
        }
        [TestMethod]
        public void Map4x4_SpeedTest()
        {
            TestSpeed(4, 1);
            TestSpeed(4, 1, 2, 2);
        }
        [TestMethod]
        public void Map8x8_SpeedTest()
        {
            TestSpeed(8, 1);
            TestSpeed(8, 1, 4, 4);
            TestSpeed(8, 1, 2, 2);
        }
        [TestMethod]
        public void Map16x16_SpeedTest()
        {
            TestSpeed(16, 1);
            TestSpeed(16, 1, 8, 8);
            TestSpeed(16, 1, 4, 4);
            TestSpeed(16, 1, 2, 2);
        }
        [TestMethod]
        public void Map32x32_SpeedTest()
        {
            TestSpeed(32, 1);
            TestSpeed(32, 1, 16, 16);
            TestSpeed(32, 1, 8, 8);
            TestSpeed(32, 1, 4, 4);
            TestSpeed(32, 1, 2, 2);
        }
        [TestMethod]
        public void Map64x64_SpeedTest()
        {
            TestSpeed(64, 1);
            TestSpeed(64, 1, 32, 32);
            TestSpeed(64, 1, 16, 16);
            TestSpeed(64, 1, 8, 8);
            TestSpeed(64, 1, 4, 4);
            TestSpeed(64, 1, 2, 2);
        }
        [TestMethod]
        public void Map128x128_SpeedTest()
        {
            TestSpeed(128, 1);
            TestSpeed(128, 1, 64, 64);
            TestSpeed(128, 1, 32, 32);
            TestSpeed(128, 1, 16, 16);
            TestSpeed(128, 1, 8, 8);
            TestSpeed(128, 1, 4, 4);
            TestSpeed(128, 1, 2, 2);
        }
        [TestMethod]
        public void Map256x256_SpeedTest()
        {
            TestSpeed(256, 2);
            TestSpeed(256, 1, 128, 128);
            TestSpeed(256, 1, 64, 64);
            TestSpeed(256, 1, 32, 32);
            TestSpeed(256, 1, 16, 16);
            TestSpeed(256, 1, 8, 8);
            TestSpeed(256, 1, 4, 4);
            TestSpeed(256, 1, 2, 2);
        }
        [TestMethod]
        public void Map512x512_SpeedTest()
        {
            TestSpeed(512, 5);
            TestSpeed(512, 2, 256, 256);
            TestSpeed(512, 1, 128, 128);
            TestSpeed(512, 1, 64, 64);
            TestSpeed(512, 1, 32, 32);
            TestSpeed(512, 1, 16, 16);
            TestSpeed(512, 1, 8, 8);
            TestSpeed(512, 1, 4, 4);
            TestSpeed(512, 1, 2, 2);
        }
        [TestMethod]
        public void Map1024x1024_SpeedTest()
        {
            TestSpeed(1024, 10);
            TestSpeed(1024, 5, 512, 512);
            TestSpeed(1024, 2, 256, 256);
            TestSpeed(1024, 1, 128, 128);
            TestSpeed(1024, 1, 64, 64);
            TestSpeed(1024, 1, 32, 32);
            TestSpeed(1024, 1, 16, 16);
            TestSpeed(1024, 1, 8, 8);
            TestSpeed(1024, 1, 4, 4);
            TestSpeed(1024, 1, 2, 2);
        }
        [TestMethod]
        public void Map2048x2048_SpeedTest()
        {
            TestSpeed(2048, 20);
            TestSpeed(2048, 10, 1024, 1024);
            TestSpeed(2048, 5, 512, 512);
            TestSpeed(2048, 2, 256, 256);
            TestSpeed(2048, 1, 128, 128);
            TestSpeed(2048, 1, 64, 64);
            TestSpeed(2048, 1, 32, 32);
            TestSpeed(2048, 1, 16, 16);
            TestSpeed(2048, 1, 8, 8);
            TestSpeed(2048, 1, 4, 4);
            TestSpeed(2048, 1, 2, 2);
        }
        [TestMethod]
        public void Map4096x4096_SpeedTest()
        {
            TestSpeed(4096, 40);
            TestSpeed(4096, 20, 2048, 2048);
            TestSpeed(4096, 10, 1024, 1024);
            TestSpeed(4096, 5, 512, 512);
            TestSpeed(4096, 2, 256, 256);
            TestSpeed(4096, 1, 128, 128);
            TestSpeed(4096, 1, 64, 64);
            TestSpeed(4096, 1, 32, 32);
            TestSpeed(4096, 1, 16, 16);
            TestSpeed(4096, 1, 8, 8);
            TestSpeed(4096, 1, 4, 4);
            TestSpeed(4096, 1, 2, 2);
        }
        [TestMethod]
        public void Map8192x8192_SpeedTest()
        {
            TestSpeed(8192, 80);
            TestSpeed(8192, 40, 4096, 4096);
            TestSpeed(8192, 20, 2048, 2048);
            TestSpeed(4096, 10, 1024, 1024);
            TestSpeed(8192, 5, 512, 512);
            TestSpeed(8192, 2, 256, 256);
            TestSpeed(8192, 1, 128, 128);
            TestSpeed(8192, 1, 64, 64);
            TestSpeed(8192, 1, 32, 32);
            TestSpeed(8192, 1, 16, 16);
            TestSpeed(8192, 1, 8, 8);
            TestSpeed(8192, 1, 4, 4);
            TestSpeed(8192, 1, 2, 2);
        }
        [TestMethod]
        public void Map16384x16384_SpeedTest()
        {
            TestSpeed(16384, 160);
        }
        private void TestSpeed(ushort mapSize, int failTimeMillis)
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

            //assert that pathfinding result run took less then or equal to fail time ms
            Assert.IsTrue(p.PathRunTime <= failTimeMillis, "" + p.PathRunTime);
        }
        private void TestSpeed(ushort mapSize, int failTimeMillis, ushort targetX, ushort targetY)
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

            //assert that pathfinding result run took less then or equal to fail time ms
            Assert.IsTrue(p.PathRunTime <= failTimeMillis, "" + p.PathRunTime);
        }
    }
}
