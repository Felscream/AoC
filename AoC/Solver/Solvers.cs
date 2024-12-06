using System.Diagnostics;

namespace AoC.Solver;

public class Solvers
{
    public class Day1Solution
    {
        public void Run(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day1();
            var solution = solver.Solve(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }

        public void Run2(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day1();
            var solution = solver.Solve2(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }
    }
    public class Day2Solution
    {
        public void Run(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day2();
            var solution = solver.Solve(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }

        public void Run2(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day2();
            var solution = solver.Solve2(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }
    }
    
    public class Day3Solution
    {
        public void Run(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day3();
            var solution = solver.Solve(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }

        public void Run2(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day3();
            var solution = solver.Solve2(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }
    }
    
    public class Day4Solution
    {
        public void Run(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day4();
            var solution = solver.Solve(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }

        public void Run2(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day4();
            var solution = solver.Solve2(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }
    }
    
    public class Day5Solution
    {
        public void Run(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day5();
            var solution = solver.Solve(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }

        public void Run2(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day5();
            var solution = solver.Solve2(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }
    }
    
    public class Day6Solution
    {
        public void Run(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day6();
            var solution = solver.Solve(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }

        public void Run2(string input, bool debug)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var solver = new Day6();
            var solution = solver.Solve2(input, debug);
            Console.WriteLine("Result "+solution);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }
    }
}