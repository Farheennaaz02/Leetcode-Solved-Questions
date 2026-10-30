
class Solution {
    public int shortestPath(int n, int[][] edges, String labels, int k) {

        // Create adjacency list
        List<int[]>[] graph = new ArrayList[n];

        for (int i = 0; i < n; i++) {
            graph[i] = new ArrayList<>();
        }

        for (int[] edge : edges) {
            int u = edge[0];
            int v = edge[1];
            int w = edge[2];

            graph[u].add(new int[]{v, w});
        }

        // dist[node][count]
        // count = consecutive identical characters
        long[][] dist = new long[n][k + 1];

        for (int i = 0; i < n; i++) {
            Arrays.fill(dist[i], Long.MAX_VALUE);
        }

        // Starting node has consecutive count 1
        dist[0][1] = 0;

        // {node, count, cost}
        PriorityQueue<long[]> pq = new PriorityQueue<>(
            (a, b) -> Long.compare(a[2], b[2])
        );

        pq.offer(new long[]{0, 1, 0});

        while (!pq.isEmpty()) {

            long[] curr = pq.poll();

            int node = (int) curr[0];
            int count = (int) curr[1];
            long cost = curr[2];

            // Skip outdated state
            if (cost != dist[node][count]) {
                continue;
            }

            // Destination reached
            if (node == n - 1) {
                return (int) cost;
            }

            // Explore neighbours
            for (int[] next : graph[node]) {

                int v = next[0];
                int weight = next[1];

                int newCount;

                if (labels.charAt(node) == labels.charAt(v)) {
                    newCount = count + 1;
                } else {
                    newCount = 1;
                }

                // Invalid consecutive characters
                if (newCount > k) {
                    continue;
                }

                long newCost = cost + weight;

                if (newCost < dist[v][newCount]) {

                    dist[v][newCount] = newCost;

                    pq.offer(new long[]{
                        v, newCount, newCost
                    });
                }
            }
        }

        return -1;
    }
}
