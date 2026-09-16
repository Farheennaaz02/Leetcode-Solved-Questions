class Solution {
    public int numberOfSets(int n, int k) {

        int mod = 1000000007;

        int N = n + k - 1;
        int R = 2 * k;

        long[][] dp = new long[N + 1][R + 1];

        // C(i, 0) = 1
        for (int i = 0; i <= N; i++) {
            dp[i][0] = 1;
        }

        for (int i = 1; i <= N; i++) {

            for (int j = 1; j <= R; j++) {

                // Don't choose current element
                dp[i][j] = dp[i - 1][j];

                // Choose current element
                if (i >= j) {
                    dp[i][j] += dp[i - 1][j - 1];
                    dp[i][j] %= mod;
                }
            }
        }

        return (int) dp[N][R];
    }
}