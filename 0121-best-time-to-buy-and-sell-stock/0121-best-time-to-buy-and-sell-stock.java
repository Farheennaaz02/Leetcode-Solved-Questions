class Solution {
    public int maxProfit(int[] prices) {
        int min = Integer.MAX_VALUE;
        int profit =0;
        for (int i =0;i<prices.length;i++){
             min = Math.min(min , prices[i]);
             int x= prices[i]-min;
             profit = Math.max(profit , x);
        }
        return profit ;
        
    }
}