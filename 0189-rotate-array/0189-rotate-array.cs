public class Solution {
    public void Rotate(int[] nums, int k) {
        int n = nums.Length ;
        k%=n;
        int [] result = new int [n];
        int index =0;
        for ( int i =n-k;i<n;i++){
            result[index]= nums[i];
            index++;
        }
        for ( int i=0;i<n-k;i++){
            result[index]= nums[i];
            index ++;
        }
        for ( int i =0;i<n ;i++){
            nums[i]= result [i];
        }
    }
}