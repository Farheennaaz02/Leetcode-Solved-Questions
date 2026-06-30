public class Solution {
    public int NumberOfSubstrings(string s) {
        int n = s.Length ;
        int result =0;
        int [] map = new int [3];
        int i =0;
        int j =0;
        while ( j <n){
            char ch = s[j];
            map[ch-'a']++;
            while ( map[0]>0&& map[1]>0&& map[2]>0){
                result +=  n -j;
                map[s[i]-'a']--;
                i++;
            }
            j++;
        
        }
        return result;
        
    }
}