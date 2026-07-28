public class Solution {
    public string SmallestPalindrome(string s) {

        if (s.Length==1){
            return s;
        }
        char mid  = '\0';
        Dictionary <char , int > freq = new ();
        foreach ( char ch in s){
            if (freq.ContainsKey(ch)){
                freq[ch]++;
            }
            else {
                freq[ch]=1;
            }
        }
        foreach( var item in freq){
            if (item.Value%2!=0){
                 mid = item.Key;
            }
        }
        StringBuilder left =new ();
        for ( char ch ='a';ch<='z';ch++){
            if (freq.ContainsKey(ch)){
                for (int i =0;i<freq[ch]/2;i++){
                    left.Append(ch);
                }

            }
            
        }
        string right =new string (left.ToString().Reverse ().ToArray ());
        if (mid=='\0'){
            return left.ToString()+right ;
        }
        else {
            return left.ToString()+mid+right;
        }
        
        
    }
}