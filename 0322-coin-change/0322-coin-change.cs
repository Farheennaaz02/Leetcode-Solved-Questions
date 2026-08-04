public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if(amount<1){
            return 0;
        }
        int [] dp = new int [amount +1];
        for ( int i=1;i<=amount;i++){
            dp[i]= amount+1;
            foreach ( int coin in coins){
                if (coin<=i&& dp[i-coin]!=int.MinValue){
                    dp[i]= Math.Min(dp[i],dp[i-coin]+1);
                }
            }
        }
        if (dp[amount]==amount+1){
            return -1;
        }
        return dp[amount];
        
    }
}