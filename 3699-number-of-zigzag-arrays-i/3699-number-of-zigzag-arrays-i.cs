public class Solution
{
    public int ZigZagArrays(int n, int l, int r)
    {
        const long MOD = 1000000007;

        int m = r - l + 1;

        // Length 1 arrays
        long[] up = new long[m];
        long[] down = new long[m];

        for (int i = 0; i < m; i++)
        {
            up[i] = 1;
            down[i] = 1;
        }

        for (int len = 2; len <= n; len++)
        {
            long[] newUp = new long[m];
            long[] newDown = new long[m];

            long[] prefixUp = new long[m];
            long[] prefixDown = new long[m];

            prefixUp[0] = up[0];
            prefixDown[0] = down[0];

            // Build prefix sums
            for (int i = 1; i < m; i++)
            {
                prefixUp[i] = (prefixUp[i - 1] + up[i]) % MOD;
                prefixDown[i] = (prefixDown[i - 1] + down[i]) % MOD;
            }

            long totalUp = prefixUp[m - 1];

            for (int y = 0; y < m; y++)
            {
                // Previous value < current value
                if (y > 0)
                {
                    newUp[y] = prefixDown[y - 1];
                }

                // Previous value > current value
                if (y < m - 1)
                {
                    newDown[y] =
                        (totalUp - prefixUp[y] + MOD) % MOD;
                }
            }

            up = newUp;
            down = newDown;
        }

        if (n == 1)
        {
            return m;
        }

        long answer = 0;

        for (int i = 0; i < m; i++)
        {
            answer = (answer + up[i]) % MOD;
            answer = (answer + down[i]) % MOD;
        }

        return (int)answer;
    }
}