public class Solution
{
    const long MOD = 1000000007;

    public int[] SumAndMultiply(string s, int[][] queries)
    {
        int n = s.Length;

        // Prefix sum of digits
        int[] prefixSum = new int[n + 1];

        // Store positions of non-zero digits
        List<int> pos = new List<int>();

        // Prefix number formed by non-zero digits
        List<long> prefixNum = new List<long>();
        prefixNum.Add(0);

        for (int i = 0; i < n; i++)
        {
            int d = s[i] - '0';
            prefixSum[i + 1] = prefixSum[i] + d;

            if (d != 0)
            {
                pos.Add(i);
                prefixNum.Add((prefixNum[prefixNum.Count - 1] * 10 + d) % MOD);
            }
        }

        int m = pos.Count;

        long[] pow10 = new long[m + 1];
        pow10[0] = 1;
        for (int i = 1; i <= m; i++)
            pow10[i] = (pow10[i - 1] * 10) % MOD;

        int[] ans = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            int l = queries[i][0];
            int r = queries[i][1];

            int left = LowerBound(pos, l);
            int right = UpperBound(pos, r);

            int cnt = right - left;

            long x = 0;
            if (cnt > 0)
            {
                x = (prefixNum[right]
                    - prefixNum[left] * pow10[cnt] % MOD
                    + MOD) % MOD;
            }

            long sum = prefixSum[r + 1] - prefixSum[l];

            ans[i] = (int)((x * sum) % MOD);
        }

        return ans;
    }

    private int LowerBound(List<int> arr, int target)
    {
        int l = 0, r = arr.Count;
        while (l < r)
        {
            int mid = (l + r) / 2;
            if (arr[mid] < target)
                l = mid + 1;
            else
                r = mid;
        }
        return l;
    }

    private int UpperBound(List<int> arr, int target)
    {
        int l = 0, r = arr.Count;
        while (l < r)
        {
            int mid = (l + r) / 2;
            if (arr[mid] <= target)
                l = mid + 1;
            else
                r = mid;
        }
        return l;
    }
}