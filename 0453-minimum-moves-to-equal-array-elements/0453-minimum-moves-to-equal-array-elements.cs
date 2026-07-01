public class Solution {
    public int MinMoves(int[] nums) {
        Array.Sort ( nums);
        int  n = nums.Length ;
        List <int > element=new ();
        int i =0;
        int j = n-1;
        while (j>0){
            int sum = nums[j]-nums[i];
            element.Add(sum );
            j--;
        }
        return element.Sum ();


        
    }
}