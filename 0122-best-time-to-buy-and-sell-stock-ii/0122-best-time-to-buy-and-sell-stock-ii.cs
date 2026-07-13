public class Solution {
    public int MaxProfit(int[] prices) {
        int maxProfit=0;
        int len = prices.Length;
        for ( int i =1;i<len;i++){
            if ( prices[i]>prices[i-1]){
                maxProfit=maxProfit+ prices[i]-prices[i-1];
            }

        }
        return maxProfit;
    }
}