public class Solution
{
    struct Node
    {
        public char left, right;
        public int pre, suf, best, len;

        public Node(char c)
        {
            left = right = c;
            pre = suf = best = len = 1;
        }
    }

    Node[] tree;
    char[] s;

    int root = 1;

    Node Merge(Node a, Node b)
    {
        Node c = new Node();

        c.len = a.len + b.len;
        c.left = a.left;
        c.right = b.right;

        c.pre = a.pre;
        c.suf = b.suf;
        c.best = Math.Max(a.best, b.best);

        if (a.right == b.left)
        {
            c.best = Math.Max(c.best, a.suf + b.pre);

            if (a.pre == a.len)
                c.pre = a.len + b.pre;

            if (b.suf == b.len)
                c.suf = b.len + a.suf;
        }

        return c;
    }

    void Build(int node, int l, int r)
    {
        if (l == r)
        {
            tree[node] = new Node(s[l]);
            return;
        }

        int mid = (l + r) / 2;

        Build(node * 2, l, mid);
        Build(node * 2 + 1, mid + 1, r);

        tree[node] = Merge(tree[node * 2], tree[node * 2 + 1]);
    }

    void Update(int node, int l, int r, int pos, char ch)
    {
        if (l == r)
        {
            tree[node] = new Node(ch);
            return;
        }

        int mid = (l + r) / 2;

        if (pos <= mid)
            Update(node * 2, l, mid, pos, ch);
        else
            Update(node * 2 + 1, mid + 1, r, pos, ch);

        tree[node] = Merge(tree[node * 2], tree[node * 2 + 1]);
    }

    public int[] LongestRepeating(
        string str,
        string queryCharacters,
        int[] queryIndices)
    {
        s = str.ToCharArray();

        int n = s.Length;
        int k = queryIndices.Length;

        tree = new Node[4 * n];

        Build(root, 0, n - 1);

        int[] ans = new int[k];

        for (int i = 0; i < k; i++)
        {
            int pos = queryIndices[i];
            char ch = queryCharacters[i];

            s[pos] = ch;

            Update(root, 0, n - 1, pos, ch);

            ans[i] = tree[root].best;
        }

        return ans;
    }
}