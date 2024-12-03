using System.Text.RegularExpressions;

namespace AoC.Solver;

public class Day2 : ISolver<long>
{
    public long Solve(string input, bool debug)
    {
        var reports = GetReports(input);
        long safe = 0;
        foreach (var report in reports)
        {
            if (debug)
            {
                Console.WriteLine(string.Join(" ",report));
            }

            var sign = Math.Sign(report[report.Count - 1] - report[0]);
            if (sign == 0)
            {
                continue;
            }
            var isValid = true;
            for (var i = 0; i < report.Count - 1; i++)
            {
                var diff = report[i+1] - report[i];
                if (debug)
                {
                    Console.WriteLine($"index {i+1} index {1} diff {diff}");
                }

                if (Math.Sign(diff) != sign || Math.Abs(diff) > 3)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                safe++;
            }
        }

        return safe;
    }

    public long Solve2(string input, bool debug)
    {
        return 0;
    }

    private List<List<int>> GetReports(string input)
    {
        var reports = new List<List<int>>();
        foreach (var se in input.Split(Environment.NewLine))
        {
            reports.Add(se.Split(" ").Select(int.Parse).ToList());
        }

        return reports;
    }
}