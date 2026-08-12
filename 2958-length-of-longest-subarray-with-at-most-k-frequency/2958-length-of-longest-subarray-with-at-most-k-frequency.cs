public class Solution {
    public int MaxSubarrayLength(int[] nums, int k) {
        Dictionary <int, int > freq = new ();
        int left =0;
        int ans =0;
        
        for ( int right =0;right <nums.Length ;right ++){
            if (!freq.ContainsKey(nums[right ])){
                freq[nums[right ]]=0;
            }
            freq[nums[right]]++;
            while  (freq[nums[right]]>k){
            freq[nums[left]]--;
            left++;
           
        }
         ans = Math.Max (ans , right -left +1);
            
        }
       
        
        
        return ans;
        

        

        
    }
}