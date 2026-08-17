public class Solution {
    public int PivotIndex(int[] nums) {
        int n = nums.Length;
        int sum =0;
        int leftsum =0;
        for ( int i =0;i<n;i++){
            sum +=nums[i];
        }
        for ( int right=0;right<n;right++){
            int rightsum = sum - leftsum -nums[right];
            if (leftsum ==rightsum ){
                return right;// index 
            }
            else{
                leftsum+=nums[right];
            }
            
        }
        return -1;
        
    }
}