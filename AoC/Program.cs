// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Dynamic;
using System.Reflection;
using AoC.Solver;

namespace AoC;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.Error.WriteLine("Please select an exercise to solve");
            return;
        }

        var arguments = args.ToList();
        var toSolve = arguments[0];
        var debug = arguments.Contains("-d");
        var testingInput = arguments.Contains("-t");
        var part = 1;
        
        if (args.Length > 1 && int.TryParse(args[1], out var partId))
        {
            if (partId is < 1 or > 2)
            {
                Console.Error.WriteLine("The exercise part is invalid");
            }
            else
            {
                part = partId;
            }
        }
        
        if (int.TryParse(toSolve, out var result) && result is > 0 and < 25)
        {
            var input = GetInput(result, testingInput);
            var solutionInstance = CreateInstance(toSolve);
            object[] parameters = [input, debug];
            var methodName = part == 1 ? "Run" : "Run2";
            
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            solutionInstance?.GetType().GetMethod(methodName)?.Invoke(solutionInstance, parameters);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
        }
        else
        {
            Console.Error.WriteLine("Argument must be a number between 1 and 24");
            return;
        }
    }
    
    private static object? CreateInstance(string number)
    {
        var type = Type.GetType($"AoC.Solver.Solvers+Day{number}Solution");

        if (type == null)
        {
            Console.WriteLine($"Class AoC.Solver.Solvers+Day{number}Solution.");
            return null;
        }

        return Activator.CreateInstance(type);
    }

    private static string GetInput(int day, bool testingInput)
    {
        var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        var inputPath = testingInput ? Path.Combine(directory, "Input", "test",$"day{day}.txt") : Path.Combine(directory, "Input", $"day{day}.txt");
        if (!File.Exists(inputPath))
        { 
            Console.Error.WriteLine($"Could not find file at {inputPath}");
        }
        return File.ReadAllText(inputPath);
    }
}