using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opfa_common_managed;

namespace opfa_common_test
{
    [TestClass]
    public class PathConsistencyTest
    {
        //if a path ever takes longer then time out fail, we can assume that the pathfinding-
        //algoritm is stuck in some kind of endless iteraton
        private int timeOutFail = 3000;
        //frequency of blocked nodes on grid (5 means every 5th node is a blocked node)
        private byte blockFrequency = 5;
        [TestMethod]
        public void StaticConsistencyTest()
        {
            TestStaticConsistency();
            TestStaticConsistency1();
            TestStaticConsistency2();
            TestStaticConsistency3();
            TestStaticConsistency4();
            TestStaticConsistency5();
        }
        [TestMethod]
        public void Map2x2_ConsistencyTest()
        {
            TestSimpleConsistency(2);
            TestRandomConsistency(2, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map4x4_ConsistencyTest()
        {
            TestSimpleConsistency(4);
            TestRandomConsistency(4, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map8x8_ConsistencyTest()
        {
            TestSimpleConsistency(8);
            TestRandomConsistency(8, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map16x16_ConsistencyTest()
        {
            TestSimpleConsistency(16);
            TestRandomConsistency(16, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map32x32_ConsistencyTest()
        {
            TestSimpleConsistency(32);
            TestRandomConsistency(32, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map64x64_ConsistencyTest()
        {
            TestSimpleConsistency(64);
            TestRandomConsistency(64, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map128x128_ConsistencyTest()
        {
            TestSimpleConsistency(128);
            TestRandomConsistency(128, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map256x256_ConsistencyTest()
        {
            TestSimpleConsistency(256);
            TestRandomConsistency(256, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map512x512_ConsistencyTest()
        {
            TestSimpleConsistency(512);
            TestRandomConsistency(512, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map1024x1024_ConsistencyTest()
        {
            TestSimpleConsistency(1024);
            TestRandomConsistency(1024, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map2048x2048_ConsistencyTest()
        {
            TestSimpleConsistency(2048);
            TestRandomConsistency(2048, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map4096x4096_ConsistencyTest()
        {
            TestSimpleConsistency(4096);
            TestRandomConsistency(4096, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map8192x8192_ConsistencyTest()
        {
            TestSimpleConsistency(8192);
            TestRandomConsistency(8192, timeOutFail, blockFrequency);
        }
        [TestMethod]
        public void Map16384x16384_ConsistencyTest()
        {
            TestSimpleConsistency(16384);
            TestRandomConsistency(16384, timeOutFail, blockFrequency);
        }

        #region Simple Consistency Test
        /// <summary>
        /// Tests the pathfinding algorithm on a simple empty map. Expected path length is always map size - 1.
        /// </summary>
        /// <param name="mapSize">Size of the quardratic map to test on.</param>
        private void TestSimpleConsistency(ushort mapSize)
        {
            Profile p;

            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));

            //assert that pathfinding length is equal to expected length
            Assert.AreEqual(mapSize - 1, p.PathLength);
        }
        #endregion

        #region Random Consistency Test
        /// <summary>
        /// Tests the pathfinding algorithm on a random map. Expected result is a pathlengt that is not 0.
        /// </summary>
        /// <param name="mapSize">Size of the quardratic map to test on.</param>
        /// <param name="timeOutFail">If the algorithm takes longer then time out fail, something is wrong.</param>
        /// <param name="blockFrequence">How often the algorithm will encounter a blocked node.</param>
        private void TestRandomConsistency(ushort mapSize, int timeOutFail, byte blockFrequence)
        {
            Profile p;

            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: true, blockFrequency: blockFrequence, resistanceCap: 127,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));

            //assert that pathfinding did not take too long (longer then time out fail)
            Assert.IsTrue(p.PathRunTime < timeOutFail);
            //assert that pathfinding length is not 0 (-1 is a valid result, which means no path could be found)
            Assert.IsTrue(p.PathLength != 0);
        }
        #endregion

        #region Static Consistency Tests
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path. 
        /// </summary>
        private void TestStaticConsistency()
        {
            Profile p;
            uint[,] expectedPath = {
                { 0,1}, { 0,2}, { 0,3}, { 0,4}, { 0,5}, { 0,6}, { 1,7}, { 2,7}, { 3,6}, { 3,5},
                { 3,4}, { 3,3}, { 3,2}, { 3,1}, { 4,0}, { 5,1}, { 6,1}, { 7,2}, { 7,3}, { 7,4},
                { 7,5}, { 7,6}, { 7,7}
            };
            byte[,] m8x8 = {
                            { 64, 00, 00, 64, 64, 64, 64, 64 },
                            { 64, 00, 00, 64, 00, 64, 64, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 00, 00, 64 },
                            { 64, 64, 64, 64, 00, 00, 00, 64 }
            };
        
            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.Normal, layout: m8x8);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, p.Path);
            //assert that pathfinding length is 23
            Assert.AreEqual(23, p.PathLength);
        }
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path. 
        /// </summary>
        private void TestStaticConsistency1()
        {
            Profile p;
            uint[,] expectedPath = {
                { 0,1}, { 1,2}, { 2,3}, { 3,4}, { 4,5}, { 5,5}, { 6,4}, { 7,5}, { 7,6}, { 7,7}
            };
            byte[,] m8x8 = {
                            { 64, 00, 00, 64, 64, 64, 64, 64 },
                            { 64, 00, 00, 64, 00, 64, 64, 64 },
                            { 64, 64, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 64, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 64, 64 },
                            { 64, 00, 00, 64, 64, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 00, 00, 64 },
                            { 64, 64, 64, 64, 00, 00, 00, 64 }
            };

            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.Normal, layout: m8x8);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, p.Path);
            //assert that pathfinding length is 10
            Assert.AreEqual(10, p.PathLength);
        }
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path. 
        /// </summary>
        private void TestStaticConsistency2()
        {
            Profile p;
            uint[,] expectedPath = {
                { 0,1}, { 0,2}, { 0,3}, { 0,4}, { 0,5}, { 0,6}, { 0,7}, { 1,7}, { 2,7}, { 3,7}, 
                { 3,6}, { 3,5}, { 3,4}, { 3,3}, { 3,2}, { 3,1}, { 3,0}, { 4,0}, { 5,0}, { 5,1}, 
                { 6,1}, { 7,1}, { 7,2}, { 7,3}, { 7,4}, { 7,5}, { 7,6}, { 7,7}
            };
            byte[,] m8x8 = {
                            { 64, 00, 00, 64, 64, 64, 64, 64 },
                            { 64, 00, 00, 64, 00, 64, 64, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 00, 00, 64 },
                            { 64, 64, 64, 64, 00, 00, 00, 64 }
            };

            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.NoDiagonals, layout: m8x8);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, p.Path);
            //assert that pathfinding length is 28
            Assert.AreEqual(28, p.PathLength);
        }
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path. 
        /// </summary>
        private void TestStaticConsistency3()
        {
            Profile p;
            uint[,] expectedPath = {
                { 0,1}, { 0,2}, { 0,3}, { 0,4}, { 0,5}, { 0,6}, { 0,7}, { 1,7}, { 2,7}, { 3,7},
                { 3,6}, { 3,5}, { 4,5}, { 5,5}, { 5,4}, { 6,4}, { 7,4}, { 7,5}, { 7,6}, { 7,7}
            };
            byte[,] m8x8 = {
                            { 64, 00, 00, 64, 64, 64, 64, 64 },
                            { 64, 00, 00, 64, 00, 64, 64, 64 },
                            { 64, 64, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 64, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 64, 64 },
                            { 64, 00, 00, 64, 64, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 00, 00, 64 },
                            { 64, 64, 64, 64, 00, 00, 00, 64 }
            };

            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.NoDiagonals, layout: m8x8);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, p.Path);
            //assert that pathfinding length is 10
            Assert.AreEqual(20, p.PathLength);
        }
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path. 
        /// </summary>
        private void TestStaticConsistency4()
        {
            Profile p;
            uint[,] expectedPath = {
                { 0,1}, { 0,2}, { 0,3}, { 0,4}, { 0,5}, { 0,6}, { 1,7}, { 2,7}, { 3,6}, { 3,5},
                { 3,4}, { 3,3}, { 3,2}, { 3,1}, { 4,0}, { 5,1}, { 6,1}, { 7,2}, { 7,3}, { 7,4},
                { 7,5}, { 7,6}, { 7,7}
            };
            byte[,] m8x8 = {
                            { 64, 00, 00, 64, 64, 64, 64, 64 },
                            { 64, 00, 00, 64, 00, 64, 64, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 00, 00, 64 },
                            { 64, 64, 64, 64, 00, 00, 00, 64 }
            };

            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.WeightedDiagonals, layout: m8x8);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, p.Path);
            //assert that pathfinding length is 23
            Assert.AreEqual(23, p.PathLength);
        }
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path. 
        /// </summary>
        private void TestStaticConsistency5()
        {
            Profile p;
            uint[,] expectedPath = {
                { 0,1}, { 1,2}, { 2,3}, { 3,4}, { 4,5}, { 5,5}, { 6,4}, { 7,5}, { 7,6}, { 7,7}
            };
            byte[,] m8x8 = {
                            { 64, 00, 00, 64, 64, 64, 64, 64 },
                            { 64, 00, 00, 64, 00, 64, 64, 64 },
                            { 64, 64, 00, 64, 00, 64, 00, 64 },
                            { 64, 00, 64, 64, 00, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 64, 64, 64 },
                            { 64, 00, 00, 64, 64, 64, 00, 64 },
                            { 64, 00, 00, 64, 00, 00, 00, 64 },
                            { 64, 64, 64, 64, 00, 00, 00, 64 }
            };

            //result run
            Profiler.ProfileGrid(profile: out p, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.WeightedDiagonals, layout: m8x8);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, p.Path);
            //assert that pathfinding length is 10
            Assert.AreEqual(10, p.PathLength);
        }
        #endregion
    }
}
