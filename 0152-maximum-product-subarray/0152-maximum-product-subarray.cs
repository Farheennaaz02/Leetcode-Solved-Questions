public class Solution {
    public int MaxProduct(int[] nums) {
        int n = nums.Length;
        int left =1;
        int right =1;
        int ans =nums[0];
        for (  int i =0;i<n;i++){
            if ( left ==0){
                left =1;
            }
            if ( right ==0){
                right =1;
            }
            left  = left* nums[i];
            right = right * nums[n-1-i];
            ans = Math.Max (ans , Math.Max (left, right ));


        }
        return ans ;
        
    }
}