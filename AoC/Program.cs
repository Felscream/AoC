// See https://aka.ms/new-console-template for more information

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
        if (args.Length > 1 && bool.TryParse(args[1], out var withDebug))
        {
            debug = withDebug;
        }
        if (int.TryParse(toSolve, out var result) && result is > 0 and < 25)
        {
            switch (result)
            {
                case 1:
                    var solver = new Day1();
                    break;
                default:
                    Console.Error.WriteLine("Solution not implemented yet");
                    break;
            }
        }
        else
        {
            Console.Error.WriteLine("Argument must be a number between 1 and 24");
            return;
        }
    }
}