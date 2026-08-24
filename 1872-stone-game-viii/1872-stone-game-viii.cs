public class Solution {
    public int StoneGameVIII(int[] stones) {
        
        int n = stones.Length;

        long[] prefix = new long[n];

        prefix[0] = stones[0];

        for (int i = 1; i < n; i++) {
            prefix[i] = prefix[i - 1] + stones[i];
        }

        long dp = prefix[n - 1];

        for (int i = n - 2; i >= 1; i--) {
            dp = Math.Max(dp, prefix[i] - dp);
        }

        return (int)dp;
    }
}