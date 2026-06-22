public class Solution {
    public string LargestNumber(int[] nums) {
        Array.Sort ( nums , (a,b)=>
        {
        string ab = a.ToString()+b.ToString ();
        string ba = b.ToString()+a.ToString();
        return  ba.CompareTo(ab);
        });
        if ( nums[0]==0){
            return"0";
        }
        return String.Join ("",nums);
        
    }
}