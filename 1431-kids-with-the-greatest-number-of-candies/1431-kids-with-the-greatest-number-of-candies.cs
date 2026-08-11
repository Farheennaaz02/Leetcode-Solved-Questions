public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        int maximum= candies.Max();
        bool[] ans = new bool[candies.Length];
        for ( int i =0;i<candies.Length;i++){
            if (candies[i]+extraCandies >= maximum){
                ans[i]=true ;
            }
            else {
                ans[i]= false;
            }


        }
        return ans ;
        
    }
}