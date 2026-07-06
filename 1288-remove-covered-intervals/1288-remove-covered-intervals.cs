public class Solution {
    public int RemoveCoveredIntervals(int[][] intervals) {
        int n = intervals.Length;
        int count =0;
        Array.Sort(intervals,(a,b)=>
        {
        if (a[0]==b[0]){
            return b[1].CompareTo(a[1]);
        }
        return a[0].CompareTo(b[0]);});
        int maxend=intervals[0][1];
        for ( int i =1;i<n ;i++){
            int currentpair = intervals[i][1];
            
            if (currentpair<=maxend  ){
                count ++;
            }
            else {
                maxend = currentpair;
            }
        }
        return n-count;


        
    }
}