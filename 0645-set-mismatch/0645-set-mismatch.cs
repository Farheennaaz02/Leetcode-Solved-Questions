public class Solution {
    public int[] FindErrorNums(int[] nums) {
        HashSet <int > set =  new ();
        int duplicate =-1;
        int missing = -1 ;
        foreach ( int num in nums){
            if ( set.Contains(num )){
                duplicate= num ;
            }
            set.Add( num );
        }
        for ( int i =1;i<=nums.Length ; i++){
            if (!set.Contains(i)){
                missing = i;
                break;

            }
        }
        return new int [] {duplicate , missing };
    }
}