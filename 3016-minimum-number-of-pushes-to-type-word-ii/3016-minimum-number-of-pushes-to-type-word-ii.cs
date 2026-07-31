public class Solution {
    public int MinimumPushes(string word) {
        // frequences 
        int [] freq = new int [26];
        foreach (char ch in word){
            freq[ch-'a']++;
        }
        // sort 
        Array.Sort(freq);
        Array.Reverse (freq);
        int ans=0;
        for (int i=0;i<freq.Length;i++){
            ans +=freq[i]*((i/8)+1);
        }
        return ans ;
    }
}