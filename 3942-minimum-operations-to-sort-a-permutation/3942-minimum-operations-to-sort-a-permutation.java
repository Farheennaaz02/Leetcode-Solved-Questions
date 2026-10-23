
class Solution {
    public int minOperations(int[] nums) {
        int n = nums.length;

        // Find the position of 0
        int zero = 0;
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) {
                zero = i;
                break;
            }
        }

        // Check cyclic increasing order
        boolean increasing = true;
        for (int i = 1; i < n; i++) {
            int prev = (zero + i - 1) % n;
            int curr = (zero + i) % n;

            if (nums[curr] != nums[prev] + 1) {
                increasing = false;
                break;
            }
        }

        // Check cyclic decreasing order
        boolean decreasing = true;
        for (int i = 1; i < n; i++) {
            int prev = (zero - i + 1 + n) % n;
            int curr = (zero - i + n) % n;

            if (nums[curr] != nums[prev] + 1
                    && !(nums[prev] == n - 1 && nums[curr] == 0)) {
                decreasing = false;
                break;
            }
        }

        int ans = Integer.MAX_VALUE;

        if (increasing) {
            // Rotate directly, or use two reversals
            ans = Math.min(ans, zero);
            ans = Math.min(ans, n - zero + 2);
        }

        if (decreasing) {
            // Reverse and rotate
            ans = Math.min(ans, 1 + Math.min(
                (zero + 1) % n,
                n - 1 - zero
            ));
        }

        return ans == Integer.MAX_VALUE ? -1 : ans;
    }
}
