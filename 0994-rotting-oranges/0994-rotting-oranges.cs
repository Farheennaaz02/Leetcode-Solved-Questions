public class Solution {
    public int OrangesRotting(int[][] grid) {
        int m = grid.Length ;
        int n =  grid[0].Length ;
        Queue<(int row , int col , int min)> q = new ();
        int fresh =0;
        for ( int i=0;i<m ;i++){
            for ( int j =0;j<n;j++){
                if (grid[i][j]==2){
                    q.Enqueue((i ,j ,0));
                }
                else if( grid[i][j]==1){
                    fresh ++;
                }
            }
        }
        int ans =0;
        int [][] dimenstion ={
            new int [] {-1,0},
            new int [] {1,0},
            new int [] {0,1},
            new int []{0,-1}
        };
        while ( q.Count >0){
            var current = q.Dequeue();
            int row = current.row ;
            int col =  current.col;
            int min = current.min;
            foreach ( int [] dim in dimenstion ){
                int newrow = row +dim[0];
                int newcol = col+dim[1];
                if ( newrow>=0&& newcol >=0&& newrow <m && newcol <n&&  grid [newrow ][newcol]==1){
                    grid[newrow][newcol]=2;
                    fresh --;
                    q.Enqueue((newrow, newcol , min +1));
                    ans =min +1;

                }
            }
            
        }       
        if ( fresh >0){
            return -1 ;
        }
        return ans;
    }
}