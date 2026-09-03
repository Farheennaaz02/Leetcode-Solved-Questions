public class Solution {
    public bool UniformArray(int[] nums1) {
        // kabh bhi all even ho hi nhi ayege bs tb 
        // ho payege jb sb even ho 
        int min = nums1.Min();// minimum 
        if ( min%2!=0){// ager min hi odd h toh sb odd bana skte h 
            return true ;
        }
       
        foreach ( int num in nums1){// ager ek bhi odd mila toh nhi ho payega 
            if ( num%2!=0){
                return false  ;
            }
        }
        return true;// all even 

        
    }
}