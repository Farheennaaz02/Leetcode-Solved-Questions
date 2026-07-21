public class Solution {
    public int MaxActiveSectionsAfterTrade(string s) {

        List <int > zerolength = new ();
        int i=0;
        int ones =0;
        while (i<s.Length){
            int j =i;
            while (j<s.Length && s[j]==s[i]){
                j++;

            }
            int len = j-i;
            if (s[i]=='1'){
                ones+=len;
            }
            else {
                zerolength.Add(len);
            }
            i=j;
        }
        int maxsum =0;
        for ( int k =0;k+1 <zerolength.Count;k++){
            maxsum = Math.Max(maxsum ,zerolength[k]+zerolength[k+1]);
        }
        return ones+maxsum ;
    }
}