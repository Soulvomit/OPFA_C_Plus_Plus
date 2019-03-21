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
            TestStaticConsistencyNormal();
            TestStaticConsistencyNormal1();
            TestStaticConsistencyNoDiagonals();
            TestStaticConsistencyNoDiagonals1();
            TestStaticConsistencyWieghtedDiagonals();
            TestStaticConsistencyWieghtedDiagonals1();
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
            Profile pManaged;
            Profile pNative;
            //result run managed
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));
            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1),
                                                pathType: GridPathType.Normal, layout: null, enviromentType: EnviromentType.Native);
            //assert that pathfinding length is equal to expected length
            Assert.AreEqual(mapSize - 1, pManaged.PathLength);
            Assert.AreEqual(mapSize - 1, pNative.PathLength);
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
            Profile pManaged;
            Profile pNative;

            //result run
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: true, blockFrequency: blockFrequence, resistanceCap: 127,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1));

            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: mapSize, outBufferSize: (uint)(mapSize * 2), startX: 0, startY: 0,
                                                targetX: (ushort)(mapSize - 1), targetY: (ushort)(mapSize - 1),
                                                pathType: GridPathType.Normal, layout: null, enviromentType: EnviromentType.Native);

            //assert that pathfinding did not take too long (longer then time out fail)
            Assert.IsTrue(pManaged.PathRunTime < timeOutFail);
            Assert.IsTrue(pNative.PathRunTime < timeOutFail);
            //assert that pathfinding length is not 0 (-1 is a valid result, which means no path could be found)
            Assert.IsTrue(pManaged.PathLength != 0);
            Assert.IsTrue(pNative.PathLength != 0);
        }
        #endregion

        #region Static Consistency Tests
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path.
        /// Normal Pathfinding: daigonal and straight nodes are valued the same.
        /// </summary>
        private void TestStaticConsistencyNormal()
        {
            Profile pManaged;
            Profile pNative;
            uint[,] expectedPath = {
                { 1,0}, { 2,0}, { 3,0}, { 4,0}, { 5,0}, { 6,0}, { 7,1}, { 7,2}, { 6,3}, { 5,3},
                { 4,3}, { 3,3}, { 2,3}, { 1,3}, { 0,4}, { 1,5}, { 1,6}, { 2,7}, { 3,7}, { 4,7},
                { 5,7}, { 6,7}, { 7,7}
            };
            /*uint[,] expectedPath = {
                { 0,1}, { 0,2}, { 0,3}, { 0,4}, { 0,5}, { 0,6}, { 1,7}, { 2,7}, { 3,6}, { 3,5},
                { 3,4}, { 3,3}, { 3,2}, { 3,1}, { 4,0}, { 5,1}, { 6,1}, { 7,2}, { 7,3}, { 7,4},
                { 7,5}, { 7,6}, { 7,7}
            };*/
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
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.Normal, layout: m8x8);
            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0, targetX: 7, targetY: 7, 
                                                pathType: GridPathType.Normal, layout: m8x8, enviromentType: EnviromentType.Native);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, pManaged.Path);
            CollectionAssert.AreEqual(expectedPath, pNative.Path);
            //assert that pathfinding length is 23
            Assert.AreEqual(23, pManaged.PathLength);
            Assert.AreEqual(23, pNative.PathLength);
        }
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path.
        /// Normal Pathfinding: daigonal and straight nodes are valued the same.
        /// </summary>
        private void TestStaticConsistencyNormal1()
        {
            Profile pManaged;
            Profile pNative;

            uint[,] expectedPath = {
                { 1,0}, { 2,1}, { 3,2}, { 4,3}, { 5,4}, { 5,5}, { 4,6}, { 5,7}, { 6,7}, { 7,7}
            };
            /*uint[,] expectedPath = {
                { 0,1}, { 1,2}, { 2,3}, { 3,4}, { 4,5}, { 5,5}, { 6,4}, { 7,5}, { 7,6}, { 7,7}
            };*/
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
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.Normal, layout: m8x8);

            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0, targetX: 7, targetY: 7,
                                                pathType: GridPathType.Normal, layout: m8x8, enviromentType: EnviromentType.Native);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, pManaged.Path);
            CollectionAssert.AreEqual(expectedPath, pNative.Path);
            //assert that pathfinding length is 23
            Assert.AreEqual(10, pManaged.PathLength);
            Assert.AreEqual(10, pNative.PathLength);
        }
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path.
        /// No Diagonal Pathfinding: daigonal steps are excluded from the path.
        /// </summary>
        private void TestStaticConsistencyNoDiagonals()
        {
            Profile pManaged;
            Profile pNative;
            uint[,] expectedPath = {
                { 1,0}, { 2,0}, { 3,0}, { 4,0}, { 5,0}, { 6,0}, { 7,0}, { 7,1}, { 7,2}, { 7,3},
                { 6,3}, { 5,3}, { 4,3}, { 3,3}, { 2,3}, { 1,3}, { 0,3}, { 0,4}, { 0,5}, { 1,5},
                { 1,6}, { 1,7}, { 2,7}, { 3,7}, { 4,7}, { 5,7}, { 6,7}, { 7,7}
            /*uint[,] expectedPath = {
                { 0,1}, { 0,2}, { 0,3}, { 0,4}, { 0,5}, { 0,6}, { 0,7}, { 1,7}, { 2,7}, { 3,7}, 
                { 3,6}, { 3,5}, { 3,4}, { 3,3}, { 3,2}, { 3,1}, { 3,0}, { 4,0}, { 5,0}, { 5,1}, 
                { 6,1}, { 7,1}, { 7,2}, { 7,3}, { 7,4}, { 7,5}, { 7,6}, { 7,7}*/
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
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.NoDiagonals, layout: m8x8);

            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0, targetX: 7, targetY: 7,
                                                pathType: GridPathType.NoDiagonals, layout: m8x8, enviromentType: EnviromentType.Native);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, pManaged.Path);
            CollectionAssert.AreEqual(expectedPath, pNative.Path);
            //assert that pathfinding length is 23
            Assert.AreEqual(28, pManaged.PathLength);
            Assert.AreEqual(28, pNative.PathLength);
        }
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path.
        /// No Diagonal Pathfinding: daigonal steps are excluded from the path.
        /// </summary>
        private void TestStaticConsistencyNoDiagonals1()
        {
            Profile pManaged;
            Profile pNative;
            uint[,] expectedPath = {
                { 1,0}, { 2,0}, { 3,0}, { 4,0}, { 5,0}, { 6,0}, { 7,0}, { 7,1}, { 7,2}, { 7,3},
                { 6,3}, { 5,3}, { 5,4}, { 5,5}, { 4,5}, { 4,6}, { 4,7}, { 5,7}, { 6,7}, { 7,7}
            };
            /*uint[,] expectedPath = {
                { 0,1}, { 0,2}, { 0,3}, { 0,4}, { 0,5}, { 0,6}, { 0,7}, { 1,7}, { 2,7}, { 3,7},
                { 3,6}, { 3,5}, { 4,5}, { 5,5}, { 5,4}, { 6,4}, { 7,4}, { 7,5}, { 7,6}, { 7,7}
            };*/
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
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.NoDiagonals, layout: m8x8);

            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0, targetX: 7, targetY: 7,
                                                pathType: GridPathType.NoDiagonals, layout: m8x8, enviromentType: EnviromentType.Native);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, pManaged.Path);
            CollectionAssert.AreEqual(expectedPath, pNative.Path);
            //assert that pathfinding length is 23
            Assert.AreEqual(20, pManaged.PathLength);
            Assert.AreEqual(20, pNative.PathLength);
        }
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path. 
        /// Diagonal Weighted Pathfinding: daigonal steps are more costly then straight nodes (factored by diagonal modifier: 1.4).
        /// </summary>
        private void TestStaticConsistencyWieghtedDiagonals()
        {
            Profile pManaged;
            Profile pNative;
            uint[,] expectedPath = {
                { 1,0}, { 2,0}, { 3,0}, { 4,0}, { 5,0}, { 6,0}, { 7,1}, { 7,2}, { 6,3}, { 5,3},
                { 4,3}, { 3,3}, { 2,3}, { 1,3}, { 0,4}, { 1,5}, { 1,6}, { 2,7}, { 3,7}, { 4,7},
                { 5,7}, { 6,7}, { 7,7}
            };
             /*uint[,] expectedPath = {
                { 0,1}, { 0,2}, { 0,3}, { 0,4}, { 0,5}, { 0,6}, { 1,7}, { 2,7}, { 3,6}, { 3,5},
                { 3,4}, { 3,3}, { 3,2}, { 3,1}, { 4,0}, { 5,1}, { 6,1}, { 7,2}, { 7,3}, { 7,4},
                { 7,5}, { 7,6}, { 7,7}
            };*/
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
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.WeightedDiagonals, layout: m8x8);

            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0, targetX: 7, targetY: 7,
                                                pathType: GridPathType.WeightedDiagonals, layout: m8x8, enviromentType: EnviromentType.Native);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, pManaged.Path);
            CollectionAssert.AreEqual(expectedPath, pNative.Path);
            //assert that pathfinding length is 23
            Assert.AreEqual(23, pManaged.PathLength);
            Assert.AreEqual(23, pNative.PathLength);
        }
        /// <summary>
        /// Tests the algorithm on a static 8x8 map. Actual path must be excatly the same as expected path.
        /// Diagonal Weighted Pathfinding: daigonal steps are more costly then straight nodes (factored by diagonal modifier: 1.4).
        /// </summary>
        private void TestStaticConsistencyWieghtedDiagonals1()
        {
            Profile pManaged;
            Profile pNative;
            uint[,] expectedPath = {
                { 1,0}, { 2,1}, { 3,2}, { 4,3}, { 5,4}, { 5,5}, { 4,6}, { 5,7}, { 6,7}, { 7,7}
            };
            /*uint[,] expectedPath = {
                { 0,1}, { 1,2}, { 2,3}, { 3,4}, { 4,5}, { 5,5}, { 6,4}, { 7,5}, { 7,6}, { 7,7}
            };*/
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
            Profiler.ProfileGrid(profile: out pManaged, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0,
                                                targetX: 7, targetY: 7, pathType: GridPathType.WeightedDiagonals, layout: m8x8);
            //result run
            Profiler.ProfileGrid(profile: out pNative, onThread: false, random: false, blockFrequency: 255, resistanceCap: 255,
                                                gridSize: 8, outBufferSize: 30, startX: 0, startY: 0, targetX: 7, targetY: 7,
                                                pathType: GridPathType.WeightedDiagonals, layout: m8x8, enviromentType: EnviromentType.Native);

            //assert that pathfinding did not take too long (longer then time out fail)
            CollectionAssert.AreEqual(expectedPath, pManaged.Path);
            CollectionAssert.AreEqual(expectedPath, pNative.Path);
            //assert that pathfinding length is 23
            Assert.AreEqual(10, pManaged.PathLength);
            Assert.AreEqual(10, pNative.PathLength);
        }
        #endregion
    }
}
