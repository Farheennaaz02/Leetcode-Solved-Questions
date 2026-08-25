public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        // 0 nd 1 
        int  n= isConnected.Length ;
        int province=0;
        for ( int i =0;i<n;i++){
                if (isConnected[i][i]==1){
                    DFS (isConnected , i ,n);
                    province++;
                }
        }
        return province;
        
    }
    void DFS (int [] [] isConnected , int i,int n){
        isConnected[i][i]=0;
        for ( int j =0;j<n;j++){
            if (isConnected[i][j] == 1 && isConnected[j][j] == 1){
                DFS (isConnected , j ,n);
            }
        }
    }
}