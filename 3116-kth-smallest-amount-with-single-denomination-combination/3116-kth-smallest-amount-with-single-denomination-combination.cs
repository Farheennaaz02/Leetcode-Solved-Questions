public class Solution
{
    public long FindKthSmallest(int[] coins, int k)
    {
        long left = 1;

        // Maximum possible answer:
        // smallest coin * k
        long right = (long)coins[0] * k;

        foreach (int coin in coins)
        {
            right = Math.Min(right, (long)coin * k);
        }

        while (left < right)
        {
            long mid = left + (right - left) / 2;

            long count = Count(mid, coins);

            if (count >= k)
            {
                // mid has at least k valid amounts
                // so answer can be mid or smaller
                right = mid;
            }
            else
            {
                // Less than k amounts
                // answer must be bigger
                left = mid + 1;
            }
        }

        return left;
    }

    private long Count(long x, int[] coins)
    {
        long result = 0;
        int n = coins.Length;

        // Generate every non-empty subset
        for (int mask = 1; mask < (1 << n); mask++)
        {
            long lcm = 1;
            int bits = 0;

            for (int i = 0; i < n; i++)
            {
                // Is coin[i] present in this subset?
                if ((mask & (1 << i)) != 0)
                {
                    bits++;

                    lcm = LCM(lcm, coins[i]);

                    // No multiple of this LCM can be <= x
                    if (lcm > x)
                    {
                        break;
                    }
                }
            }

            if (lcm > x)
                continue;

            long count = x / lcm;

            // Odd number of coins -> ADD
            // Even number of coins -> SUBTRACT
            if (bits % 2 == 1)
            {
                result += count;
            }
            else
            {
                result -= count;
            }
        }

        return result;
    }

    private long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = a % b;
            a = b;
            b = temp;
        }

        return a;
    }

    private long LCM(long a, long b)
    {
        return a / GCD(a, b) * b;
    }
}