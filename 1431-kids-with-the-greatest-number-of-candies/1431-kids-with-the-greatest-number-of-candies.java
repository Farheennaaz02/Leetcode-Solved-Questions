class Solution {
    public List<Boolean> kidsWithCandies(int[] candies, int extraCandies) {
        int largest = candies[0];
        for (  int i =0;i<candies.length ;i++){
            if (candies[i]>largest){
                largest = candies[i];
            }
        }
        List<Boolean> ans = new ArrayList<>(candies.length);
        for ( int i=0;i<candies.length ;i++){
            if (candies[i]+extraCandies>=largest){
                ans.add(true) ;
            }
            else{
                ans.add( false) ;
            }
        }
        return ans ;
    }
}