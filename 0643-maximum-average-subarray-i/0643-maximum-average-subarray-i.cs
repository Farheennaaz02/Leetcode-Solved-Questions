public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        int sum =0;
        for ( int i=0;i<k;i++){
            sum+=nums[i];
        }
        int max = sum ;
        for ( int i =k;i<nums.Length;i++){
            sum+=nums[i];
            sum-=nums[i-k];
            max= Math.Max(sum , max);
        }
        return (double)max/k;
        
    }
}