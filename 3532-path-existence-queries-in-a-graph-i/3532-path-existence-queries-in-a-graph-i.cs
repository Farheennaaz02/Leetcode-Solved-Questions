public class Solution {
    public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries) {
        int [] component = new int [nums.Length];
        int id =0;
        component[0]=id;
        for ( int i =1;i<n;i++){
            if ( nums[i]-nums[i-1]>maxDiff){
                id ++;
            }
            component[i]=id;
        }
        bool [] ans = new bool [queries.Length];
        for ( int i =0;i<queries.Length;i++){
            int  u = queries[i][0];
            int v = queries[i][1];
            ans[i]= component[u]==component[v];
        }
        return ans;
        
    }
}