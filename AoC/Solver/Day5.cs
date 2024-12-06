namespace AoC.Solver;

public class Day5 : ISolver<long>
{
    public long Solve(string input, bool debug)
    {
        var rules = ParseRules(input);
        var updates = ParseUpdates(input);
        var total = 0;
        foreach (var update in updates)
        {
            var isValid = true;
            for (var i = update.Count - 1; i > 0; i--)
            {
                var key = update[i];
                for (var j = i - 1; j > -1; j--)
                {
                    if (rules.TryGetValue(key, out var value) && value.Contains(update[j]))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (!isValid) continue;
            var medIdx = (int)Math.Floor(update.Count / 2d);
            total += update[medIdx];
        }
        return total;
    }

    

    public long Solve2(string input, bool debug)
    {
        var rules = ParseRules(input);
        var updates = ParseUpdates(input);
        var total = 0;
        foreach (var update in updates)
        {
            var isValid = true;
            for (var i = update.Count - 1; i > 0; i--)
            {
                var key = update[i];
                for (var j = i - 1; j > -1; j--)
                {
                    if (rules.TryGetValue(key, out var value) && value.Contains(update[j]))
                    {
                        isValid = false;
                        var temp = update[j];
                        update[j] = key;
                        update[i] = temp;
                        i = update.Count;
                        break;
                    }
                }
            }

            if (isValid) continue;
            var medIdx = (int)Math.Floor(update.Count / 2d);
            total += update[medIdx];
        }
        return total;
    }
    
    private static Dictionary<int, HashSet<int>> ParseRules(string input)
    {
        var rules = new Dictionary<int, HashSet<int>>();
        var rows = input.Split(Environment.NewLine);
        foreach (var row in rows)
        {
            if (row.Trim().Length == 0)
            {
                break;
            }

            var values = row.Split("|").Select(int.Parse).ToArray();

            if (!rules.ContainsKey(values[0]))
            {
                rules.Add(values[0], [values[1]]);
            }
            else
            {
                rules[values[0]].Add(values[1]);
            }
        }

        return rules;
    }
    
    private static List<List<int>> ParseUpdates(string input)
    {
        var updates = new List<List<int>>();
        var rows = input.Split(Environment.NewLine);
        var idx = 0;
        while (rows[idx].Trim() != string.Empty)
        {
            idx++;
        }
        idx++;
        for (var i = idx; i < rows.Length; i++)
        {
            updates.Add(rows[i].Split(",").Select(int.Parse).ToList());
        }
        
        return updates;
    }
}