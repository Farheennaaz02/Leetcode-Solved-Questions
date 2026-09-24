class Solution {
    public int[] productExceptSelf(int[] nums) {
        int zerocount =0;
        int totalproduct=1;
        int [] ans = new int [nums.length];
    
        for (int i =0;i<nums.length;i++){
            if (nums[i]==0){
                zerocount ++;
            }
            else {
                 totalproduct*=nums[i];

            }
           
        }
        for ( int i =0;i<nums.length ;i++){
            if (zerocount >1){
                ans[i]=0;
            }
            else if (zerocount==0){
                ans[i]=(totalproduct/nums[i]);
            }
            else {
                if (nums[i]==0){
                    ans[i]= totalproduct;
                }
                else{
                    ans[i]=0;
                }
            }
        }
        return ans ;
        
        
    }
}