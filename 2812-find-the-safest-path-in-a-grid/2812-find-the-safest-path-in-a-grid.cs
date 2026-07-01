public class Solution {
    int n;
    int[][] dist;

    public int MaximumSafenessFactor(IList<IList<int>> grid) {
        n = grid.Count;
        dist = new int[n][];
        for (int i = 0; i < n; i++) { dist[i] = new int[n]; Array.Fill(dist[i], -1); }

        Queue<(int,int)> q = new Queue<(int,int)>();
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (grid[i][j] == 1) { dist[i][j] = 0; q.Enqueue((i,j)); }

        int[] dx = {0,0,1,-1}, dy = {1,-1,0,0};
        while (q.Count > 0) {
            var (x,y) = q.Dequeue();
            for (int d = 0; d < 4; d++) {
                int nx = x+dx[d], ny = y+dy[d];
                if (nx>=0 && nx<n && ny>=0 && ny<n && dist[nx][ny]==-1) {
                    dist[nx][ny] = dist[x][y]+1;
                    q.Enqueue((nx,ny));
                }
            }
        }

        int lo = 0, hi = n, ans = 0;
        while (lo <= hi) {
            int mid = (lo+hi)/2;
            if (CanReach(mid)) { ans = mid; lo = mid+1; }
            else hi = mid-1;
        }
        return ans;
    }

    bool CanReach(int minSafe) {
        if (dist[0][0] < minSafe) return false;
        bool[,] visited = new bool[n,n];
        Queue<(int,int)> q = new Queue<(int,int)>();
        q.Enqueue((0,0));
        visited[0,0] = true;
        int[] dx = {0,0,1,-1}, dy = {1,-1,0,0};

        while (q.Count > 0) {
            var (x,y) = q.Dequeue();
            if (x == n-1 && y == n-1) return true;
            for (int d = 0; d < 4; d++) {
                int nx = x+dx[d], ny = y+dy[d];
                if (nx>=0 && nx<n && ny>=0 && ny<n && !visited[nx,ny] && dist[nx][ny] >= minSafe) {
                    visited[nx,ny] = true;
                    q.Enqueue((nx,ny));
                }
            }
        }
        return false;
    }
}