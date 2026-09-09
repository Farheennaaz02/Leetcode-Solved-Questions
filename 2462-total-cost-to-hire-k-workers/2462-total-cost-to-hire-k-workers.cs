public class Solution {
    public long TotalCost(int[] costs, int k, int candidates) {
        int n = costs.Length ;
        PriorityQueue<int , int> leftpq= new();
        PriorityQueue<int , int>rightpq= new ();
        int left=0;
        int right = n-1;
        long ans =0;
        while ( k >0){
            while ( leftpq.Count <candidates&& left <= right){
                leftpq.Enqueue(costs[left],costs[left]);
                left++;
            }
            while ( rightpq.Count <candidates&& left <= right){
                rightpq.Enqueue(costs[right ], costs[right]);
                right --;
            }
            if ( rightpq.Count ==0||( leftpq.Count >0&& leftpq.Peek()<=rightpq.Peek())){
                ans+=leftpq.Dequeue();
            }
            else{
                ans += rightpq.Dequeue();
            }
            k--;
        }
        return ans ;
    }
}