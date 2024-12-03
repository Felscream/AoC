// See https://aka.ms/new-console-template for more information

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
        var toSolve = args[0];
        var debug = false;
        var testingInput = false;
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
        if (args.Length > 2 && bool.TryParse(args[2], out var withDebug))
        {
            debug = withDebug;
        }

        if (args.Length > 3 && bool.TryParse(args[3], out var withTesting))
        {
            testingInput = withTesting;
        }
        if (int.TryParse(toSolve, out var result) && result is > 0 and < 25)
        {
            var input = GetInput(result, testingInput);
            var solutionInstance = CreateInstance(toSolve);
            object[] parameters = [input, debug];
            var methodName = part == 1 ? "Run" : "Run2";
            
            solutionInstance?.GetType().GetMethod(methodName)?.Invoke(solutionInstance, parameters);
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