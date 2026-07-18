public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        
        int n = nums.Length ;
        int [] result  = new int [n];
        int multi =1;
        int zerocount =0;
        for ( int i =0;i<n;i++){
            if ( nums[i]!=0){
                multi = multi* nums[i];
            }
            else {
                zerocount ++;
            }

        }
        for ( int  j =0;j<n;j++){
            if ( zerocount >1){
                result[j]=0;
            }
            else if ( zerocount==1){
                if (nums[j]==0){
                    result [j]= multi;
                }
                else {
                    result [j]= 0;
                }

            }
            else {
                result [j]= multi/ nums[j];
            }
        }
        return result ;

    }
}