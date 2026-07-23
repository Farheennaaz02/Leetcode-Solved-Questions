public class Solution {
    public int UniqueXorTriplets(int[] nums) {
        // same number ka 0
        // 2 xor 2 => 0
        // 2 xor 0=> 2
        // 2xor 1=> 1

        // nums = [1,2]
        //         0 1
        // indexing 
        // nums=[1]
        // 
        int n = nums.Length ;

        if (  n<=2){
            return n ;
        }
        int ans =1;
        while ( ans<=n){
            ans<<=1;
        }
        return ans ;

        

    }
}