class Solution {
    public int jump(int[] nums) {
        int jump =0;
        int currentend=0;
        int farthest=0;
        for ( int i =0;i<nums.length-1 ;i++){
            farthest =  Math.max (farthest, nums[i]+i);
            if (i==currentend){
                jump ++;
                currentend = farthest;

            }
        }
        return jump ;
        
    }
}