public class Solution {
    public int CountMajoritySubarrays(int[] nums, int target) {
        int   n = nums.Length ;
        int answer =0;
        for ( int i=0;i<n;i++){
            int count =0;
            for ( int j=i;j<n;j++){
                if ( nums[j]==target ){
                    count ++;

                }
                int length = j-i+1;
                if (count  > length/2){
                    answer ++;
                }

            }

        }
        return answer ;
        
    }
}