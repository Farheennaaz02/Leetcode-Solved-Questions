class Solution {
    public List<List<Integer>> combinationSum2(int[] candidates, int target) {
        Arrays.sort (candidates);
        List <List <Integer >> result = new ArrayList<>();
        List <Integer> path = new ArrayList <> ();
        solve ( candidates , target , 0 , result , path );
        return result ;
        
    }
    void solve ( int [] candidates, int target , int start , List<List<Integer>> result , List <Integer> path){
        if ( target ==0){
            result.add(new ArrayList <> (path));
            return ;
        }
        if ( target <0){
            return ;
        }
        for ( int i =start ; i<candidates .length ;i++){
            if (i>start && candidates[i]== candidates[i-1]){
                continue;
            }
            path.add(candidates[i]);
            solve ( candidates , target-candidates[i] , i+1 , result  , path );
            path.remove ( path.size()-1);
        }

    }
}