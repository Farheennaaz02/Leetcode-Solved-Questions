class Solution {

    class Node {
        int product;      // product of whole segment % k
        int[] count;      // count[r] = number of subarrays with product % k = r

        Node(int k) {
            product = 1;
            count = new int[k];
        }
    }

    int k;

    // Merge two nodes: left + right
    Node merge(Node left, Node right) {

        Node res = new Node(k);

        // Product of complete segment
        res.product = (left.product * right.product) % k;

        // Subarrays completely inside left
        for (int r = 0; r < k; r++) {
            res.count[r] = left.count[r];
        }

        // Subarrays starting in left and continuing into right
        for (int r = 0; r < k; r++) {
            int newRemainder = (r * left.product) % k;
            res.count[newRemainder] += right.count[r];
        }

        return res;
    }

    Node[] tree;

    void build(int node, int l, int r, int[] nums) {

        if (l == r) {
            tree[node] = new Node(k);

            int value = nums[l] % k;

            tree[node].product = value;
            tree[node].count[value] = 1;

            return;
        }

        int mid = l + (r - l) / 2;

        build(node * 2, l, mid, nums);
        build(node * 2 + 1, mid + 1, r, nums);

        tree[node] = merge(tree[node * 2], tree[node * 2 + 1]);
    }

    void update(int node, int l, int r, int index, int value) {

        if (l == r) {

            tree[node] = new Node(k);

            value %= k;

            tree[node].product = value;
            tree[node].count[value] = 1;

            return;
        }

        int mid = l + (r - l) / 2;

        if (index <= mid) {
            update(node * 2, l, mid, index, value);
        } else {
            update(node * 2 + 1, mid + 1, r, index, value);
        }

        tree[node] = merge(tree[node * 2], tree[node * 2 + 1]);
    }

    Node query(int node, int l, int r, int ql, int qr) {

        // Completely inside
        if (ql <= l && r <= qr) {
            return tree[node];
        }

        // Completely outside
        if (r < ql || l > qr) {
            Node empty = new Node(k);
            return empty;
        }

        int mid = l + (r - l) / 2;

        Node left = query(node * 2, l, mid, ql, qr);
        Node right = query(node * 2 + 1, mid + 1, r, ql, qr);

        return merge(left, right);
    }

    public int[] resultArray(int[] nums, int k, int[][] queries) {

        this.k = k;

        int n = nums.length;

        tree = new Node[4 * n];

        // Build segment tree
        build(1, 0, n - 1, nums);

        int[] ans = new int[queries.length];

        for (int i = 0; i < queries.length; i++) {

            int index = queries[i][0];
            int value = queries[i][1];
            int start = queries[i][2];
            int x = queries[i][3];

            // 1. Update nums[index]
            update(1, 0, n - 1, index, value);

            // 2. Query [start, n-1]
            Node result = query(1, 0, n - 1, start, n - 1);

            // 3. Number of subarrays having product % k == x
            ans[i] = result.count[x];
        }

        return ans;
    }
}