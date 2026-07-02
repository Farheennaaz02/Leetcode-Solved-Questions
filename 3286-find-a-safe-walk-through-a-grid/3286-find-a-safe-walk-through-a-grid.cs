public class Solution {
    public bool FindSafeWalk(IList<IList<int>> grid, int health) {
        if (  grid==null||grid.Count ==0|| grid[0].Count==0){
            return false ;
        }
        int row = grid.Count ;
        int col = grid[0].Count;
        int initialhealth = health-grid[0][0];
        if ( initialhealth<1){
            return false ;
        }
        bool [, , ] visited = new bool[row , col, health+1];
        Queue<(int r , int c,int  h )> queue= new ();
        queue.Enqueue((0 , 0, initialhealth) );
        visited[0,0, initialhealth]=true ;
        int [][] dimenstion = new int [][]{
            new int [] {1,0},
            new int []{0,1},
            new int [] {0,-1},
            new int []{-1,0}
        };
        while ( queue.Count >0){
            var (r, c, h)= queue.Dequeue();
            if ( r==row-1&& c==col-1&& h >=1){
                return true ;
            }
            foreach ( var dir in dimenstion){
                int nr = r +  dir[0];
                int nc = c+ dir[1];
                if (nr >=0&& nr<row &&nc >=0&& nc<col){
                    int nexthealth = h-grid [nr] [ nc ];
                    if ( nexthealth >=1&& !visited[nr, nc , nexthealth ]){
                        visited[ nr , nc , nexthealth]=true ;
                        queue.Enqueue((nr , nc , nexthealth ));
                    }
                }
            }
        }
        return false;
    }
}