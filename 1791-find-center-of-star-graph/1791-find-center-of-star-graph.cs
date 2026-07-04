public class Solution {
    public int FindCenter(int[][] edges) {
        //1,2
        //2,3  // 1=>2    || 1=>3  return 1
        //4,2
        if (edges[0][0]==edges[1][0]||edges[0][0]==edges[1][1]){
            return edges[0][0];
        }
        else{
            return edges[0][1];
        }
        
    }
}