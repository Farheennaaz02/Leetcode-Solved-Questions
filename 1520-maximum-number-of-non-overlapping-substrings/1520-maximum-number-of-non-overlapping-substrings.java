class Solution {
    public List<String> maxNumOfSubstrings(String s) {

        int n = s.length();

        int[] first = new int[26];
        int[] last = new int[26];

        Arrays.fill(first, -1);

        // Find first and last occurrence
        for (int i = 0; i < n; i++) {

            int c = s.charAt(i) - 'a';

            if (first[c] == -1) {
                first[c] = i;
            }

            last[c] = i;
        }

        List<int[]> intervals = new ArrayList<>();

        // Try starting from every first occurrence
        for (int i = 0; i < n; i++) {

            int c = s.charAt(i) - 'a';

            // Only start from first occurrence
            if (i != first[c]) {
                continue;
            }

            int start = i;
            int end = last[c];

            boolean valid = true;

            // Expand the interval if required
            for (int j = start; j <= end; j++) {

                int current = s.charAt(j) - 'a';

                // Character appeared before start
                if (first[current] < start) {
                    valid = false;
                    break;
                }

                // Need to include all occurrences
                end = Math.max(end, last[current]);
            }

            if (valid) {
                intervals.add(new int[]{start, end});
            }
        }

        // Sort by ending position
        intervals.sort((a, b) -> a[1] - b[1]);

        List<String> ans = new ArrayList<>();

        int previousEnd = -1;

        for (int[] interval : intervals) {

            int start = interval[0];
            int end = interval[1];

            // Non-overlapping
            if (start > previousEnd) {

                ans.add(s.substring(start, end + 1));

                previousEnd = end;
            }
        }

        return ans;
    }
}