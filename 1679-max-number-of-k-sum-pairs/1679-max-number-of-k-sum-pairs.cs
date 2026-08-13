public class Solution {
    public int MaxOperations(int[] nums, int k) {
        int count =0;
        Array.Sort ( nums);
        int left =0;
        int right = nums.Length -1;
        while (left<right ){
            if (nums[left]+nums[right]==k){
                count ++;
                left ++;
                right --;
            }
            else if ( nums[left]+nums[right]<k){
                left ++;
            }
            else{
                right --;
            }
        }
        return count ;
        
    }
}