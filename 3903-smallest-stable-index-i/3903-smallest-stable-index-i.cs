

using System;

public class Solution {
    public int FirstStableIndex(int[] nums, int k) {
        int n = nums.Length;
        if (n == 0) return -1;

        // right[i] will store the minimum value from index i to n-1
        int[] right = new int[n];
        right[n - 1] = nums[n - 1];
        
        for (int i = n - 2; i >= 0; i--) {
            right[i] = Math.Min(right[i + 1], nums[i]);
        }

        // left tracks the maximum value from index 0 to i
        int left = nums[0];
        for (int i = 0; i < n; i++) {
            left = Math.Max(left, nums[i]);
            
            // Check if the current index satisfies the stability condition
            if (left - right[i] <= k) {
                return i;
            }
        }

        return -1;
    }
}
