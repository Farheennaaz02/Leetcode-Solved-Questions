
class Solution {
    private static final long MOD = 1_000_000_007L;

    public int sumCounts(int[] nums) {
        int n = nums.length;

        // Last position where each number appeared
        int[] last = new int[100001];
        java.util.Arrays.fill(last, -1);

        LazySegmentTree tree = new LazySegmentTree(n);
        long answer = 0;

        for (int i = 0; i < n; i++) {
            int x = nums[i];

            // Previous occurrence of x
            int previous = last[x];

            // Add 1 to distinct counts of subarrays
            // starting from previous + 1 through i
            tree.update(previous + 1, i);

            // Save the latest occurrence
            last[x] = i;

            // Sum of squares for subarrays ending at i
            answer = (answer + tree.getSquareSum()) % MOD;
        }

        return (int) answer;
    }

    static class LazySegmentTree {
        int n;

        // Sum of values in each segment
        long[] sum;

        // Sum of squares of values in each segment
        long[] squareSum;

        // Pending range increment
        long[] lazy;

        LazySegmentTree(int n) {
            this.n = n;
            sum = new long[4 * n];
            squareSum = new long[4 * n];
            lazy = new long[4 * n];
        }

        // Apply an increment to a complete segment
        void apply(int node, int left, int right, long add) {
            long length = right - left + 1L;

            // (x + add)^2 = x^2 + 2*x*add + add^2
            squareSum[node] =
                (squareSum[node]
                + 2L * add * sum[node] % MOD
                + length % MOD * add % MOD * add % MOD)
                % MOD;

            // Every value increases by add
            sum[node] =
                (sum[node] + length % MOD * add % MOD) % MOD;

            // Remember the pending update
            if (left != right) {
                lazy[node] = (lazy[node] + add) % MOD;
            }
        }

        // Pass pending updates to the children
        void pushDown(int node, int left, int right) {
            if (lazy[node] == 0 || left == right) {
                return;
            }

            int mid = left + (right - left) / 2;

            apply(node * 2, left, mid, lazy[node]);
            apply(node * 2 + 1, mid + 1, right, lazy[node]);

            lazy[node] = 0;
        }

        // Add 1 to every position in range [queryLeft, queryRight]
        void update(int queryLeft, int queryRight) {
            if (queryLeft > queryRight) {
                return;
            }

            update(1, 0, n - 1, queryLeft, queryRight);
        }

        void update(int node, int left, int right,
                    int queryLeft, int queryRight) {

            // No overlap
            if (right < queryLeft || left > queryRight) {
                return;
            }

            // Complete overlap
            if (queryLeft <= left && right <= queryRight) {
                apply(node, left, right, 1);
                return;
            }

            // Partial overlap: update children
            pushDown(node, left, right);

            int mid = left + (right - left) / 2;

            update(node * 2, left, mid, queryLeft, queryRight);
            update(node * 2 + 1, mid + 1, right,
                   queryLeft, queryRight);

            // Merge information from both children
            sum[node] =
                (sum[node * 2] + sum[node * 2 + 1]) % MOD;

            squareSum[node] =
                (squareSum[node * 2] + squareSum[node * 2 + 1])
                % MOD;
        }

        // Sum of squares for all starting positions
        long getSquareSum() {
            return squareSum[1];
        }
    }
}
