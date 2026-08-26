class Solution {
     boolean [] visited ;
    List <List <Integer >> graph ;
    public boolean validPath(int n, int[][] edges, int source, int destination) {
        visited = new boolean [n];
        graph = new ArrayList<>();
        for ( int i =0;i<n;i++){
            graph.add (new ArrayList<>());
        }
        for( int [] edge : edges){
            int u = edge[0];
            int v = edge [1];
            graph.get(u).add(v);
            graph.get(v).add(u);
        }
        return DFS ( source , destination );
        
    }
    boolean DFS ( int node , int destination ){
        visited[node]= true;
        if ( node== destination ){
            return true ;
        }
        for ( int nei:graph.get(node)){
            if (!visited[nei]){
                if(DFS(nei, destination )){
                    return true ;
                }

            }
        }
        return false;
    }
}