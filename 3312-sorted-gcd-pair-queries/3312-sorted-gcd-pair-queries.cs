public class Solution {
    public int[] GcdValues(int[] nums, long[] queries) {
        int mx = 0;
        foreach (int x in nums)
            mx = Math.Max(mx, x);

        int[] freq = new int[mx + 1];
        foreach (int x in nums)
            freq[x]++;

        // cntG[g] = number of pairs whose gcd is exactly g
        long[] cntG = new long[mx + 1];

        for (int g = mx; g >= 1; --g) {
            long c = 0;

            // count numbers divisible by g
            for (int y = g; y <= mx; y += g)
                c += freq[y];

            // choose any 2 among them
            cntG[g] = c * (c - 1) / 2;

            // remove multiples (inclusion-exclusion)
            for (int y = g + g; y <= mx; y += g)
                cntG[g] -= cntG[y];
        }

        // prefix sums over gcd values
        long[] pref = new long[mx + 1];
        for (int g = 1; g <= mx; ++g)
            pref[g] = pref[g - 1] + cntG[g];

        int[] ans = new int[queries.Length];

        for (int i = 0; i < queries.Length; ++i) {
            long k = queries[i] + 1; // 1-based

            int l = 1, r = mx;
            while (l < r) {
                int m = (l + r) / 2;
                if (pref[m] >= k)
                    r = m;
                else
                    l = m + 1;
            }

            ans[i] = l;
        }

        return ans;
    }
}