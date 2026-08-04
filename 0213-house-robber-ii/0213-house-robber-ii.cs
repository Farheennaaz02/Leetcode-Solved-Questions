public class Solution {
    public int Rob(int[] nums) {
        // aranged in a circle
        int n = nums.Length;
        if (n==1){
            return nums[0];
        }
        int [] skiplast= new int [n-1];
        int[] skipfirst = new int [n-1];
        for (int i =0;i<n-1;i++){
            skiplast[i]=nums[i];
            skipfirst[i]= nums[i+1];
        }
        int lootlast = Rohelper(skiplast);
        int lootfirst = Rohelper(skipfirst);
        return Math.Max(lootlast,lootfirst);
        
    }
    private int Rohelper(int [] nums){
        int n = nums.Length;
         if (n==1){
            return nums[0];
        }
        int [] dp =new int[n];
        dp[0]=nums[0];
        dp[1]= Math.Max(nums[0], nums[1]);
        for ( int i =2;i<n;i++){
            dp[i]= Math.Max(dp[i-1],dp[i-2]+nums[i]);
        }
        return dp[n-1];
    }
}