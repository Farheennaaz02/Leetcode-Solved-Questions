class Solution {
    public int minEatingSpeed(int[] piles, int h) {
        int left=1;
        int right  =    Arrays.stream(piles).max ().getAsInt();
        while (  left<right){
            int mid = left+(right -left)/2;
            int hour =0;
            for( int i : piles){
                hour+=(i+mid-1)/mid;
            }
            if ( hour>h){
                left = mid +1;// speed increase
            }
            else {
                right = mid ;
            }
        }
        return left ;// right bhi kr sktt h 
        
    }
}