class Solution {
    public int thirdMax(int[] nums) {
        
        HashSet <Integer > set = new HashSet<>();
        for (int i :nums){
            set.add(i);
        }
        if (set.size()<3){
            return Collections.max(set);
        }
        PriorityQueue<Integer> q = new PriorityQueue<>();
        for ( int i:set){
            q.offer(i);
        }
        while (q.size()>3){
            q.poll();
        }
        return q.peek();
        
    }
}