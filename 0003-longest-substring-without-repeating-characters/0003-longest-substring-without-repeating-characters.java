class Solution {
    public int lengthOfLongestSubstring(String s) {
        // maximum 
        int left =0;
        HashSet <Character > map = new HashSet<>();
        int ans =0;
        for ( int right =0;right <s.length();right++){
            while (map.contains(s.charAt(right))){
                map.remove (s.charAt(left));
                left++;
            }
            if (!map.contains(s.charAt(right))){
                map.add(s.charAt(right ));
                ans= Math.max(ans , right-left+1);
            }
            
        }
        return ans ;
    }
}