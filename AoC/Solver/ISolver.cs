namespace AoC.Solver;

public interface ISolver<out T>
{ 
    T Solve(string input, bool debug);
}