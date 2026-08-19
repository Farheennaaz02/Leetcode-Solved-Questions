public class Solution {
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) {

        // Store reserved seats row-wise
        Dictionary<int, HashSet<int>> reserved = new();

        foreach (int[] seat in reservedSeats) {
            int row = seat[0];
            int col = seat[1];

            if (!reserved.ContainsKey(row)) {
                reserved[row] = new HashSet<int>();
            }

            reserved[row].Add(col);
        }

        // Every completely empty row can have 2 families
        int ans = (n - reserved.Count) * 2;

        // Check rows having reservations
        foreach (var entry in reserved) {

            HashSet<int> seats = entry.Value;

            bool left = !seats.Contains(2) &&
                        !seats.Contains(3) &&
                        !seats.Contains(4) &&
                        !seats.Contains(5);

            bool middle = !seats.Contains(4) &&
                          !seats.Contains(5) &&
                          !seats.Contains(6) &&
                          !seats.Contains(7);

            bool right = !seats.Contains(6) &&
                         !seats.Contains(7) &&
                         !seats.Contains(8) &&
                         !seats.Contains(9);

            if (left && right) {
                // Can put one family on each side
                ans += 2;
            }
            else if (left || middle || right) {
                // Only one group is possible
                ans += 1;
            }
        }

        return ans;
    }
}