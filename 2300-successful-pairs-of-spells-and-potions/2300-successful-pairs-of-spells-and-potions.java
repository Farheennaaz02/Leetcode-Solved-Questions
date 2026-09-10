import java.util.Arrays;
class Solution {
    public int[] successfulPairs(int[] spells, int[] potions, long success) {
        Arrays.sort (potions);
        int [] ans = new int [spells.length ];
        for ( int i =0;i<spells.length;i++){
            int left =0;
            int right = potions.length-1;
            while ( left <= right){
                int mid = left+(right - left)/2;
                long product= (long) spells[i]*potions[mid];
                if (product >= success){
                    // km krna pdega 
                    right = mid -1;
                }
                else {
                    left = mid +1;
                }
                ans[i]= potions.length - left ;// left beacuse vo chte honge 

            }
        }
        return ans;

        
    }
}