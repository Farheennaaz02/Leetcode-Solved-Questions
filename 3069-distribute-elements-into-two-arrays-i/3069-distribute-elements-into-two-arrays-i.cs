
public class Solution {
    public int[] ResultArray(int[] nums) {
        int n = nums.Length ;
        int [] arr1 = new int [n];
        int [] arr2=new int [n];
        arr1[0]= nums[0];
        arr2[0]= nums[1];
        int index =1;
        int index2 = 1;
        for ( int i =2;i<n;i++){
            
           
            if (arr1[index-1]> arr2[index2-1]){
                arr1[index]=nums[i];
                index ++;
            }
            else {
                arr2[index2]=nums[i];
                index2++;
            }


        }
        int [] result = new int [n];
        for ( int i =0;i<index;i++){
            result[i]= arr1[i];
        } 
        for ( int j =0;j<index2;j++){
            result[index+j]=arr2[j];
        }
        return result ;
      
        
        
    }
}