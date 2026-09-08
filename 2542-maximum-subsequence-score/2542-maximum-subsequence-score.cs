public class Solution {
    public long MaxScore(int[] nums1, int[] nums2, int k) {
        int n = nums1.Length;
        var pair= new ( int n1, int n2)[n];
        for ( int  i =0;i<n;i++){
            pair[i]= (nums1[i], nums2[i]);// all pair done 
        } 
        Array.Sort (pair, (a,b)=> b.n2.CompareTo(a.n2));
        PriorityQueue<int , int > pq = new ();
        long sum =0;
        long ans=0;
        foreach (var gro in pair){
            pq.Enqueue(gro.n1, gro.n1);
            sum+=gro.n1;
            if (pq.Count >k){
                sum-=pq.Dequeue();
            }
            if (pq.Count ==k){
                ans = Math.Max( ans , sum*gro.n2);
            }
        }
        return ans ;
        
    }
}