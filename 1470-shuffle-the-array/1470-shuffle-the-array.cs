public class Solution {
    public int[] Shuffle(int[] nums, int n) {
        int length = nums.Length ;
        int i =0;
        int j =n;
        List<int > result = new ();
        while ( i<n){
            result.Add(nums[i]);
            result.Add(nums[j]);
            i++;
            j++;
        }
        return result.ToArray ();

        
    }
}