public class Solution {
    public int TimeRequiredToBuy(int[] tickets, int k) {
        int time =0;
        for ( int i =0;i<tickets.Length;i++){
            if ( i <=k){
                time+=Math.Min (tickets[i],tickets[k]);
            }
            else{
                time +=Math.Min(tickets[i],tickets[k]-1);
            }
        }
        return time;
        
    }
}