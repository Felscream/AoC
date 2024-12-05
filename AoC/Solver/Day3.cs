using System.Text.RegularExpressions;

namespace AoC.Solver;

public class Day3 : ISolver<long>
{
    private Regex mulPattern = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
    private Regex doPattern = new Regex(@"do\(\)");
    private Regex dontPattern = new Regex(@"don't\(\)");
    public long Solve(string input, bool debug)
    {
        long total = 0;
        foreach (Match match in mulPattern.Matches(input))
        {

            long res = 0;
            if (match.Groups.Count > 2)
            {
                res = int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
            }
            
            if (debug)
            {
                Console.WriteLine($"${match.Value} = {res}");
            }

            total += res;
        }

        return total;
    }

    public long Solve2(string input, bool debug)
    {
        int mulIdx = 0;
        int dosIdx = 0;
        int dontIdx = 0;
        var mulMatches = mulPattern.Matches(input);
        var dosMatches = doPattern.Matches(input);
        var dontMatches = dontPattern.Matches(input);
        var total = 0L;
        while (mulIdx < mulMatches.Count)
        {
            var mul = mulMatches[mulIdx];
            var mulPos = mul.Index;

            var dosPos = int.MaxValue;
            if (dosIdx < dosMatches.Count)
            {
                var dos = dosMatches[dosIdx];
                dosPos = dos.Index;
            }

            var dontPos = int.MaxValue;
            if (dontIdx < dontMatches.Count)
            {
                var dont = dontMatches[dontIdx];
                dontPos = dont.Index;
            }

            if (debug)
            {
                Console.WriteLine($"Current pos = {mulPos} do pos = {dosPos} dont pos = {dontPos}");
            }

            var res = 0L;
            if (mulPos < dontPos)
            {
                res = int.Parse(mul.Groups[1].Value) * int.Parse(mul.Groups[2].Value);
                mulIdx++;
            } 
            else if (dosPos > dontPos)
            {
                while (mulIdx < mulMatches.Count && mulMatches[mulIdx].Index < dosPos)
                {
                    mulIdx++;
                }

                while (dontIdx < dontMatches.Count && dontMatches[dontIdx].Index < dosPos)
                {
                    dontIdx++;
                }
            } 
            else if (dontPos > dosPos)
            {
                dosIdx++;
            }
            
            total += res;
        }

        return total;
    }
}