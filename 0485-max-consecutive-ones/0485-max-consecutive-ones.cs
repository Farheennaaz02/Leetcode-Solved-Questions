public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int n = nums.Length;
        int count =0;
        int ans =0;
     
        for( int i =0;i<n;i++){
            if (  nums[i]==1){
                count ++;
                ans = Math.Max ( ans , count );
            }
            else{
                count =0;
            }
        }
        return ans ;
    }
}