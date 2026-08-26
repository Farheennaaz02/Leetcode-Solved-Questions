public class Solution {
    bool [] visited ;
    List <IList<int>> graph ;
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        // return false /true 
        // bi directinal 
        visited= new bool[n];
        graph = new List <IList<int>> ();
        // connected map;
        for( int i =0;i<n;i++){
             graph.Add(new List<int>());
          
            
        }
        foreach ( var edge in edges){
            int u = edge[0];
            int v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);// connected map complete 
        }
        return DFS ( source , destination);
        
    }
    bool DFS ( int node  , int destination){
        visited[node]= true;
        if ( node == destination ){
            return true ;
        }
        foreach ( int nei in graph[node]){
            if ( !visited[nei]){
                if (DFS ( nei, destination )){
                    return true;
                }
            }
        }
        return false;
    }
}