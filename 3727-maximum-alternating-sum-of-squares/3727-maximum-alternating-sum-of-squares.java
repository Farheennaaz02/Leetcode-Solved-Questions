import java.util.Arrays;

public class Solution {
    public long maxAlternatingSum(int[] nums) {
        int n = nums.length;
        long[] squaredNums = new long[n];
        
        // Step 1: Square every element (cast to long to avoid overflow)
        for (int i = 0; i < n; i++) {
            squaredNums[i] = (long) nums[i] * nums[i];
        }
        
        // Step 2: Sort the squares in ascending order
        Arrays.sort(squaredNums);
        
        int m = n / 2; // Number of elements to subtract
        long totalSum = 0;
        
        // Step 3: Subtract the smaller half and add the larger half
        for (int i = 0; i < n; i++) {
            if (i < m) {
                totalSum -= squaredNums[i];
            } else {
                totalSum += squaredNums[i];
            }
        }
        
        return totalSum;
    }
}