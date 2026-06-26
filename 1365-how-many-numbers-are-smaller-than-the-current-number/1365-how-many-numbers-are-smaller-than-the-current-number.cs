public class Solution {
    public int[] SmallerNumbersThanCurrent(int[] nums) {
        int [] result = new int [nums.Length];
        
        for ( int i =0;i<nums.Length ;i++){
            int count =0;

            int j=0;
            if ( i ==j){
                j++;
            }
            while ( j<nums.Length){
                if ( nums[i]> nums[j]){
                    count ++;
                    
                }
                j++;
            }
            result[i]= count ;
        }
        return result ;
        
    }
}