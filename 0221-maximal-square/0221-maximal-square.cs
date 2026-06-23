public class Solution {
    public int MaximalSquare(char[][] matrix) {
        int row = matrix.Length;
        int col = matrix[0].Length ;
        int count =0;
        int [,]dp= new int [row , col];
        for ( int i =0;i<row ;i++){
            for ( int j =0;j<col  ;j++){
                if (matrix[i][j]=='1'){
                    if ( i==0||j==0){
                        dp[i,j]=1;
                    }
                    else {
                        dp[i,j]=1+Math.Min (Math.Min (dp[i,j-1],dp[i-1,j]),dp[i-1,j-1]);
                        
                    }
                    count =Math.Max ( count , dp[i,j]);
                    

                }
                
            }
        }
        return count *count ;

        
    }
}