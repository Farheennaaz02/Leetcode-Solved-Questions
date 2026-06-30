public class Solution {
    public int[] FinalPrices(int[] prices) {
        List <int > result = new ();
        int n = prices.Length ;
        for ( int i =0;i<n;i++){
            bool found = false;
            for ( int j = i+1 ; j<n ;j++){
                if (prices[j]<=prices[i]){
                    found=true;
                    result.Add(prices[i]-prices[j]);
                    break;
                }
            }
            if (!found){
                result.Add(prices[i]);
            }
        }
        return result.ToArray ();
        
    }
}