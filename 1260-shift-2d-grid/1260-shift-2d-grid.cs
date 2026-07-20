public class Solution {
    int [] [] grid;
    int row ;
    int col;
    // z => total 
   
       
    public IList<IList<int>> ShiftGrid(int[][] grid, int k) {
            this.grid= grid;
          row = grid.Length ;
         col = grid[0].Length ;
          int z = row * col;
        
        k =k%z;
        if ( k!=0){
            reverse (0,z-1);
            reverse (0,k-1);
            reverse (k, z-1);

        }
        IList <IList<int >> ans =  new List <IList<int>>();
        foreach ( var element in grid){
            ans.Add(element.ToList());
        }
        return ans;
    }
    private void reverse(int i , int j ){
          
        while (i<j){
            int temp = grid [i/col][i%col];
            grid[i/col][i%col]= grid [j/col][j%col];
            grid[j/col][j%col]= temp;
            i++;
            j--;

        }
    }
}