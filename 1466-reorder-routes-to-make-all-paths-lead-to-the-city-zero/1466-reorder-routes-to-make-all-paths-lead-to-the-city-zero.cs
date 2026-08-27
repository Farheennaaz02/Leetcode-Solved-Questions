public class Solution {
    public int MinReorder(int n, int[][] connections) {
        // return the number kitni direction change kari
        List <Tuple< int , int >>[] graph = new List<Tuple<int , int >>[n];
        // connection map sketel 
        for ( int i =0;i<n;i++){
            graph[i]= new List <Tuple<int  , int >>();
        }
        foreach (var edge in connections ){
            int a = edge[0];
            int b = edge[1];
            // suppose a->b manual bnaenge
            graph[a].Add(new Tuple <int , int> (b,1));// 1 => manula create kara esa 
            graph[b].Add(new Tuple<int , int > (a,0));// 0=> original atha esaa 
            // connection map complete 
        }
        // infinte ko rokna pdega 
        bool [] visited = new bool [n];
        return DFS ( 0 , graph , visited);

        
        
    }
    int DFS ( int city , List<Tuple<int , int >>[] graph , bool[] visited){
        visited[city]= true;
        int count =0;
        foreach ( var edge in graph[city]){
            int nextcity = edge.Item1;
            int cost = edge.Item2;
            if ( visited[nextcity]){
                continue ;
            }
            count+=cost;
            count+=DFS(nextcity , graph , visited);
        }
        return count ;
        

    }
}