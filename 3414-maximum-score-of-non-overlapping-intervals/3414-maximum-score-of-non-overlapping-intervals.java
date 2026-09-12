class Solution {

    class Node {
        int start, end, weight, index;

        Node(int start, int end, int weight, int index) {
            this.start = start;
            this.end = end;
            this.weight = weight;
            this.index = index;
        }
    }

    class Result {
        long weight;
        List<Integer> indices;

        Result(long weight, List<Integer> indices) {
            this.weight = weight;
            this.indices = indices;
        }
    }

    public int[] maximumWeight(List<List<Integer>> intervals) {

        int n = intervals.size();

        Node[] arr = new Node[n];

        for (int i = 0; i < n; i++) {
            arr[i] = new Node(
                intervals.get(i).get(0),
                intervals.get(i).get(1),
                intervals.get(i).get(2),
                i
            );
        }

        // Sort by start time
        Arrays.sort(arr, (a, b) -> {
            if (a.start != b.start)
                return Integer.compare(a.start, b.start);

            if (a.end != b.end)
                return Integer.compare(a.end, b.end);

            return Integer.compare(a.index, b.index);
        });

        // Find next non-overlapping interval
        int[] next = new int[n];

        for (int i = 0; i < n; i++) {

            int left = i + 1;
            int right = n;

            while (left < right) {

                int mid = left + (right - left) / 2;

                if (arr[mid].start > arr[i].end) {
                    right = mid;
                } else {
                    left = mid + 1;
                }
            }

            next[i] = left;
        }

        Result[][] dp = new Result[n + 1][5];

        // IMPORTANT:
        // Initialize every dp[n][k]
        for (int k = 0; k <= 4; k++) {
            dp[n][k] = new Result(
                0,
                new ArrayList<>()
            );
        }

        for (int i = n - 1; i >= 0; i--) {

            // If k = 0, we cannot select anything
            dp[i][0] = new Result(
                0,
                new ArrayList<>()
            );

            for (int k = 1; k <= 4; k++) {

                // OPTION 1: Skip current interval
                Result skip = dp[i + 1][k];

                // OPTION 2: Take current interval
                Result nextResult = dp[next[i]][k - 1];

                List<Integer> indices =
                    new ArrayList<>(nextResult.indices);

                indices.add(arr[i].index);

                Collections.sort(indices);

                Result take = new Result(
                    arr[i].weight + nextResult.weight,
                    indices
                );

                dp[i][k] = better(skip, take);
            }
        }

        return dp[0][4].indices
                .stream()
                .mapToInt(Integer::intValue)
                .toArray();
    }

    private Result better(Result a, Result b) {

        // Higher weight is better
        if (a.weight != b.weight) {
            return a.weight > b.weight ? a : b;
        }

        // Same weight -> lexicographically smaller
        List<Integer> x = a.indices;
        List<Integer> y = b.indices;

        int size = Math.min(x.size(), y.size());

        for (int i = 0; i < size; i++) {

            if (!x.get(i).equals(y.get(i))) {
                return x.get(i) < y.get(i) ? a : b;
            }
        }

        return x.size() <= y.size() ? a : b;
    }
}