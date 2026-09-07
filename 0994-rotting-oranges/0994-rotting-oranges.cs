public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        Queue<(int row, int col, int minutes)> q = new();

        int fresh = 0;

        // Put all rotten oranges in queue
        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (grid[row][col] == 2)
                {
                    q.Enqueue((row, col, 0));
                }
                else if (grid[row][col] == 1)
                {
                    fresh++;
                }
            }
        }

        int[][] dimensions =
        {
            new int[] {-1, 0},
            new int[] {1, 0},
            new int[] {0, -1},
            new int[] {0, 1}
        };

        int answer = 0;

        while (q.Count > 0)
        {
            var current = q.Dequeue();

            int row = current.row;
            int col = current.col;
            int minutes = current.minutes;

            foreach (int[] dir in dimensions)
            {
                int newrow = row + dir[0];
                int newcol = col + dir[1];

                if (newrow >= 0 && newcol >= 0 &&
                    newrow < m && newcol < n &&
                    grid[newrow][newcol] == 1)
                {
                    grid[newrow][newcol] = 2;

                    fresh--;

                    q.Enqueue((newrow, newcol, minutes + 1));

                    answer = minutes + 1;
                }
            }
        }

        if (fresh > 0)
        {
            return -1;
        }

        return answer;
    }
}