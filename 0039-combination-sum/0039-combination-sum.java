class Solution {
    public List<List<Integer>> combinationSum(int[] candidates, int target) {
        List<List<Integer>> ans  = new ArrayList<>();
        List<Integer > path = new ArrayList <> ();
        solve (candidates , target , 0 , ans , path );
        return ans ;
    }
    void solve (int [] candidates , int target , int start , List<List <Integer>> ans , List <Integer> path){
        if ( target==0){
             ans.add(new ArrayList<>(path));
             return ;
        }
        if ( target <0){
            return ;
        }
        for (int i =start ;i<candidates.length;i++){
            path.add(candidates[i]);
            solve (candidates , target- candidates[i],i , ans , path );
            path.remove (path.size ()-1);
        }
        
    }
}