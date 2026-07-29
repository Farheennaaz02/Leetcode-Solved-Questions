public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary <int , int > map= new ();
        for ( int i =0;i<nums.Length;i++){
            int current = nums[i];
            int need = target - current ;
            if (map.ContainsKey(need)){
                return new int [] {map[need],i};
            }

            map[current ]=i;
        }
        return new int [0];

        
    }
}