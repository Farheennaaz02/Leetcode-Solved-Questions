public class Solution {
    public int FindMaxPathScore(int[][] edges, bool[] online, long k) {
        int n = online.Length;

        // Adjacency list ek hi baar banao
        List<int[]>[] adj = new List<int[]>[n];
        int[] indeg = new int[n];
        for (int i = 0; i < n; i++) adj[i] = new List<int[]>();

        int maxCost = 0;
        foreach (var e in edges) {
            adj[e[0]].Add(new int[] { e[1], e[2] });
            indeg[e[1]]++;
            maxCost = Math.Max(maxCost, e[2]);
        }

        // Topological order ek hi baar nikal lo (Kahn's algorithm)
        int[] topoOrder = new int[n];
        int idx = 0;
        int[] indegCopy = (int[])indeg.Clone();
        Queue<int> q = new Queue<int>();
        for (int i = 0; i < n; i++) if (indegCopy[i] == 0) q.Enqueue(i);

        while (q.Count > 0) {
            int u = q.Dequeue();
            topoOrder[idx++] = u;
            foreach (var e in adj[u]) {
                if (--indegCopy[e[0]] == 0) q.Enqueue(e[0]);
            }
        }

        // Binary search directly value range par (sorting/distinct ki zaroorat nahi)
        int lo = 0, hi = maxCost, ans = -1;

        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;

            if (CanReach(n, adj, online, k, mid, topoOrder)) {
                ans = mid;
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }

        return ans;
    }

    // O(n + m) DP using precomputed topo order — no heap, no rebuilding
    private bool CanReach(int n, List<int[]>[] adj, bool[] online, long k, int score, int[] topoOrder) {
        long[] dist = new long[n];
        Array.Fill(dist, long.MaxValue);
        dist[0] = 0;

        foreach (int u in topoOrder) {
            if (dist[u] == long.MaxValue) continue;
            if (u != 0 && !online[u]) continue; // offline node se aage mat badho

            foreach (var e in adj[u]) {
                int v = e[0], c = e[1];
                if (c < score) continue; // is score ke liye ye edge kaam ka nahi

                long newDist = dist[u] + c;
                if (newDist < dist[v]) dist[v] = newDist;
            }
        }

        return dist[n - 1] != long.MaxValue && dist[n - 1] <= k;
    }
}