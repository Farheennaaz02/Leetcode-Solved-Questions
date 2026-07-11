public class Solution {
     bool [] visited ;
        List <int >[] graph;
        
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        visited= new bool[n];
        graph = new List <int> [n];
       for ( int i =0;i<n;i++){
            graph[i]= new List <int>();
        }
        foreach ( var edge  in edges){
            int u = edge[0];
            int v= edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }
        return DFS ( source, destination);
    }
    public bool DFS( int node, int destination ){
        visited[node]= true ;
        if ( node== destination){
            return true ;
        }
        foreach (int neig in graph[node]){
            if (!visited[neig]){
                if (DFS(neig, destination)){
                    return true;
                }
            }
        }
        return false;
        
    }
}