public class Solution {
    public int[] GetConcatenation(int[] nums) {
        int n = nums.Length ;
        int length= 2*n; 
        int [] result = new int [length];
        int i=0;
        int j =0;
        while ( i<n){
            result [i]= nums [i];
            i++;
        }
        while ( j <n){
            result [n+j]= nums [j];
            j++;
        }
        return result ;
        
    }
}