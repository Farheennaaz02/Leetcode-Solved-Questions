public class Solution {
    public int MaximumProduct(int[] nums) {
        // 2 negative and 1 positive 
        // all psitive 
        Array.Sort (nums);
        int n = nums.Length ;
        int first = nums[0]*nums[1]*nums[n-1];
        int second = nums[n-1]* nums[n-2]*nums[n-3];
        int ans = Math.Max (first , second );
        return ans ;

        
        
    }
}