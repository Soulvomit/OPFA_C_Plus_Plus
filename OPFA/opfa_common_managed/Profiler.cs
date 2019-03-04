using System;
using System.Diagnostics;

namespace opfa_common_managed
{
    public struct Profile
    {
        public long MapCreationTime;
        public long PathRunTime;
        public int PathLength;
    }
    public static class Profiler
    {
        #region ProfileCubic
        public static uint[,] ProfileCubic(out Profile profile, bool onThread, bool random, byte blockFrequency, byte resistanceCap, 
            ushort cubeSize = 1000, uint outBufferSize = 10000, ushort startX = 0, ushort startY = 0, ushort startZ = 0,
            ushort targetX = 999, ushort targetY = 999, ushort targetZ = 999)
        {
            //init cube data (MAX SIZE: 1280x1280x1280)
            CubicLayout gl = new CubicLayout(cubeSize, cubeSize, cubeSize);
            //profile cube creation
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (random)
            {
                gl.GenerateRandomLayout(blockFrequency, resistanceCap);
            }
            else
            {
                gl.GenerateEmptyLayout();
            }
            sw.Stop();

            CubicMemory gm = new CubicMemory(outBufferSize, gl);
            gm.StartPosition = new ushort[3] { startX, startY, startZ };
            gm.TargetPosition = new ushort[3] { targetX, targetY, targetZ };
            gl.inbuffer[gm.StartPosition[0], gm.StartPosition[1], gm.StartPosition[2]] = 1;
            gl.inbuffer[gm.TargetPosition[0], gm.TargetPosition[1], gm.TargetPosition[2]] = 1;
            //profile cube path
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            if (onThread)
            {
                gm.RunThreadedOnce();
                gm.JoinThreadedOnce();
            }
            else
            {
                gm.RunOnce();
            }
            sw1.Stop();
            //save info to profile
            profile = new Profile();
            profile.MapCreationTime = sw.ElapsedMilliseconds;
            profile.PathRunTime = sw1.ElapsedMilliseconds;
            profile.PathLength = gm.PathLength;
            return gm.Path;
            //show time and length
            /*Console.WriteLine("TIME:   " + sw.ElapsedMilliseconds + "MS");
            Console.WriteLine("LENGTH: " + gm.PathLength);
            //draw cube path
            if (gm.PathLength > 0)
            {
                uint[,] path = gm.Path;
                for (int i = 0; i < gm.PathLength; i++)
                {
                    Console.Write("{" + path[i, 0] + "," + path[i, 1] + "," + path[i, 2] + "} ");
                }
            }
            Console.ReadKey();*/
        }
        #endregion

        #region ProfileGrid
        public static uint[,] ProfileGrid(out Profile profile, bool onThread, bool random, byte blockFrequency, byte resistanceCap, 
            ushort gridSize = 30000, uint outBufferSize = 300000, ushort startX = 0, ushort startY = 0, 
            ushort targetX = 29999, ushort targetY = 29999)
        {
            //init grid data (MAX SIZE: 46340x46340)
            GridLayout gl = new GridLayout(gridSize, gridSize);
            //profile grid creation
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (random)
            {
                gl.GenerateRandomLayout(blockFrequency, resistanceCap);
            }
            else
            {
                gl.GenerateEmptyLayout();
            }
            sw.Stop();
            GridMemory gm = new GridMemory(outBufferSize, gl);
            gm.StartPosition = new ushort[2] { startX, startY };
            gm.TargetPosition = new ushort[2] { targetX, targetY };
            gl.inbuffer[gm.StartPosition[0], gm.StartPosition[1]] = 1;
            gl.inbuffer[gm.TargetPosition[0], gm.TargetPosition[1]] = 1;
            //profile grid path
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            if (onThread)
            {
                gm.RunThreadedOnce();
                gm.JoinThreadedOnce();
            }
            else
            {
                gm.RunOnce();
            }
            sw1.Stop();
            //save info to profile
            profile = new Profile();
            profile.MapCreationTime = sw.ElapsedMilliseconds;
            profile.PathRunTime = sw1.ElapsedMilliseconds;
            profile.PathLength = gm.PathLength;
            return gm.Path;
            //show time and length
            /*Console.WriteLine("MAPTIME:    " + sw.ElapsedMilliseconds + "MS");
            Console.WriteLine("PATHTIME:   " + sw1.ElapsedMilliseconds + "MS");
            Console.WriteLine("LENGTH:     " + gm.PathLength);
            Console.ReadKey();*/
        }
        #endregion

