using System.Linq;
public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
       /// int k=0;
        int n = nums.Length;
        HashSet<int>unique= new HashSet<int>(nums);
        List<int> result = new List<int>();
        for ( int i=1;i<=n;i++ ){
            if (!unique.Contains(i)){
                result.Add(i);
            }
           
        }
                    return result;

    }
}