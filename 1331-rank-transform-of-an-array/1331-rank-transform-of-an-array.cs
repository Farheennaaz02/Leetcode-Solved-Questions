public class Solution {
    public int[] ArrayRankTransform(int[] arr) {
        // arr =[40,10,20 30]
        int n = arr.Length;
        int[] sorted = ( int[])arr.Clone();
        Array.Sort (sorted);
        int rank =1;

        Dictionary <int, int > map = new ();
        foreach ( int number in sorted ){
            if (!map.ContainsKey(number)){
                map[number]= rank;
                rank++;
            }
        }
        int [] result = new int [n];
        for ( int i =0;i<n;i++){
            result[i]= map[arr[i]];
        }
        return result ;
        
    }
}