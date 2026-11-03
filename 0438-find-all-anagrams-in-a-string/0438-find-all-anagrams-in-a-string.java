class Solution {
    public List<Integer> findAnagrams(String s, String p) {
        int k = p.length();
        int n = s.length();
        int [] freq = new int[26];
        for ( int i =0;i<k;i++){
            freq[p.charAt(i)-'a']++;
        }
        int left =0;
        int right =0;
        List <Integer> ans = new ArrayList <>();
        while (right <n){
            freq[s.charAt(right)-'a']--;
            if (right-left+1==k){
                boolean found = true;
                for ( int j=0;j<26;j++){
                    if (freq[j]!=0){
                        found= false ;
                    }
                }
                if (found){
                    ans.add(left);
                }
                freq[s.charAt(left)-'a']++;
                left++;
            }
            right ++;
        }
        return ans ;
        
    }
}