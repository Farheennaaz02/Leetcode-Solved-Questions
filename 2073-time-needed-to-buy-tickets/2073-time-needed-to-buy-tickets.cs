public class Solution {
    public int TimeRequiredToBuy(int[] tickets, int k) {
        int time =0;
        for ( int i =0;i<tickets.Length;i++){
            if ( i <=k){
                time+=Math.Min (tickets[i],tickets[k]);
            }
            else{
                time +=Math.Min(tickets[i],tickets[k]-1);
            }
        }
        return time;
        
    }
}
/*public class Solution {
    public int TimeRequiredToBuy(int[] tickets, int k) {

        Queue<int> q = new Queue<int>();

        for (int i = 0; i < tickets.Length; i++)
            q.Enqueue(i);

        int time = 0;

        while (q.Count > 0)
        {
            int person = q.Dequeue();

            tickets[person]--;
            time++;

            if (tickets[person] == 0)
            {
                if (person == k)
                    return time;
            }
            else
            {
                q.Enqueue(person);
            }
        }

        return time;
    }
}*/