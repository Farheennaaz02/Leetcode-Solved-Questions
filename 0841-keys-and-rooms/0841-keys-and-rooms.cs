public class Solution {
    bool [] visited;
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        int n = rooms.Count;
        visited = new bool[n];
        DFS ( 0 , rooms);
        for( int i =0;i<n;i++){
            if (!visited[i]){
                return false ;
            }
        }
        return true;


        
    }
    void DFS ( int room , IList<IList<int>> rooms){
        visited[room]= true ;
        foreach ( int nextroom in rooms[room]){
            if (!visited[nextroom]){
                DFS(nextroom , rooms);

            }
        }
    }
}