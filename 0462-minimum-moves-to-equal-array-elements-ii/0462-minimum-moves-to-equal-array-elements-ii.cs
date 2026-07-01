public class Solution {
    public int MinMoves2(int[] nums) {
        Array.Sort (nums);
        int moves =0;
        int n = nums.Length ;
        int mid = nums[n/2];
        foreach( int  num in nums){
            moves+=Math.Abs(mid - num);
        }
        return moves ;
        
    }
}