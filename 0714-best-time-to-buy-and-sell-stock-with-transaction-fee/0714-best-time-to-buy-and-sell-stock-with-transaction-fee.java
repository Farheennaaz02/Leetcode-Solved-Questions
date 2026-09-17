class Solution {
    public int maxProfit(int[] prices, int fee) {
        int n = prices.length ;
        int [][] dp = new int [n][2];
        boolean buy = true ;
        for ( int i =0;i<n;i++){
            dp[i][0]=-1;
            dp[i][1]=-1;
        }
        return solve ( prices, fee , 0 , n , 0 , dp,buy );

    }
    int solve (int [] prices , int fee , int day , int n , int profit , int [][] dp , boolean buy){
        if (day >=n){
            return 0;
        }
        int state ;
        if (buy) {
            state =1;
        }
        else {
            state =0;
        }
        if (dp[day][state]!=-1){
            return (dp[day][state]);
        }
        if (buy){
            int take =solve (prices , fee , day+1, n,profit , dp , false)-prices[day];
            int nottake =solve (prices , fee , day+1 , n, profit , dp , true );
            profit= Math.max (profit , Math.max (nottake , take ));
        }
        else {
            int sell = solve (prices , fee , day+1,n,profit,dp,true)+prices[day]-fee;
            int notsell=solve (prices , fee , day+1,n,profit,dp,false );
            profit=Math.max (profit , Math.max(notsell , sell));
        }
        dp[day][state]= profit;
        return profit ;
    }
}