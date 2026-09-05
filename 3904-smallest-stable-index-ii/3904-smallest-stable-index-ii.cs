public class Solution {
    public int FirstStableIndex(int[] nums, int k) {
        int n = nums.Length ;
        if ( n==0){
            return -1;
        }
        // max and min 
        int [] right =new int [n];
        right[n-1] = nums[n-1];
        for ( int i=n-2;i>=0;i--){
            right[i]= Math.Min (nums[i],right[i+1]);
        }
        int left = nums[0];// max thing 
        for ( int i =0;i<n;i++){
            left = Math.Max ( left , nums[i]);
            if ( left - right[i] <=k){
                return i ;
            }
        }
        return -1;
    }
}