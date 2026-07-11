public class Solution {
    int nodes =0;
    int edge =0;
    int count =0;
    List<int > [] graph ; 
    bool[] visited;
    public int CountCompleteComponents(int n, int[][] edges) {
        //do DFS and cheac the condtion and increase the answer and also take care of the n nodes 
         visited = new bool [ n];
         graph = new List<int > [n];
        for ( int i =0;i<n;i++){
            graph[i]=new List <int > ();
        }
        foreach (var e in edges){
            graph[e[0]].Add(e[1]);
            graph [e[1]].Add(e[0]);
        }
        for ( int i =0;i<n ;i++){
            if (!visited[i]){
                nodes =0;
                edge=0;
                DFS(i);
                edge/=2;
                if (edge == nodes *(nodes-1)/2){
                    count ++;
                }
            }
        }
        return count;

        
    }
    public void DFS ( int node){
        visited[node]= true ;
        nodes ++;
        foreach ( int nei in graph[node] ){
            edge ++;
            if ( !visited[nei]){
                DFS(nei);
            }
        }
        

    }

}