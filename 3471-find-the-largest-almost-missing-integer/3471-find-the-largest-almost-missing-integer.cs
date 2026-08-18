public class Solution {
    public int LargestInteger(int[] nums, int k) {
        int  n = nums.Length;
        // appear exctly one time 
        // freq of all 
        Dictionary <int , int> freq= new ();
        foreach ( int i  in nums){
            if (!freq.ContainsKey(i)){
                freq[i]=1;
            }
            else {
                freq[i]++;

            }
            
        }
        //ager sara inout is single window 
        if (k==n){
            return nums.Max();
        }
        // ager sb alag alag window h 
        if (k==1){
            int ans =-1;
            foreach ( int i in nums){
                if (freq[i]==1){
                    ans=Math.Max(ans ,i);
                }
            }
            return ans ;
        }
        int left = nums[0];
        int right = nums[n-1];
        int max=-1 ;
        if (freq[left]==1){
            max = Math.Max(max , left);
        }
         if (freq[right]==1){
            max =Math.Max(max , right);
         }
        return max;
        
    }
}