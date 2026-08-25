public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        int orig= image[sr][sc];
        int newcolor= color;
        if (orig==newcolor){
            return image;
        }
        int m= image.Length ;
        int n = image[0].Length;
        DFS ( image , sr , sc ,orig ,color ,m,n );
        return image ;

        
    }
    
    void DFS ( int [][] image , int i , int j , int orig,int newcolor, int m ,  int n){
        if ( i<0||  j <0|| i >=m|| j >=n|| image[i][j]!=orig||orig== newcolor){
            return ;
        }
        image[i][j]= newcolor;
        DFS ( image , i-1, j , orig, newcolor,m,n);
        DFS( image , i+1, j , orig, newcolor,m,n);
        DFS( image , i, j-1 , orig, newcolor,m,n);
        DFS( image , i, j+1 , orig, newcolor,m,n);


    }


}