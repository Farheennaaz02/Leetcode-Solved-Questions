public class Solution {
    public string MergeAlternately(string word1, string word2) {
        List <char > ans = new ();
        int len1= word1.Length ;
        int len2 = word2.Length;
        int maxlen = Math.Max ( len1 , len2);
        int i =0;
        int j =0;
        while (i<len1||j<len2){
            if (i<len1){
                ans.Add(word1[i]);
                i++;
            }
            if (j<len2){
                ans.Add(word2[j]);
                j++;
            }
        }
        return new string(ans.ToArray());
        
    }
}