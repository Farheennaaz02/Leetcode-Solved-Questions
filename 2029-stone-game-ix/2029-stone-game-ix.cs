public class Solution {
    public bool StoneGameIX(int[] stones) {
        int[] count = new int[3];

        foreach (int stone in stones) {
            count[stone % 3]++;
        }

        int zero = count[0];
        int one = count[1];
        int two = count[2];

        // If there are no 1s or no 2s,
        // Alice cannot create a winning situation.
        if (one == 0 && two == 0)
            return false;

        // Remove pairs of 0s because they don't affect the game.
        // The important cases depend on the difference between
        // the number of 1s and 2s.

        if (zero % 2 == 0) {
            return one >= 1 && two >= 1;
        }

        return Math.Abs(one - two) > 2;
    }
}