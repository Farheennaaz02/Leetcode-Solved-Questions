class Solution {
    public int minMoves2(int[] nums) {
        Arrays.sort (nums);
        int moves =0;
        int  mid  = nums[nums.length/2];
        for(int num  : nums){
            moves+=Math.abs (mid - num);

        }
        return moves ;
        
    }
}