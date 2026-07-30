public class Solution {
    public int MinimumPushes(string word) {
        int ans =0;
        for ( int i =0;i<word.Length ;i++){
            ans += (i/8)+1;

        }
        return ans ;
        
    }
}