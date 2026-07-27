public class Solution {
    public int MaxProduct(int[] nums) {
        Array.Sort (nums);
        int n = nums.Length ;
       // int last = nums[n-1];
        int ans = nums[n-1]-1;
        int ans2 = nums[n-2]-1;
        return ans *ans2;
        
    }
}