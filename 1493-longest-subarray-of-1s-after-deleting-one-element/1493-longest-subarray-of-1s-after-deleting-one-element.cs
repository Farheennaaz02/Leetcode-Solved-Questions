public class Solution {
    public int LongestSubarray(int[] nums) {
        // delete nho karenge bs length m sse count of zero sub kr denge 

        //delete only one 0
        int left =0;
        int max =0;
        int zero=0;
        for ( int right =0;right<nums.Length ;right ++){
            
            if ( nums[right ]==0){
                zero++;
            }
            while (zero>1){
                if ( nums[left]==0){
                    zero--;
                }
                left ++;
            }
            max = Math.Max ( max , right - left) ;
        }
        return max;
        
        
        
    }
}