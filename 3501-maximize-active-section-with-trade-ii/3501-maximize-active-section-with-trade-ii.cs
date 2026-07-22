public class SegmentTree {
    private int n;
    private int[] arr;
    private int[] seg;

    private void Build(int p, int l, int r) {
        if (l == r) {
            seg[p] = arr[l];
            return;
        }

        int mid = (l + r) >> 1;
        Build(p << 1, l, mid);
        Build(p << 1 | 1, mid + 1, r);
        seg[p] = Math.Max(seg[p << 1], seg[p << 1 | 1]);
    }

    private int QueryInternal(int p, int l, int r, int L, int R) {
        if (L <= l && r <= R) {
            return seg[p];
        }

        int mid = (l + r) >> 1;
        int res = 0;
        if (L <= mid) {
            res = Math.Max(res, QueryInternal(p << 1, l, mid, L, R));
        }
        if (R > mid) {
            res = Math.Max(res, QueryInternal(p << 1 | 1, mid + 1, r, L, R));
        }

        return res;
    }

    public SegmentTree(int[] arr) {
        this.arr = arr;
        this.n = arr.Length;
        this.seg = new int[n << 2];
        Build(1, 0, n - 1);
    }

    public int Query(int L, int R) {
        if (L > R) {
            return 0;
        }

        return QueryInternal(1, 0, n - 1, L, R);
    }
}

public class Solution {
    public List<int> MaxActiveSectionsAfterTrade(string s, int[][] queries) {
        int n = s.Length;
        int cnt1 = s.Count(c => c == '1');

        List<int> zeroBlocks = new List<int>();
        List<int> blockLeft = new List<int>();
        List<int> blockRight = new List<int>();

        int i = 0;
        while (i < n) {
            int st = i;
            while (i < n && s[i] == s[st]) {
                i += 1;
            }
            if (s[st] == '0') {
                zeroBlocks.Add(i - st);
                blockLeft.Add(st);
                blockRight.Add(i - 1);
            }
        }

        int m = zeroBlocks.Count;
        if (m < 2) {  // continuous 0 blocks less than 2 segments, return the
                      // answer directly
            return Enumerable.Repeat(cnt1, queries.Length).ToList();
        }

        int[] tmpSum = new int[m - 1];
        for (int k = 0; k < m - 1; k++) {
            tmpSum[k] = zeroBlocks[k] + zeroBlocks[k + 1];
        }
        SegmentTree seg = new SegmentTree(tmpSum);
        List<int> ans = new List<int>();

        foreach (var q in queries) {
            int l = q[0], r = q[1];
            int idx = LowerBound(blockRight, l);
            int jdx = UpperBound(blockLeft, r) - 1;

            // at most 1 continuous block of 0s within the substring
            if (idx > m - 1 || jdx < 0 || idx >= jdx) {
                ans.Add(cnt1);
                continue;
            }
            int firstLen = blockRight[idx] - Math.Max(blockLeft[idx], l) +
                           1;  // actual length of the first consecutive block
                               // of 0s in the substring
            int lastLen = Math.Min(blockRight[jdx], r) - blockLeft[jdx] +
                          1;  // actual length of the last consecutive block of
                              // 0s in the substring
            int bestGain;
            // exactly 2 consecutive 0 blocks within the substring
            if (idx + 1 == jdx) {
                bestGain = firstLen + lastLen;
            } else {
                int val1 = firstLen + zeroBlocks[idx + 1];
                int val2 = zeroBlocks[jdx - 1] + lastLen;
                int val3 = seg.Query(idx + 1, jdx - 2);
                bestGain = Math.Max(Math.Max(val1, val2), val3);
            }
            ans.Add(cnt1 + bestGain);
        }

        return ans;
    }

    private int LowerBound(List<int> list, int target) {
        int left = 0, right = list.Count;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }

    private int UpperBound(List<int> list, int target) {
        int left = 0, right = list.Count;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list[mid] <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}