        #region ProfileGridRun
        public static void ProfileGridRun(byte blockFrequency, byte resistanceCap, bool random = true)
        {
            //init grid and memory pathfinder
            GridLayout gl = new GridLayout(40, 40);
            if (random)
            {
                gl.GenerateRandomLayout(blockFrequency, resistanceCap);
            }
            else
            {
                gl.GenerateBlockRandomLayout(blockFrequency);
            }
            GridMemory gm = new GridMemory(1600, gl);
            gm.StartPosition = new ushort[2] { 0, 0 };
            gm.TargetPosition = new ushort[2] { 39, 39 };
            gl.inbuffer[gm.StartPosition[0], gm.StartPosition[1]] = 1;
            gl.inbuffer[gm.TargetPosition[0], gm.TargetPosition[1]] = 1;
            //run memory pathfinder
            gm.Run();
            string cmd = null;
            while (cmd != "-q")
            {
                
                Console.Write("command: ");
                cmd = Console.ReadLine();
                Console.Clear();

                if (cmd == "-p" || cmd == "-pause")
                {
                    Console.WriteLine("Pathfinding paused...");
                    gm.Pause();
                }
                else if (cmd == "-r" || cmd == "-resume")
                {
                    Console.WriteLine("Pathfinding resumed...");
                    gm.Resume();
                }
                else if (cmd.StartsWith("-spos"))
                {
                    var s = cmd.Split(' ');
                    ushort x = 0;
                    UInt16.TryParse(s[1], out x);
                    ushort y = 0;
                    UInt16.TryParse(s[2], out y);
                    gm.StartPosition = new ushort[] { x, y };
                    DrawGrid(null, gm, gl);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (cmd.StartsWith("-tpos"))
                {
                    var s = cmd.Split(' ');
                    ushort x = 0;
                    UInt16.TryParse(s[1], out x);
                    ushort y = 0;
                    UInt16.TryParse(s[2], out y);
                    gm.TargetPosition = new ushort[] { x, y };
                    DrawGrid(null, gm, gl);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (cmd == "-t" || cmd == "-path")
                {
                    Console.WriteLine("LENGTH: " + gm.PathLength);
                    var path = gm.Path;
                    for (int i = 0; i < gm.PathLength; i++)
                    {
                        Console.Write("{" + path[i, 0] + "," + path[i, 1] + "} ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (cmd == "-c" || cmd == "-profile")
                {
                    PerformanceCounter cpuCounter = new PerformanceCounter();
                    cpuCounter.CategoryName = "Processor";
                    cpuCounter.CounterName = "% Processor Time";
                    cpuCounter.InstanceName = "_Total";
                    PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

                    float unused = cpuCounter.NextValue(); // first call will always return 0
                    System.Threading.Thread.Sleep(100); // wait a second, then try again
                    Console.WriteLine("Pathfinder CPU usage: " + cpuCounter.NextValue() + "%");
                    Console.WriteLine("Free Memory: " + ramCounter.NextValue() + "MB");
                }
                else if (cmd == "-d" || cmd == "-draw")
                {
                    DrawGrid(null, gm, gl);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (cmd == "-h" || cmd == "-help")
                {
                    Console.WriteLine("-h, -help: shows help");
                    Console.WriteLine("-p, -pause: pauses pathfinder");
                    Console.WriteLine("-r, -resume: resumes pathfinder");
                    Console.WriteLine("-t, -path: prints the current path");
                    Console.WriteLine("-d, -draw: draws the grid");
                    Console.WriteLine("-c, -profile: show system resource usage");
                    Console.WriteLine("-q, -quit: quits");
                    Console.WriteLine("-spos [x] [y]: moves the starting position");
                    Console.WriteLine("-tpos [x] [y]: moves the target position");
                    Console.WriteLine();
                }
            }
            gm.Stop();
        }
        #endregion

        #region DrawGrid
        private static void DrawGrid(Stopwatch sw, GridMemory gm, GridLayout gl)
        {
            if (sw != null)
            {
                Console.WriteLine("TIME:   " + sw.ElapsedMilliseconds + "MS");
                Console.WriteLine("LENGTH: " + gm.PathLength);
            }
            bool append = false;
            if (gm.PathLength > 0 && gm.PathLength < 100)
            {
                uint[,] path = gm.Path;
                for (uint y = 0; y < gl.Height; y++)
                {
                    for (uint x = 0; x < gl.Width; x++)
                    {
                        byte resistance = gl.inbuffer[x, y];
                        if (resistance < 10)
                        {
                            append = true;
                        }
                        else
                        {
                            append = false;
                        }
                        uint[] step = { x, y };

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;

                        if (resistance == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        for (uint i = 0; i < path.GetLength(0); i++)
                        {
                            if (x == path[i, 0] && y == path[i, 1])
                            {
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                        }
                        if (x == gm.StartPosition[0] && y == gm.StartPosition[1])
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (x == gm.TargetPosition[0] && y == gm.TargetPosition[1])
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (append)
                        {
                            Console.Write("0" + resistance + " ");
                        }
                        else
                        {
                            Console.Write(resistance + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else if (gm.PathLength < 100)
            {
                for (uint y = 0; y < gl.Height; y++)
                {
                    for (uint x = 0; x < gl.Width; x++)
                    {
                        byte resistance = gl.inbuffer[x, y];
                        if (resistance < 10)
                        {
                            append = true;
                        }
                        else
                        {
                            append = false;
                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        if (resistance == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        if (x == gm.StartPosition[0] && y == gm.StartPosition[1])
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (x == gm.TargetPosition[0] && y == gm.TargetPosition[1])
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (append)
                        {
                            Console.Write("0" + resistance + " ");
                        }
                        else
                        {
                            Console.Write(resistance + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
        #endregion


    }
}
