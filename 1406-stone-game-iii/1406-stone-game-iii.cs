public class Solution {
    int [] memo;
   
    public string StoneGameIII(int[] stoneValue) {
         int n = stoneValue.Length;
         memo =new int [n] ;
        Array.Fill(memo,-1);
        int diff= solve (0, stoneValue);
        if (diff>0){
            return "Alice";
        }
        else if(diff<0){
            return "Bob";
        }
        else{
            return "Tie";
        }

        
    }
    private int solve ( int i , int [] stoneValue ){
         int n = stoneValue.Length;
         
        if (i>=n){
            return 0;
        }
        if(memo[i]!=-1){
            return memo[i];
         }
        int result = stoneValue[i]-solve (i+1, stoneValue );
        if (i+1<n){
            result= Math.Max(result , stoneValue[i]+stoneValue[i+1]-solve (i+2,stoneValue));
        }
        if (i+2<n){
            result= Math.Max(result , stoneValue[i]+stoneValue[i+1]+stoneValue[i+2]-solve (i+3,stoneValue));
        }
        return memo[i]= result ;
    }
}