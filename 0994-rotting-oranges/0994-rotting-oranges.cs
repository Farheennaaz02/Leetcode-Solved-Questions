public class Solution {
    public int OrangesRotting(int[][] grid) {
        int row = grid.Length ;
         int col = grid[0].Length ;
         Queue<(int row , int col) > queue = new ();

         int fresh =0;
        for ( int i =0;i<row ;i++){
            for ( int j =0;j<col ;j++){
                if (grid[i][j]==2){
                    queue.Enqueue((i,j));
                    
                }
                else if ( grid[i][j]==1){
                    fresh ++;
                }
            }
        }
        if ( fresh ==0){
            return 0;
        }
        int min =0;
        int [][] direction = 
        {
            new int [] {-1,0},
            new int []{1,0},
            new int [] {0,-1},
            new int []{0,1}
        };

        while (queue.Count >0 && fresh>0){
            int size = queue.Count();
            for ( int i =0;i<size ;i++){
                var (rows , cols )= queue.Dequeue();
                foreach ( int [] din in direction ){
                    int newrow = rows+din[0];
                    int newcol = cols +din[1];
                    if  ( newrow <0|| newrow>=row || newcol <0 || newcol >= col || grid[newrow][newcol]!=1){
                        continue ;
                    }
                    grid[newrow][newcol]=2;
                    fresh --;
                    queue.Enqueue ( ( newrow , newcol));

                }
            }
            min ++;

        }
        return fresh==0? min :-1;
        
    }
}