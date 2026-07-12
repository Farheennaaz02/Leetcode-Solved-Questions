public class Solution {
    public int MaxProfit(int[] prices) {
        int len = prices.Length;
        int min = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < len; i++) {
            if (prices[i] < min) {
                min = prices[i];   // naya minimum update
            } else {
                int profit = prices[i] - min;
                if (profit > maxProfit) {
                    maxProfit = profit;   // best profit update
                }
            }
        }

        return maxProfit;
    }
}
