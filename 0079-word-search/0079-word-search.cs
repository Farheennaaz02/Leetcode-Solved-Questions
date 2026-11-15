public class Solution {
    public bool Exist(char[][] board, string word) {
        int rows = board.Length;
        int col= board[0].Length ;
        
        for ( int  i =0;i<board.Length ; i++){
            for ( int  j =0;j<board[0].Length;j++){
                if ( DFS ( board ,word, i,j,0)){
                   return true;

                }
            }

        }
        return false ;
        
    }
    public bool DFS ( char [][] board ,  string word , int i , int j , int n ){
        if ( n == word.Length){
            return true ;
        }
        if( i <0|| j<0|| i >=board.Length ||j>=board[0].Length ||board[i][j]!=word[n] ){
            return false ;
        }
        char temp = board[i][j];
        board [i][j]= '#';
        bool found =
        DFS(board , word , i+1 , j , n+1)||
        DFS ( board , word , i-1 , j , n+1)||
        DFS ( board , word , i , j+1, n+1)||
        DFS ( board , word , i, j-1, n+1);
        board [i][j]= temp;
        return found;
    }
}