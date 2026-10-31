
class Solution {
    public int uniquePaths(int[][] grid) {
        int m = grid.length;
        int n = grid[0].length;

        int MOD = 1000000007;

        // dp[i][j][0] = entered while moving right
        // dp[i][j][1] = entered while moving down
        long[][][] dp = new long[m][n][2];

        // Start only once
        dp[0][0][0] = 1;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {

                long right = dp[i][j][0];
                long down = dp[i][j][1];

                if (grid[i][j] == 0) {

                    long total = (right + down) % MOD;

                    // Move right
                    if (j + 1 < n) {
                        dp[i][j + 1][0] =
                            (dp[i][j + 1][0] + total) % MOD;
                    }

                    // Move down
                    if (i + 1 < m) {
                        dp[i + 1][j][1] =
                            (dp[i + 1][j][1] + total) % MOD;
                    }

                } else {

                    // Mirror: right -> down
                    if (i + 1 < m) {
                        dp[i + 1][j][1] =
                            (dp[i + 1][j][1] + right) % MOD;
                    }

                    // Mirror: down -> right
                    if (j + 1 < n) {
                        dp[i][j + 1][0] =
                            (dp[i][j + 1][0] + down) % MOD;
                    }
                }
            }
        }

        return (int)((dp[m - 1][n - 1][0]
                    + dp[m - 1][n - 1][1]) % MOD);
    }
}
