class Solution {
    int m ;
    int n ;
    boolean[][][] visited;                                   // ADDED

    public boolean hasValidPath(char[][] grid) {
          m = grid.length;
         n = grid[0].length;
        if (grid[0][0]==')'|| grid [m-1][n-1]=='('){        // CHANGED: last cell must be ')'
            return false;
        }

        
        if ((m+n-1)%2==1){
            return false ;
        }
        visited = new boolean[m][n][m+n];                    // ADDED
        return solve (0  , 0 ,0, grid);
        
        
    }
    boolean solve(int i ,int j , int opencount , char [][] grid){
        if (i>=m|| j>=n){
            return false;
        }
        if (grid[i][j]=='('){
            opencount +=1;
        }
        else {
            opencount-=1;
        }
        if (opencount<0){
            return false ;
        }
        if (i==m-1 && j == n-1){
            return opencount ==0;
        }

        if (visited[i][j][opencount]) return false;          // ADDED: already tried, it failed
        visited[i][j][opencount] = true;                     // ADDED
        
        if (solve (i+1,j,opencount , grid)==true ){
            return true ;
        } 
        if (solve (i,j+1,opencount , grid)==true ){
            return true ;
        }
        return false   ;
    } 
}