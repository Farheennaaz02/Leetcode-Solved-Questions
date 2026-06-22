public class Solution {
    public int MaxNumberOfBalloons(string text) {
        int []  freq = new int [26];
        foreach ( char ch in text){
            freq[ch-'a']++;
        }
        int b= freq['b'-'a'];
        int a =freq['a'-'a'];
        int l = freq['l'-'a']/2;
        int o = freq['o'-'a']/2;
        int n = freq['n'-'a'];
        int ans = b;
        ans = Math.Min ( ans , a);
        ans  = Math.Min ( ans , l);
        ans = Math.Min (ans , o);
        ans = Math.Min ( ans , n );
        return ans ;
        
    }
}