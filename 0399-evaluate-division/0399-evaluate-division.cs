public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        Dictionary <string ,List<(string , double)>>graph = new ();
        // connnection map 
        //  equation=> graph
        for( int i =0;i<equations.Count;i++){
            string a = equations[i][0];
            string b = equations[i][1];
            double value = values[i];
            if (!graph.ContainsKey(a)){
                graph[a]= new List<(string , double) >();
            }
            graph[a].Add((b , value));
            if(!graph.ContainsKey(b)){
                graph[b]= new List <(string , double )>();
            }
            graph[b].Add((a,1.0/value));
        } 
        List<double > result = new ();
        // solve query
        foreach(var query in queries){
            string start = query[0];// pairs
            string end = query[1];
            if (!graph.ContainsKey(start)||!graph.ContainsKey(end)){
                result.Add(-1.0);
                continue ;
            }
            HashSet<string > visited = new ();
            double answer = DFS (start , end , 1.0 , graph , visited);
            result.Add(answer);
        }
        
        
    return result.ToArray();

    }
    double DFS (string current ,  string target , double product , Dictionary<string , List<(string , double )>> graph,HashSet<string > visited){
        if ( current == target){
            return product;
        }
        visited.Add(current);
        foreach ( var edge in graph [current]){
            string next = edge.Item1;
            double value = edge.Item2;
            if ( visited.Contains(next)){
                continue ;
            }
            double answer = DFS (next , target , product*value , graph , visited);
            if (answer!=-1.0){
                return answer;
            }
            

        }
        return -1.0;
    }
}