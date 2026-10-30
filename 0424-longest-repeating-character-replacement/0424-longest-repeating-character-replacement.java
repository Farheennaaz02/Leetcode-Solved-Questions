class Solution {
    public int characterReplacement(String s, int k) {
        int [] freq = new int [26];
        int left =0;
        int maxfreq= 0 ; 
        int longest =0;
        for (int right =0;right<s.length();right++){
            freq[s.charAt(right)-'A']++;
            maxfreq = Math.max (maxfreq, freq[s.charAt(right)-'A']);
            while  ((right - left+1)-maxfreq>k){
                freq[s.charAt(left)-'A']--;
                left ++;

            }
            longest = Math.max (right-left+1 , longest);
        }
        
        return longest ;
    }
}