public class Solution
{
    public int LongestSubsequence(int[] nums)
    {
        int xor = 0;
        int zeros = 0;
        int n = nums.Length;

        foreach (int x in nums)
        {
            xor ^= x;

            if (x == 0)
                zeros++;
        }

        if (xor != 0)
            return n;

        if (zeros == n)
            return 0;

        return n - 1;
    }
}