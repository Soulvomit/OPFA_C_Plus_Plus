using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opfa_common_managed;

namespace opfa_common_test
{
    [TestClass]
    public class PathConsistencyTest
    {
        [TestMethod]
        public void Map2x2_ConsistencyTest()
        {
            TestConsistency(2, 1);
        }
        [TestMethod]
        public void Map4x4_ConsistencyTest()
        {
            TestConsistency(4, 1);
        }
        [TestMethod]
        public void Map8x8_ConsistencyTest()
        {
            TestConsistency(8, 1);
        }
        [TestMethod]
        public void Map16x16_ConsistencyTest()
        {
            TestConsistency(16, 1);
        }
        [TestMethod]
        public void Map32x32_ConsistencyTest()
        {
            TestConsistency(32, 1);
        }
        [TestMethod]
        public void Map64x64_ConsistencyTest()
        {
            TestConsistency(64, 1);
        }
        [TestMethod]
        public void Map128x128_ConsistencyTest()
        {
            TestConsistency(128, 1);
        }
        [TestMethod]
        public void Map256x256_ConsistencyTest()
        {
            TestConsistency(256, 2);
        }
        [TestMethod]
        public void Map512x512_ConsistencyTest()
        {
            TestConsistency(512, 5);
        }
        [TestMethod]
        public void Map1024x1024_ConsistencyTest()
        {
            TestConsistency(1024, 10);
        }
        [TestMethod]
        public void Map2048x2048_ConsistencyTest()
        {
            TestConsistency(2048, 20);
        }
        [TestMethod]
        public void Map4096x4096_ConsistencyTest()
        {
            TestConsistency(4096, 40);
        }
        [TestMethod]
        public void Map8192x8192_ConsistencyTest()
        {
            TestConsistency(8192, 80);
        }
        [TestMethod]
        public void Map16384x16384_ConsistencyTest()
        {
            TestConsistency(16384, 160);
        }
        private void TestConsistency(ushort mapSize, int failTimeMillis)
        {
            Profile p;

            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));

            //assert that pathfinding length is equal to expected length
            Assert.AreEqual(mapSize - 1, p.PathLength);
        }
    }
}
