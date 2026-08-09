public class Solution
{
    public int StoneGameII(int[] piles)
    {
        int n = piles.Length;

        // suffix[i] = piles[i] + piles[i+1] + ... + piles[n-1]
        int[] suffix = new int[n + 1];

        for (int i = n - 1; i >= 0; i--)
        {
            suffix[i] = suffix[i + 1] + piles[i];
        }

        // dp[i][M] = maximum stones current player can get
        // starting from index i with current M
        int[,] dp = new int[n, 2 * n + 1];

        for (int i = n - 1; i >= 0; i--)
        {
            for (int M = 1; M <= n; M++)
            {
                // If we can take all remaining piles
                if (i + 2 * M >= n)
                {
                    dp[i, M] = suffix[i];
                    continue;
                }

                int best = 0;

                // Take X piles where 1 <= X <= 2*M
                for (int X = 1; X <= 2 * M && i + X <= n; X++)
                {
                    int opponent = dp[i + X, Math.Max(M, X)];

                    // Total remaining - opponent's maximum
                    best = Math.Max(best, suffix[i] - opponent);
                }

                dp[i, M] = best;
            }
        }

        return dp[0, 1];
    }
}