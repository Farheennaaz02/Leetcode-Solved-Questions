public class Solution
{
    bool[] visited;
    bool[] pathvisited;
    List<List<int>> graph;

    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        int n = numCourses;

        visited = new bool[n];
        pathvisited = new bool[n];

        graph = new List<List<int>>();

        // Create graph
        for (int i = 0; i < n; i++)
        {
            graph.Add(new List<int>());
        }

        // Build directed graph
        foreach (var edge in prerequisites)
        {
            int u = edge[0];
            int v = edge[1];

            graph[u].Add(v);
        }

        // Check every course
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                if (DFS(i))
                {
                    return false; // cycle mil gayi
                }
            }
        }

        return true; // cycle nahi mili
    }

    bool DFS(int node)
    {
        visited[node] = true;
        pathvisited[node] = true;

        foreach (int nei in graph[node])
        {
            // Node never visited
            if (!visited[nei])
            {
                if (DFS(nei))
                {
                    return true;
                }
            }

            // Node current DFS path mein already hai
            else if (pathvisited[nei])
            {
                return true; // cycle mil gayi
            }
        }

        // Backtracking
        pathvisited[node] = false;

        return false;
    }
}