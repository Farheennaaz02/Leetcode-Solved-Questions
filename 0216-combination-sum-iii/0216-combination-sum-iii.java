class Solution {
    public List<List<Integer>> combinationSum3(int k, int n) {
        List<List<Integer>> result = new ArrayList<>();
        List<Integer> path = new ArrayList<>();
        solve ( k , n , 1,result , path );
        return result ;
        
    }
    void solve ( int k , int target , int start , List<List<Integer>> result , List<Integer> path){
        if (k==0 && target ==0){
            result.add(new ArrayList<>(path));
            return;
        }
        if (k==0||target<0){
            return ;
        }
        for ( int i =start ;i<=9;i++){
            path.add(i);
            solve (k-1, target-i , i+1 , result , path);
            path.remove ( path.size()-1);
        }
    }
}