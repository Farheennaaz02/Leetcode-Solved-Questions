class Solution {
    public int minSubArrayLen(int target, int[] nums) {
        int i=0;
        int sum =0;
        int min = Integer.MAX_VALUE ;
        int minvalue  = Integer.MAX_VALUE ;
        for ( int j =0;j<nums.length ;j++){
            sum += nums[j];
            while (sum >=target){
                min = Math.min(min,j-i+1);
                sum -=nums[i];
                i++;
            }
        }
        if (min == minvalue){
            return 0;
        }
        else {
            return min ;
        }
        
    }
}