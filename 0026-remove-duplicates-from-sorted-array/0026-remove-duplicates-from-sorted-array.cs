public class Solution {
    public int RemoveDuplicates(int[] nums) {
        // nums = [0,0,1,1,1,2,2,3,3,4]
        //i=1;   k=1  
        int len = nums.Length;
        if ( len ==0){
            return 0;
        }
        int k =1;
        for ( int i =1;i<len;i++){
            if(nums[i]!=nums[k-1]){
                nums[k]= nums[i];
                k++;

            }
        }
        return k ;
        
    }
}