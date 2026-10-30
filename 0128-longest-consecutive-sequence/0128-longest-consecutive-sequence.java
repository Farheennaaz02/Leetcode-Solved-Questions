class Solution {
    public int longestConsecutive(int[] nums) {
        HashSet <Integer > set = new HashSet <>();
        for ( int num : nums){
            set.add(num);
        }
        int ans =0;
        for ( int i:set){
            if (!set.contains(i-1)){
                int count =1;
                int current = i;
                while (set.contains(current+1 )){
                    count ++;
                    current++;
                }
                ans = Math.max (ans , count );
            }
        }
        return ans ;
    }
}