public class Solution {
    public IList<int> FindMissingElements(int[] nums) {
        List <int > ans = new ();
        HashSet <int > map =new(nums);
        int min = nums.Min ();
        int max = nums.Max();
        for ( int i =min ; i<max;i++){
            if (!map.Contains(i)){
                ans.Add(i);

            }
        }
        return ans;
        

        
    }
}