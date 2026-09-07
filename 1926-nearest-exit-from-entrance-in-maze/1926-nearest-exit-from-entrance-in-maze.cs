public class Solution {
    public int NearestExit(char[][] maze, int[] entrance) {
        // define 
        int m = maze.Length ;
        int n = maze[0].Length ;
        Queue<( int row ,int col , int steps )> q= new ();
        q.Enqueue((entrance[0],entrance[1],0));
        maze[entrance[0]][entrance[1]]='+';// visited
        int [][] dimenstions = {new int [] {-1,0},new int [] {1,0},new int[]{0,-1},new int []{0,1}};
        while (q.Count >0){
            var current = q.Dequeue ();
            int row = current.row ;
            int col = current.col;
            int step = current.steps;
            foreach ( int [] dir in dimenstions){
                int newrow = row+dir[0];
                int newcol = col+dir[1];
                if (newrow >=0&& newcol>=0&& newrow<m&&newcol<n&& maze[newrow][newcol]=='.'){
                    if (newrow==0|| newrow==m-1||newcol==0|| newcol==n-1){
                        return step+1;
                    }
                    maze[newrow][newcol]='+';
                    q.Enqueue((newrow , newcol , step+1));

                }

            }
        }
        return  -1;
        
    }
}