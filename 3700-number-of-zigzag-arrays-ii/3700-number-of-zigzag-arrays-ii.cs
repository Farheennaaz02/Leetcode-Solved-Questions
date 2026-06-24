public class Solution
{
    private const long MOD = 1000000007;

    public int ZigZagArrays(int n, int l, int r)
    {
        int m = r - l + 1;
        int size = 2 * m;

        long[,] trans = new long[size, size];

        // up -> down
        for (int x = 0; x < m; x++)
        {
            for (int y = x + 1; y < m; y++)
            {
                trans[x, m + y] = 1;
            }
        }

        // down -> up
        for (int x = 0; x < m; x++)
        {
            for (int y = 0; y < x; y++)
            {
                trans[m + x, y] = 1;
            }
        }

        long[,] power = MatrixPower(trans, n - 1);

        long[] startUp = new long[size];
        long[] startDown = new long[size];

        for (int i = 0; i < m; i++)
        {
            startUp[i] = 1;
            startDown[m + i] = 1;
        }

        long[] res1 = Multiply(power, startUp);
        long[] res2 = Multiply(power, startDown);

        long ans = 0;

        for (int i = 0; i < size; i++)
        {
            ans = (ans + res1[i]) % MOD;
            ans = (ans + res2[i]) % MOD;
        }

        return (int)ans;
    }

    private long[,] MatrixPower(long[,] mat, long exp)
    {
        int n = mat.GetLength(0);

        long[,] result = new long[n, n];

        for (int i = 0; i < n; i++)
        {
            result[i, i] = 1;
        }

        while (exp > 0)
        {
            if ((exp & 1) == 1)
            {
                result = Multiply(result, mat);
            }

            mat = Multiply(mat, mat);
            exp >>= 1;
        }

        return result;
    }

    private long[,] Multiply(long[,] a, long[,] b)
    {
        int n = a.GetLength(0);

        long[,] res = new long[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int k = 0; k < n; k++)
            {
                if (a[i, k] == 0) continue;

                for (int j = 0; j < n; j++)
                {
                    if (b[k, j] == 0) continue;

                    res[i, j] =
                        (res[i, j] + a[i, k] * b[k, j]) % MOD;
                }
            }
        }

        return res;
    }

    private long[] Multiply(long[,] matrix, long[] vector)
    {
        int n = vector.Length;

        long[] res = new long[n];

        for (int i = 0; i < n; i++)
        {
            long sum = 0;

            for (int j = 0; j < n; j++)
            {
                sum = (sum + matrix[i, j] * vector[j]) % MOD;
            }

            res[i] = sum;
        }

        return res;
    }
}