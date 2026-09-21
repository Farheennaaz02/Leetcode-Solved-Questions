class Solution {
    public long[] resultArray(int[] nums, int k) {

        long[] result = new long[k];

        // dp[r] = number of subarrays ending at previous index
        // whose product % k = r
        long[] dp = new long[k];

        for (int num : nums) {

            long[] next = new long[k];

            // Start a new subarray with only num
            int rem = num % k;
            next[rem]++;

            // Extend all previous subarrays by num
            for (int r = 0; r < k; r++) {
                if (dp[r] > 0) {
                    int newRem = (r * rem) % k;
                    next[newRem] += dp[r];
                }
            }

            // Add all subarrays ending at current index
            for (int r = 0; r < k; r++) {
                result[r] += next[r];
            }

            dp = next;
        }

        return result;
    }
}