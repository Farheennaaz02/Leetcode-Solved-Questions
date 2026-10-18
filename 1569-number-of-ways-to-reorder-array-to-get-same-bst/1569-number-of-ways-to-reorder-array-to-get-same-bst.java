
class Solution {
    static final int MOD = 1_000_000_007;
    long[][] comb;

    public int numOfWays(int[] nums) {
        int n = nums.length;

        // Precompute combinations: C(n, r)
        comb = new long[n + 1][n + 1];

        for (int i = 0; i <= n; i++) {
            comb[i][0] = comb[i][i] = 1;

            for (int j = 1; j < i; j++) {
                comb[i][j] =
                    (comb[i - 1][j - 1] + comb[i - 1][j]) % MOD;
            }
        }

        // Subtract 1 because original ordering is also counted
        return (int) ((solve(nums) - 1 + MOD) % MOD);
    }

    private long solve(int[] nums) {
        int n = nums.length;

        if (n <= 2) {
            return 1;
        }

        int root = nums[0];

        // Separate elements into left and right subtrees
        java.util.List<Integer> left = new java.util.ArrayList<>();
        java.util.List<Integer> right = new java.util.ArrayList<>();

        for (int i = 1; i < n; i++) {
            if (nums[i] < root) {
                left.add(nums[i]);
            } else {
                right.add(nums[i]);
            }
        }

        int L = left.size();
        int R = right.size();

        // Convert lists back to arrays
        int[] leftArr = left.stream()
                            .mapToInt(Integer::intValue)
                            .toArray();

        int[] rightArr = right.stream()
                              .mapToInt(Integer::intValue)
                              .toArray();

        // Interleave left and right elements, then reorder each subtree
        long ways = comb[L + R][L];
        ways = ways * solve(leftArr) % MOD;
        ways = ways * solve(rightArr) % MOD;

        return ways;
    }
}
