class Solution {
    public boolean canJump(int[] nums) {
    int len =nums.length ;
    int goal = len -1 ;
    for (  int i=len-2 ;i>=0;i--){
        if (i+nums[i]>=goal){
            goal = i;
        }
    }
    return goal ==0;
        
    }
}