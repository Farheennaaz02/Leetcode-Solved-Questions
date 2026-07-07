public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int len = nums.Length;
        int k=0;
        for ( int i =0;i<len;i++){
            if ( nums [i]!= val ){
                nums[k]=nums[i];// array m hi chneges krna 
                k++;
            }
        }
        return k ;
    }
}