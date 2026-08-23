public class Solution {
    public bool SumGame(string num) {
        int n = num.Length;
        int mid = n / 2;

        int leftSum = 0;
        int rightSum = 0;
        int leftQ = 0;
        int rightQ = 0;

        // Left half
        for (int i = 0; i < mid; i++) {
            if (num[i] == '?')
                leftQ++;
            else
                leftSum += num[i] - '0';
        }

        // Right half
        for (int i = mid; i < n; i++) {
            if (num[i] == '?')
                rightQ++;
            else
                rightSum += num[i] - '0';
        }

        int sumDiff = leftSum - rightSum;
        int qDiff = leftQ - rightQ;

        // Odd difference in ? means Alice can always force inequality
        if (qDiff % 2 != 0)
            return true;

        // Bob wins only in this exact balanced case
        return sumDiff != -(qDiff / 2) * 9;
    }
}