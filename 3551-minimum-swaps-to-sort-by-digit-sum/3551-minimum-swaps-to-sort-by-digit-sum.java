
import java.util.*;

class Solution {
    public int minSwaps(int[] nums) {
        int n = nums.length;

        // Store the original array
        int[] sorted = nums.clone();

        // Sort by digit sum, then by number
        Integer[] arr = new Integer[n];

        for (int i = 0; i < n; i++) {
            arr[i] = nums[i];
        }

        Arrays.sort(arr, (a, b) -> {
            int sumA = digitSum(a);
            int sumB = digitSum(b);

            if (sumA != sumB) {
                return sumA - sumB;
            }

            return a - b;
        });

        // Map each number to its correct sorted index
        Map<Integer, Integer> position = new HashMap<>();

        for (int i = 0; i < n; i++) {
            position.put(arr[i], i);
        }

        boolean[] visited = new boolean[n];
        int swaps = 0;

        // Count cycles of misplaced elements
        for (int i = 0; i < n; i++) {
            if (visited[i]) {
                continue;
            }

            int j = i;
            int cycleSize = 0;

            while (!visited[j]) {
                visited[j] = true;

                // Find where the current number belongs
                j = position.get(nums[j]);

                cycleSize++;
            }

            if (cycleSize > 1) {
                swaps += cycleSize - 1;
            }
        }

        return swaps;
    }

    private int digitSum(int num) {
        int sum = 0;

        while (num > 0) {
            sum += num % 10;
            num /= 10;
        }

        return sum;
    }
}
