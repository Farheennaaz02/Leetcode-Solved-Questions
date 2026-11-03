class Solution {
    public int minMoves(int[] nums) {
        Arrays.sort (nums);
        int moves=0;
        int end = nums[nums.length-1];
        for ( int num : nums){
            moves += Math.abs(end - num);
        }
        return moves ;
        
    }
}