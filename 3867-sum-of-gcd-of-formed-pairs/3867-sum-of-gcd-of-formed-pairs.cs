public class Solution {
    public long GcdSum(int[] nums) {
        int max = int.MinValue ;
        long ans=0;
        int[] prefix = new int [nums.Length];
        for ( int  i =0;i< nums.Length ;i++){
            max = Math.Max ( nums[i],max);
            prefix[i]=GCD(nums[i],max);
        }
        Array.Sort (prefix);
        int left =0;
        int right= nums.Length -1;
        while( left <right){
            ans+= GCD(prefix[left], prefix [right]);
            left++;
            right--;
            
        }
        
        return ans;
    }
    private int GCD(int a , int b){
        while ( b!=0){
            int temp = b;
            b = a%b;
            a = temp;
        }
        return a ;
    }
}