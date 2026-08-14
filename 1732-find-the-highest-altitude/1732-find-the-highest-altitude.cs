public class Solution {
    public int LargestAltitude(int[] gain) {
        int ele =0;
        int max =0;
        for ( int i =0;i<gain.Length;i++){
            ele+=gain[i];
            max= Math.Max(max , ele);
        }
        return max;
        
    }
}