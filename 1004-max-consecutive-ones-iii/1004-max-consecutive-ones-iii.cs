public class Solution {
    public int LongestOnes(int[] nums, int k) {
        int max =0;
        int left =0;


        for( int right  =0;right <nums.Length;right ++){
            if  (nums[right]==0){
                k--;
            }
            // window shink
            while (k<0){
                if (  nums[left]==0){
                    k++;
                }
                left ++;
            }
            
            max  = Math.Max (max ,right-left +1 );

            

        }
        return max ;
        
    }
}