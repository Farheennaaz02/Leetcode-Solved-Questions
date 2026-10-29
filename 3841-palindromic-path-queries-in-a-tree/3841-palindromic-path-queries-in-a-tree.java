
import java.util.*;

class Solution {
    int[][] up;
    int[] depth, tin, tout, parent;
    int[] basePrefix;
    int timer, LOG;
    List<Integer>[] tree;
    Fenwick bit;

    public List<Boolean> palindromePath(
            int n, int[][] edges, String s, String[] queries) {

        tree = new ArrayList[n];
        for (int i = 0; i < n; i++) {
            tree[i] = new ArrayList<>();
        }

        // 1. Build the tree
        for (int[] e : edges) {
            tree[e[0]].add(e[1]);
            tree[e[1]].add(e[0]);
        }

        LOG = 1;
        while ((1 << LOG) <= n) LOG++;

        up = new int[LOG][n];
        depth = new int[n];
        tin = new int[n];
        tout = new int[n];
        parent = new int[n];
        basePrefix = new int[n];

        int[] order = new int[n];
        int[] stack = new int[n];
        int[] nextChild = new int[n];

        // 2. Iterative DFS: parent, depth, Euler times
        int top = 0;
        stack[top++] = 0;
        parent[0] = 0;
        tin[0] = ++timer;
        order[timer - 1] = 0;

        while (top > 0) {
            int u = stack[top - 1];

            if (nextChild[u] < tree[u].size()) {
                int v = tree[u].get(nextChild[u]++);

                if (v == parent[u]) continue;

                parent[v] = u;
                depth[v] = depth[u] + 1;
                up[0][v] = u;

                tin[v] = ++timer;
                order[timer - 1] = v;
                stack[top++] = v;
            } else {
                tout[u] = timer;
                top--;
            }
        }

        // 3. Binary lifting table for LCA
        for (int k = 1; k < LOG; k++) {
            for (int u = 0; u < n; u++) {
                up[k][u] = up[k - 1][up[k - 1][u]];
            }
        }

        // 4. XOR bitmask from root to each node
        char[] chars = s.toCharArray();

        basePrefix[0] = 1 << (chars[0] - 'a');

        for (int i = 1; i < n; i++) {
            int u = order[i];
            basePrefix[u] =
                basePrefix[parent[u]] ^ (1 << (chars[u] - 'a'));
        }

        // 5. Fenwick tree for subtree range XOR updates
        bit = new Fenwick(n + 2);

        List<Boolean> answer = new ArrayList<>();

        // 6. Process queries
        for (String q : queries) {
            String[] parts = q.split(" ");

            if (parts[0].equals("update")) {
                int u = Integer.parseInt(parts[1]);
                char c = parts[2].charAt(0);

                int oldMask = 1 << (chars[u] - 'a');
                int newMask = 1 << (c - 'a');
                int delta = oldMask ^ newMask;

                // Update all root-prefix masks in u's subtree
                bit.update(tin[u], delta);
                bit.update(tout[u] + 1, delta);

                chars[u] = c;
            } else {
                int u = Integer.parseInt(parts[1]);
                int v = Integer.parseInt(parts[2]);

                int lca = getLCA(u, v);

                int mask = basePrefix[u] ^ basePrefix[v]
                        ^ bit.query(tin[u])
                        ^ bit.query(tin[v])
                        ^ (1 << (chars[lca] - 'a'));

                // At most one character may have odd frequency
                answer.add((mask & (mask - 1)) == 0);
            }
        }

        return answer;
    }

    int getLCA(int u, int v) {
        if (depth[u] < depth[v]) {
            int temp = u;
            u = v;
            v = temp;
        }

        // Bring u to v's depth
        int diff = depth[u] - depth[v];

        for (int k = 0; k < LOG; k++) {
            if ((diff & (1 << k)) != 0) {
                u = up[k][u];
            }
        }

        if (u == v) return u;

        // Lift both nodes until their parents become equal
        for (int k = LOG - 1; k >= 0; k--) {
            if (up[k][u] != up[k][v]) {
                u = up[k][u];
                v = up[k][v];
            }
        }

        return parent[u];
    }

    class Fenwick {
        int[] tree;

        Fenwick(int n) {
            tree = new int[n + 1];
        }

        // XOR difference update
        void update(int i, int value) {
            while (i < tree.length) {
                tree[i] ^= value;
                i += i & -i;
            }
        }

        // Prefix XOR
        int query(int i) {
            int result = 0;

            while (i > 0) {
                result ^= tree[i];
                i -= i & -i;
            }

            return result;
        }
    }
}
