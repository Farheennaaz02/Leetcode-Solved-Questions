public class Solution {
    public int MajorityElement(int[] nums) {
        int n = nums.Length;
        Dictionary <int , int > freq= new ();
        foreach ( int num in nums){
            if (freq.ContainsKey(num)){
                freq[num]++;
            }
            else {
                freq[num]=1;
            }
        }
        int max = 0;
        int ans=0;
        foreach ( var pair in freq){
            if(pair.Value>max){
                max= pair.Value;
                ans =pair.Key;
            }
            
        }

        return ans;
        
    }
}