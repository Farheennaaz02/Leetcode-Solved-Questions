public class Solution {
    public int MissingMultiple(int[] nums, int k) {
        Dictionary<int , int> map = new();
        foreach ( int i in nums){
            map[i]=1;
        }
        int number =k;
        while(map.ContainsKey( number)){
            number = number+k;
        }
        return number ;
        
    }
}