public class Solution
{
    public int MinMoves(string[] classroom, int energy)
    {
        int m = classroom.Length;
        int n = classroom[0].Length;

        int sr = 0, sc = 0;
        int litterCount = 0;

        // Give every litter a bit number
        int[,] litterId = new int[m, n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                litterId[i, j] = -1;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (classroom[i][j] == 'S')
                {
                    sr = i;
                    sc = j;
                }
                else if (classroom[i][j] == 'L')
                {
                    litterId[i, j] = litterCount++;
                }
            }
        }

        int allCollected = (1 << litterCount) - 1;

        // State = row, col, energy, mask
        // visited[r,c,energy,mask]
        bool[,,,] visited = new bool[m, n, energy + 1, 1 << litterCount];

        Queue<(int r, int c, int e, int mask)> q =
            new Queue<(int r, int c, int e, int mask)>();

        q.Enqueue((sr, sc, energy, 0));
        visited[sr, sc, energy, 0] = true;

        int moves = 0;

        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };

        while (q.Count > 0)
        {
            int size = q.Count;

            while (size-- > 0)
            {
                var cur = q.Dequeue();

                int r = cur.r;
                int c = cur.c;
                int e = cur.e;
                int mask = cur.mask;

                if (mask == allCollected)
                    return moves;

                for (int d = 0; d < 4; d++)
                {
                    int nr = r + dr[d];
                    int nc = c + dc[d];

                    if (nr < 0 || nr >= m || nc < 0 || nc >= n)
                        continue;

                    if (classroom[nr][nc] == 'X')
                        continue;

                    // Need 1 energy to make a move
                    if (e == 0)
                        continue;

                    int ne = e - 1;
                    int nmask = mask;

                    // Collect litter
                    if (litterId[nr, nc] != -1)
                    {
                        nmask |= 1 << litterId[nr, nc];
                    }

                    // Reset energy on R
                    if (classroom[nr][nc] == 'R')
                    {
                        ne = energy;
                    }

                    if (!visited[nr, nc, ne, nmask])
                    {
                        visited[nr, nc, ne, nmask] = true;
                        q.Enqueue((nr, nc, ne, nmask));
                    }
                }
            }

            moves++;
        }

        return -1;
    }
}