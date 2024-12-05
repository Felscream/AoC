namespace AoC.Solver;

public class Day4 : ISolver<long>
{
    public long Solve(string input, bool debug)
    {
        var board = ParseInput(input);
        var height = board.Length;
        var width = board[0].Length;
        var count = 0L;
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (board[row][col] == 'X')
                {
                    if (row < height - 3)
                    {
                        // top to bottom
                        if (board[row + 1][col] == 'M' && board[row + 2][col] == 'A' && board[row + 3][col] == 'S')
                        {
                            count++;
                        }
                        // diagonal top-left to bottom-right
                        if (col < width - 3 && board[row + 1][col + 1] == 'M' && board[row + 2][col + 2] == 'A' &&
                            board[row + 3][col + 3] == 'S')
                        {
                            count++;
                        }

                        // diagonal top-right to bottom-left
                        if (col > 2 && board[row + 1][col - 1] == 'M' && board[row + 2][col - 2] == 'A' &&
                            board[row + 3][col - 3] == 'S')
                        {
                            count++;
                        }
                    }

                    if (row > 2)
                    {
                        // bottom to top
                        if (board[row - 1][col] == 'M' && board[row - 2][col] == 'A' && board[row - 3][col] == 'S')
                        {
                            count++;
                        }
                        
                        // diagonal bottom left to top right
                        if (col < width - 3 && board[row - 1][col + 1] == 'M' && board[row - 2][col + 2] == 'A' && board[row - 3][col + 3] == 'S')
                        {
                            count++;
                        }
                        
                        //diagonal bottom-right to top-left
                        if (col > 2 && board[row - 1][col - 1] == 'M' && board[row - 2][col - 2] == 'A' &&
                            board[row - 3][col - 3] == 'S')
                        {
                            count++;
                        }
                    }

                    // right to left
                    if (col > 2 && board[row][col - 1] == 'M' && board[row][col - 2] == 'A' && board[row][col - 3] == 'S')
                    {
                        count++;
                    }

                    // left to right
                    if (col < width - 3 && board[row][col + 1] == 'M' && board[row][col + 2] == 'A' &&
                        board[row][col + 3] == 'S')
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    public long Solve2(string input, bool debug)
    {
        var board = ParseInput(input);
        var height = board.Length;
        var width = board[0].Length;
        var count = 0L;
        List<char> searchedChar = ['S', 'M'];
        for (var row = 1; row < height - 1; row++)
        {
            for (var col = 1; col < width - 1; col++)
            {
                if (board[row][col] == 'A')
                {
                    if (searchedChar.Contains(board[row - 1][col - 1]) && searchedChar.Contains(board[row + 1][col + 1]) && board[row - 1][col - 1] != board[row + 1][col + 1]
                        && searchedChar.Contains(board[row - 1][col + 1]) && searchedChar.Contains(board[row + 1][col - 1]) && board[row - 1][col + 1] != board[row + 1][col - 1])
                    {
                        count++;
                    }
                    
                }
            }
        }
        
        return count;
    }

    private static char[][] ParseInput(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var res = new char[lines.Length][];
        for (var i = 0; i < lines.Length; i++)
        {
            res[i] = lines[i].ToCharArray();
        }

        return res;
    }
}