public class Solution
{
    List<int>[] graph;
    List<int>[] undirected;
    bool[] suspicious;
    bool[] visited;

    public IList<int> RemainingMethods(int n, int k, int[][] invocations)
    {
        graph = new List<int>[n];
        undirected = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
            undirected[i] = new List<int>();
        }

        foreach (var edge in invocations)
        {
            int u = edge[0];
            int v = edge[1];

            graph[u].Add(v);

            undirected[u].Add(v);
            undirected[v].Add(u);
        }

        suspicious = new bool[n];
        visited = new bool[n];

        // Mark all suspicious methods
        DFS1(k);

        // Traverse every non-suspicious component
        for (int i = 0; i < n; i++)
        {
            if (!suspicious[i] && !visited[i])
            {
                DFS2(i);
            }
        }

        List<int> ans = new List<int>();

        for (int i = 0; i < n; i++)
        {
            if (!suspicious[i])
                ans.Add(i);
        }

        return ans;
    }

    void DFS1(int node)
    {
        suspicious[node] = true;

        foreach (int nei in graph[node])
        {
            if (!suspicious[nei])
                DFS1(nei);
        }
    }

    void DFS2(int node)
    {
        visited[node] = true;
        suspicious[node] = false;

        foreach (int nei in undirected[node])
        {
            if (!visited[nei])
                DFS2(nei);
        }
    }
}