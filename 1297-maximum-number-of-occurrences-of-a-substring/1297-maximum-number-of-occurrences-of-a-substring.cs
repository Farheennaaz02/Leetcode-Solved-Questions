public class Solution {
    public int MaxFreq(string s, int maxLetters, int minSize, int maxSize) {

        Dictionary <string , int > substringcount = new ();
        Dictionary <char , int > charcount = new ();
        int left =0;
        int ans =0;
        // frequncies
        for ( int i =0;i<s.Length ;i++){
            char ch = s[i];
            if (!charcount.ContainsKey(ch)){
                charcount[ch]=0;
            }
            charcount[ch]++;
            // sliding window 
        if (i-left+1>minSize){
            // banda hogya nhi chahiye 
            char leftelement =s[left];
            charcount[leftelement]--;
            if (charcount[leftelement]==0){
                charcount.Remove (leftelement);
            }
            left++;
        }
        if (i-left+1==minSize){
            // yeh chahiye
            if (charcount.Count <=maxLetters){
                string sb = s.Substring (left , minSize);
                if (!substringcount.ContainsKey(sb)){
                    substringcount[sb]=0;
                }
                substringcount[sb]++;
                ans= Math.Max (ans , substringcount[sb]);
            }
            

        }
        }
        
        return ans ;
    }
}