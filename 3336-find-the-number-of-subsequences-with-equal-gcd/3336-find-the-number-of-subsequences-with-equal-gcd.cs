public class Solution
{
    const int MOD = 1_000_000_007;

    int[] nums;
    int n;
    long[,,] memo;

    public int SubsequencePairCount(int[] nums)
    {
        this.nums = nums;
        n = nums.Length;

        memo = new long[n + 1, 201, 201];

        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= 200; j++)
                for (int k = 0; k <= 200; k++)
                    memo[i, j, k] = -1;

        return (int)DFS(0, 0, 0);
    }

    private long DFS(int idx, int g1, int g2)
    {
        if (idx == n)
            return (g1 != 0 && g1 == g2) ? 1 : 0;

        if (memo[idx, g1, g2] != -1)
            return memo[idx, g1, g2];

        long ans = DFS(idx + 1, g1, g2);

        int ng1 = (g1 == 0) ? nums[idx] : GCD(g1, nums[idx]);
        ans += DFS(idx + 1, ng1, g2);
        ans %= MOD;

        int ng2 = (g2 == 0) ? nums[idx] : GCD(g2, nums[idx]);
        ans += DFS(idx + 1, g1, ng2);
        ans %= MOD;

        return memo[idx, g1, g2] = ans;
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int t = a % b;
            a = b;
            b = t;
        }
        return a;
    }
}