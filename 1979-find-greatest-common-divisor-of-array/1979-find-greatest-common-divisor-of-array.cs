public class Solution {
    public int FindGCD(int[] nums) {
        Array.Sort (nums);
        int a = nums[0];
        int b = nums[nums.Length -1];
        while ( b!=0){
            int temp = b;
            b=a%b ;
            a= temp ;

        }
        return a ;
        
    }
}