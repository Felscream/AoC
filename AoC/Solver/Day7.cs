using System.Data.SqlTypes;

namespace AoC.Solver;

public class Day7 : ISolver<ulong>
{
    public ulong Solve(string input, bool debug)
    {
        var equations = ParseInput(input);
        ulong total = 0;
        foreach (var equation in equations)
        {
            var res = SolveOperators(equation.Key, equation.Value, 1, equation.Value[0]);
            if (debug)
            {
                Console.WriteLine("{0} = {1} {2}", equation.Key, string.Join(", ", equation.Value), res ? "OK" : "KO");
            }

            if (res)
            {
                total += equation.Key;
            }
        }

        return total;
    }

    public ulong Solve2(string input, bool debug)
    {
        var equations = ParseInput(input);
        ulong total = 0;
        foreach (var equation in equations)
        {
            var res = SolveOperators2(equation.Key, equation.Value, 1, equation.Value[0]);
            if (debug)
            {
                Console.WriteLine("{0} = {1} {2}", equation.Key, string.Join(", ", equation.Value), res ? "OK" : "KO");
            }

            if (res)
            {
                total += equation.Key;
            }
        }

        return total;
    }

    private static bool SolveOperators(ulong target, List<ulong> values, int indexToAdd, ulong curValue)
    {
        if (indexToAdd >= values.Count)
        {
            return curValue == target;
        }
        var addition = curValue + values[indexToAdd];
        var multiplication = curValue * values[indexToAdd];
    
        return SolveOperators(target,values,indexToAdd + 1, addition) 
               || SolveOperators(target, values, indexToAdd + 1, multiplication);
    }
    
    private static bool SolveOperators2(ulong target, List<ulong> values, int indexToAdd, ulong curValue)
    {
        if (indexToAdd >= values.Count)
        {
            return curValue == target;
        }
        var addition = curValue + values[indexToAdd];
        var multiplication = curValue * values[indexToAdd];
        var combination = curValue * (10 * ((ulong)Math.Log10(values[indexToAdd]) + 1)) + values[indexToAdd];
    
        return SolveOperators2(target,values,indexToAdd + 1, addition) 
               || SolveOperators2(target, values, indexToAdd + 1, multiplication)
               || SolveOperators2(target, values, indexToAdd + 1, combination);
    }

    private static List<KeyValuePair<ulong, List<ulong>>> ParseInput(string input)
    {
        var inp = new List<KeyValuePair<ulong, List<ulong>>>();
        var rows = input.Split(Environment.NewLine);
        foreach (var row in rows)
        {
            var parts = row.Split(':');
            var target = ulong.Parse(parts[0]);
            var numbers = parts[1].Trim().Split(" ").Select(ulong.Parse).ToList();
            inp.Add(new KeyValuePair<ulong, List<ulong>>(target, numbers));
        }
        return inp;
    }
}