public class Solution {
    public int LongestConsecutive(int[] nums) {
        
        int length =0;
        HashSet <int> set = new HashSet<int>( nums);
        foreach ( int n in set){
            if (!set.Contains(n-1)){
                int max =1;
                int current =n;
                while (set.Contains(current+1)){
                    max++;
                    current++;
                }
                length = Math.Max (max , length);



            }
            
        }
        return length;
        
    }
}