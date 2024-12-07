using System.Numerics;

namespace AoC.Solver;

public class Day6 : ISolver<long>
{
    public long Solve(string input, bool debug)
    {
        var visited = new HashSet<Vector2Int>();
        var map = ParseInput(input);
        var height = map.Length;
        var width = map[0].Length;
        var pos = GetGuardCurrentPosition(map);
        visited.Add(pos);
        var direction = new Vector2Int(0, -1);
        var nextTile = pos + direction;
        if (debug)
        {
            Console.WriteLine("");
            Console.WriteLine("------INITIAL------");
            Console.WriteLine("");
            foreach (var row in map)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
        while (nextTile.X > -1 && nextTile.X < width && nextTile.Y > -1 && nextTile.Y < height)
        {
            map[pos.Y][pos.X] = 'X';
            
            if (map[nextTile.Y][nextTile.X] != '#')
            {
                pos = nextTile;
                visited.Add(pos);
            }
            else
            {
                direction = TurnRight(direction);
            }
            nextTile = pos + direction;
        }
        map[pos.Y][pos.X] = 'X';
        if (debug)
        {
            Console.WriteLine("");
            Console.WriteLine("------FINAL------");
            Console.WriteLine("");
            foreach (var row in map)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
        return visited.Count;
    }

    public long Solve2(string input, bool debug)
    {
        var possibleObstacle = new HashSet<Vector2Int>();
        var map = ParseInput(input);
        var height = map.Length;
        var width = map[0].Length;
        var pos = GetGuardCurrentPosition(map);
        var direction = new Vector2Int(0, -1);
        var nextTile = pos + direction;
        var obstacles = new List<Vector2Int>();
        if (debug)
        {
            Console.WriteLine("");
            Console.WriteLine("------INITIAL------");
            Console.WriteLine("");
            foreach (var row in map)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
        while (nextTile.X > -1 && nextTile.X < width && nextTile.Y > -1 && nextTile.Y < height)
        {
            //map[pos.Y][pos.X] = 'X';
            
            if (map[nextTile.Y][nextTile.X] != '#')
            {
                if (obstacles.Count > 2 && obstacles.Any(obstacle => direction is {X: 0, Y: -1} && obstacle.X > nextTile.X && obstacle.Y == pos.Y
                                                                 || direction is {X: 0, Y: 1} && obstacle.X < nextTile.X && obstacle.Y == pos.Y
                                                                 || direction is {X:-1, Y:0} && obstacle.Y < nextTile.Y && obstacle.X == pos.X
                                                                 || direction is {X:1, Y:0} && obstacle.Y > nextTile.Y && obstacle.X == pos.X))
                {
                    possibleObstacle.Add(nextTile);
                    map[nextTile.Y][nextTile.X] = 'O';
                }
                
                pos = nextTile;
                switch(direction)
                {
                    case { X: 0, Y: -1 }:
                    case { X: 0, Y: 1 }:
                        map[pos.Y][pos.X] = map[pos.Y][pos.X] switch
                        {
                            '-' => '+',
                            '.' => '|',
                            _ => map[pos.Y][pos.X]
                        };

                        break;
                    case { X: 1, Y: 0 }:
                    case { X: -1, Y: 0 }:
                        map[pos.Y][pos.X] = map[pos.Y][pos.X] switch
                        {
                            '|' => '+',
                            '.' => '-',
                            _ => map[pos.Y][pos.X]
                        };
                        break;
                };
            }
            else
            {
                obstacles.Add(nextTile);
                direction = TurnRight(direction);
            }
            nextTile = pos + direction;
        }
        //map[pos.Y][pos.X] = 'X';
        
        if (debug)
        {
            Console.WriteLine("");
            Console.WriteLine("------FINAL------");
            Console.WriteLine("");
            foreach (var row in map)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
        return possibleObstacle.Count;
    }

    private static char[][] ParseInput(string input)
    {
        var rows = input.Split(Environment.NewLine);
        var map = new char[rows.Length][];
        for (var i = 0; i < rows.Length; i++)
        {
            map[i] = rows[i].ToCharArray();
        }

        return map;
    }

    private static Vector2Int TurnRight(Vector2Int direction)
    {
        return direction switch
        {
            { X: 0, Y: -1 } => new Vector2Int(1, 0),
            { X: 1, Y: 0 } => new Vector2Int(0, 1),
            { X: 0, Y: 1 } => new Vector2Int(-1, 0),
            _ => new Vector2Int(0, -1)
        };
    }

    private static Vector2Int GetGuardCurrentPosition(char[][] map)
    {
        var height = map.Length;
        var width = map[0].Length;
        for (var row = 0; row < height; row++)
        {
            for (var col = 0; col < width; col++)
            {
                if (map[row][col] == '^')
                {
                    return new Vector2Int(col, row);
                }
            }
        }
        
        return new Vector2Int();
    }

    
}

public struct Vector2Int(int x = 0, int y = 0) : IEquatable<Vector2Int>
{
    public bool Equals(Vector2Int other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector2Int other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    
    public static Vector2Int operator +(Vector2Int a, Vector2Int b)
    {
        return new Vector2Int(a.X + b.X, a.Y + b.Y);
    }
}

