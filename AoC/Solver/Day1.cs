using System.Text.RegularExpressions;

namespace AoC.Solver;

public class Day1 : ISolver<long>
{
    public long Solve(string input, bool debug)
    {
        var lists = ParseInput(input);
        var l1 = lists[0];
        var l2 = lists[1];
        if (debug)
        {
            Console.WriteLine($"First list \n{string.Join(", ",l1.UnorderedItems)}");
            Console.WriteLine($"Second list \n{string.Join(", ",l2.UnorderedItems)}");
        }

        long total = 0;
        while (l1.Count > 0 && l2.Count > 0)
        {
            var n1 = l1.Dequeue();
            var n2 = l2.Dequeue();
            total += Math.Abs(n1 - n2);
        }
        
        return total;
    }

    public long Solve2(string input, bool debug)
    {
        var occurrences = GetOccurences(input);
        var numbers = GetItemList(input);
        if (debug)
        {
            Console.WriteLine(numbers.Length);
            Console.WriteLine(string.Join(", ", numbers));
        }

        long total = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (occurrences.TryGetValue(numbers[i], out var value))
            {
                total += numbers[i] * value;
            }
        }

        return total;
    }

    private static List<PriorityQueue<long, long>> ParseInput(string input)
    {
        var lists = new List<PriorityQueue<long, long>>();
        var l1 = new PriorityQueue<long, long>();
        var l2 = new PriorityQueue<long, long>();
        var rows = input.Split(Environment.NewLine);
        foreach (var row in rows)
        {
            var numbers = Regex.Split(row, @"\s+").Where(s => s != string.Empty).Select(long.Parse).ToArray();
            l1.Enqueue(numbers[0], numbers[0]);
            l2.Enqueue(numbers[1], numbers[1]);
        }
        
        lists.Add(l1);
        lists.Add(l2);
        return lists;
    }

    private static Dictionary<long, long> GetOccurences(string input)
    {
        var rows = input.Split(Environment.NewLine);
        var occurrences = new Dictionary<long, long>();
        foreach (var row in rows)
        {
            var numbers = Regex.Split(row, @"\s+").Where(s => s != string.Empty).Select(long.Parse).ToArray();
            if (!occurrences.TryAdd(numbers[1], 1))
            {
                occurrences[numbers[1]]++;
            }
        }

        return occurrences;
    }

    private static long[] GetItemList(string input)
    {
        var rows = input.Split(Environment.NewLine);
        var numbers = new long[rows.Length];
        for (int i = 0; i < rows.Length; i++)
        {
            numbers[i] = long.Parse(Regex.Replace(rows[i], @"\s+\d+", ""));
        }

        return numbers;
    }
}