public class Solution {
    public bool PredictTheWinner(int[] nums) {
        int n = nums.Length ;
        int player1=solve (0,n-1,  nums);
        int totalscore = nums.Sum ();
        int player2= totalscore-player1;
        return (player1>=player2);

        
    }
    public int solve(int i ,int j , int[] nums){
        if ( i>j){
            return 0;
        }
        if (i==j){
            return nums[i];

        }
        int takei=nums[i]+Math.Min (solve(i+1,j-1,nums),solve(i+2,j,nums));
        int takej= nums[j]+Math.Min (solve (i,j-2,nums),solve (i+1,j-1,nums));
        return Math.Max(takei, takej);
    }
}