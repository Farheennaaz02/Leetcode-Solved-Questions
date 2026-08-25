public class Solution {
    public int NumIslands(char[][] grid) {
        if ( grid==null|| grid[0].Length== 0|| grid.Length ==0){
            return 0;
        }
        int count =0;
        int  n = grid.Length ;
        int m = grid[0].Length ;
        for ( int i =0;i<n;i++){
            for ( int j=0;j<m;j++){
                if (grid[i][j]=='1'){
                    DFS(grid , i , j, n ,m);
                    count ++;
                }
             
            }
        }
        return count ;
        
    }
    void DFS (char [] []  grid , int i ,int j, int n , int m  ){
        if ( i<0||j<0||i>=n||j>=m||grid[i][j]=='0'){
            return ;
        }
        grid[i][j]='0';
        DFS ( grid , i+1 ,j,n,m);
        DFS ( grid , i-1,j,n,m);
        DFS ( grid , i, j-1,n,m);
        DFS ( grid , i, j+1,n,m);
    }
}