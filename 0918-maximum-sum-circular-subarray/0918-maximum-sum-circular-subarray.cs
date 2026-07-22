public class Solution {
    public int MaxSubarraySumCircular(int[] nums) {
        // circular 
        // total - min = max 
        int n =nums.Length;
        int total =0;
        for ( int i=0;i<n;i++){
            total = total + nums[i];
        }
        int min = nums[0];
        int currentmin = nums[0];
        int max = nums[0];
        int currentmax= nums[0];
        for (int i=1 ;i<n;i++){
            currentmin = Math.Min ( nums[i], currentmin +nums[i]);
            min = Math.Min (  min , currentmin);
            currentmax =Math.Max ( nums[i], currentmax +nums[i]);
            max = Math.Max ( max , currentmax );

        }
        if ( max<0){
            return max ;
        }
        return Math.Max (max , total - min );
        
    }
}