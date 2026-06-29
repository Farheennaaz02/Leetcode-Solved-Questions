public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        int [] result = new int [n];
        Stack <int > stack = new ();
        int prevtime =0;
        foreach ( string log in logs ){
            string [] part= log.Split (':');
            int id = int.Parse(part[0]);
            string type = part[1];
            int time = int.Parse( part[2]);
            if (type == "start"){
                if ( stack.Count>0){
                    result[stack.Peek()]+= time - prevtime;
                    
                }
                stack.Push ( id);
                prevtime =  time;
            }
            else{
                result[stack.Peek()]+=time - prevtime+1;
                stack.Pop();
                prevtime = time +1;
            }
        
        }
        return result ;
        
    }
}