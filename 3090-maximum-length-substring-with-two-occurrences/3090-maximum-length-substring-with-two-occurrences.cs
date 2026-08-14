public class Solution {
    public int MaximumLengthSubstring(string s) {
        // at most => jayada se jyada 
        // hr character k bs 2 ya 2 se km 
        Dictionary <char , int > freq= new ();
        int max =0;
        int left =0;
        for ( int right =0;right<s.Length ;right++){
            if (freq.ContainsKey(s[right])){
                freq[s[right]]++;
            }
            else{
                freq[s[right]]=1;
            }
            while (freq[s[right]]>2){
                freq[s[left]]--;
                left++;
            }
            max = Math.Max(max, right - left +1);
        
        }
        return max ;

        
        
    }
}