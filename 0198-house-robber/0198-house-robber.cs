public class Solution {
    public int Rob(int[] nums) {
        // base condition 
        int n = nums.Length;
        if (n<2){
            return nums[0];
        }
        int [] dp = new int [n+1];
        dp[0]= nums[0];
        dp[1]= Math.Max(nums[1],nums[0]);
        for ( int i =2;i<n;i++){
            dp[i]= Math.Max(dp[i-2]+nums[i],dp[i-1]);
        }
        return dp[n-1];
        
    }
}