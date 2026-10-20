
class Solution {
    public int sortableIntegers(int[] nums) {
        int n = nums.length;

        // 1. Prefix maximum
        int[] prefMax = new int[n + 1];

        for (int i = 0; i < n; i++) {
            prefMax[i + 1] = Math.max(prefMax[i], nums[i]);
        }

        // 2. Suffix minimum
        int[] suffMin = new int[n + 1];
        suffMin[n] = Integer.MAX_VALUE;

        for (int i = n - 1; i >= 0; i--) {
            suffMin[i] = Math.min(nums[i], suffMin[i + 1]);
        }

        // 3. Count adjacent decreases
        int[] prefDrop = new int[n];

        for (int i = 1; i < n; i++) {
            prefDrop[i] = prefDrop[i - 1];

            if (nums[i - 1] > nums[i]) {
                prefDrop[i]++;
            }
        }

        int ans = 0;

        // Check every divisor of n
        for (int i = 1; i <= n / i; i++) {
            if (n % i == 0) {

                if (check(nums, prefMax, suffMin, prefDrop, i)) {
                    ans += i;
                }

                int other = n / i;

                if (other != i &&
                    check(nums, prefMax, suffMin, prefDrop, other)) {
                    ans += other;
                }
            }
        }

        return ans;
    }

    private boolean check(int[] nums, int[] prefMax,
                          int[] suffMin, int[] prefDrop, int k) {
        int n = nums.length;

        for (int start = 0; start < n; start += k) {
            int end = start + k - 1;

            // Count decreases inside this block
            int drops = prefDrop[end] - prefDrop[start];

            // Also check the circular boundary
            if (nums[end] > nums[start]) {
                drops++;
            }

            // Block must be circularly sortable,
            // and values must fit the global sorted order.
            if (drops > 1 || prefMax[start] > suffMin[start]) {
                return false;
            }
        }

        return true;
    }
}
