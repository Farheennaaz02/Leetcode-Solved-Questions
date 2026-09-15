class Solution {
    public int maxPalindromes(String s, int k) {

        int n = s.length();

        // dp[i][j] = true if s[i...j] is a palindrome
        boolean[][] dp = new boolean[n][n];

        // Build palindrome DP
        for (int len = 1; len <= n; len++) {

            for (int i = 0; i + len - 1 < n; i++) {

                int j = i + len - 1;

                if (s.charAt(i) == s.charAt(j) &&
                    (len <= 2 || dp[i + 1][j - 1])) {

                    dp[i][j] = true;
                }
            }
        }

        int count = 0;

        // End position of previously selected palindrome
        int lastEnd = -1;

        // Process palindromes by their ending position
        for (int end = 0; end < n; end++) {

            for (int start = lastEnd + 1; start <= end - k + 1; start++) {

                if (dp[start][end]) {

                    count++;

                    // Select this palindrome
                    lastEnd = end;

                    break;
                }
            }
        }

        return count;
    }
}