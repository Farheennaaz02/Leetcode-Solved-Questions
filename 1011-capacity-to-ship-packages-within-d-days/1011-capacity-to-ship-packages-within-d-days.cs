public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        // left ---------right
        int left =0;// lesser
        int right = 0;// greater
        foreach (int i in weights){
            left = Math.Max (left , i);
            right +=i;
        }
        while ( left <right){
            int mid = (left +right)/2;
            int day =1;
            int sum =0;
            foreach ( int i in weights){

                if ( sum +i>mid){
                    day++;
                    sum=0;
                }
                sum+=i;
            }
            if (day>days){
                left= mid+1;
            }
            else {
                right = mid ;
            }

        }
        return left;
    }
}