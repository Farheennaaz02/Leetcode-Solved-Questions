public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int maxsum=0;
        
        int n = grid.Length;
        int m = grid[0].Length ;
        for ( int i =0;i<n;i++){
            
            for ( int j =0;j<m;j++){
                int currentsum =0;
                if ( grid[i][j]==1){
                currentsum=  DFS ( grid , i , j , m ,n,currentsum );
                maxsum= Math.Max(maxsum , currentsum);
                    
                }
               
              
              
            }
        }
        return maxsum ;
        
    }
    int DFS (int [][] grid , int i , int j , int m ,int  n,int currentsum){
        if (i<0||j<0||i>=n||j>=m||grid[i][j]==0){
            return currentsum;
        }
        grid[i][j]=0;
        currentsum++;
      currentsum =  DFS (grid , i+1 , j , m, n,currentsum);
        currentsum = DFS ( grid, i-1,j,m,n,currentsum);
        currentsum = DFS (grid , i, j-1 , m,n,currentsum);
        currentsum = DFS (grid,i,j+1,m,n,currentsum);
        return currentsum ;
    }
}