public class Solution {
    public string PredictPartyVictory(string senate) {
        int n = senate.Length;
        Queue<int > radiant = new ();
        Queue<int> dire = new();
        for (int i =0;i<n;i++){
            if (senate[i]=='R'){
                radiant.Enqueue(i);// indexing 
            }
            else {
                dire.Enqueue(i);
            }
        }
        while (radiant.Count >0&& dire.Count >0){
            int r = radiant.Dequeue();
            int d = dire.Dequeue();
            if ( r<d){// r phle aaya tha d se 
                radiant.Enqueue(r+n);

            }
            else {
                dire.Enqueue(d+n);
            }

        }
        if  ( radiant.Count >0){
            return "Radiant";
        }
        else {
            return "Dire";
        }
        
    }
}