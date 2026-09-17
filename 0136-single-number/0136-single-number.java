class Solution {
    public int singleNumber(int[] nums) {
        // xor 
        // same -> 0
        // differnt - >1
        int ans =0;
        for ( int num : nums){
            ans^=num;
        }
        
        return ans ;
    }
}