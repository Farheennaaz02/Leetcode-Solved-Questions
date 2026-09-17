class Solution {
    
    public int maxProfit(int[] prices) {
        int n = prices.length;
        boolean buy = true ;
        int [][] dp = new int [n][2];
        for (int i =0;i<n;i++){
            dp[i][0]=-1;// row border -1 all ----->
            dp[i][1]=-1;// col border -1 all 
        }
        return solve (prices , 0 , n , buy,0,dp);
    }
    int solve ( int []prices , int day , int  n , boolean buy, int profit,int [][] dp){
        if (day >=n){
            return 0;
        }
        int state ;
        if (buy){
            state=1;
        }
        else {
            state =0;
        }
        if (dp[day][state]!=-1){
            return dp[day][state];
        }
        if (buy){
            int take = solve (prices , day+1,n,false,profit,dp)-prices[day];// prfit = sell - buy
            int nottake=solve(prices , day+1 , n , true,profit,dp );
            profit= Math.max (profit ,Math.max(nottake , take));
        }
        else {
            int sell = solve (prices, day+2,n,true,profit,dp)+prices[day];
            int notsell=solve (prices, day+1,n,false,profit,dp);
            profit = Math.max (profit,Math.max (notsell , sell));
        }
        dp[day][state]= profit;

        return profit;
    }
}