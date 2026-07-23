public class Solution {
    public void SortColors(int[] nums) {
        // nums [2,0,2,1,1,0]
        int left =0;
        int mid =0;
        int right = nums.Length-1;
        while ( mid <=right){
            if ( nums[mid]==0){
                int  temp = nums[mid];
                nums[mid ]= nums[left];
                nums[left]= temp;
                left ++;
                mid ++;
                
            }
            else if ( nums[mid]==2){
                int temp = nums[mid];
                nums[mid]= nums[right];
                nums[right]= temp;
                
                right --;
            }



            else {
                mid++;
            }
        }
        

        
    }
    
}