namespace AoC.Solver;

public class Solvers
{
    public class Day1Solution
    {
        public void Run(string input, bool debug)
        {
            var solver = new Day1();
            var solution = solver.Solve(input, debug);
            Console.WriteLine("Result "+solution);
        }

        public void Run2(string input, bool debug)
        {
            var solver = new Day1();
            var solution = solver.Solve2(input, debug);
            Console.WriteLine("Result "+solution);
        }
    }
}