public class Solution
{
    List<(int next, int dist)>[] graph;
    bool[] visited;
    int answer = int.MaxValue;

    public int MinScore(int n, int[][] roads)
    {
        // Create graph
        graph = new List<(int, int)>[n + 1];

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        // Build adjacency list
        foreach (var road in roads)
        {
            int u = road[0];
            int v = road[1];
            int d = road[2];

            graph[u].Add((v, d));
            graph[v].Add((u, d));
        }

        visited = new bool[n + 1];

        // Start DFS from city 1
        DFS(1);

        return answer;
    }

    void DFS(int node)
    {
        visited[node] = true;

        foreach (var (next, dist) in graph[node])
        {
            // Keep track of the minimum edge seen
            answer = Math.Min(answer, dist);

            if (!visited[next])
            {
                DFS(next);
            }
        }
    }
}