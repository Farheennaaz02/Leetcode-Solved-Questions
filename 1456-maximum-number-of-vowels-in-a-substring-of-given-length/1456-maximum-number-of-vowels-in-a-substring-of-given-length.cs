public class Solution {
    public int MaxVowels(string s, int k) {
        // fixed size sliding window 
        int count =0;
        
        for ( int i =0;i<k;i++){
            if(s[i]=='a'||s[i]=='e'||  s[i]=='i'||s[i]=='o'||s[i]=='u'){
                count ++;
            }

        }
        int maxcount = count ;
        for ( int i=k;i<s.Length ;i++){
            if(s[i]=='a'||s[i]=='e'||  s[i]=='i'||s[i]=='o'||s[i]=='u'){
                count++;

            }
            if(s[i-k]=='a'||s[i-k]=='e'||s[i-k]=='i'||s[i-k]=='o'||s[i-k]=='u'){
                count --;
            }
            if (count > maxcount){
                maxcount = count ;
            }

        }
        return Math.Max(maxcount , count );
    }
}