class Solution {
    public int longestOnes(int[] nums, int k) {
        int left =0;
        int maxlen=-1;
        for ( int i =0;i<nums.length ;i++){
            if (nums[i]==0){
                k--;
            }
            while (k<0){
                if (nums[left]==0){
                    k++;
                }
                left++;
               
            }
            maxlen= Math.max(maxlen ,i-left+1);
           
        }
        return maxlen ;
        
    }
}