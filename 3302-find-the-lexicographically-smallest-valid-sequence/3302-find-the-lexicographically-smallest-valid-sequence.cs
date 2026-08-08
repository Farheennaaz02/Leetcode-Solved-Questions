public class Solution
{
    public int[] ValidSequence(string word1, string word2)
    {
        int n = word1.Length;
        int m = word2.Length;

        int[] ans = new int[m];

        // last[j] = last possible index in word1
        // where word2[j] can be matched
        int[] last = new int[m];

        Array.Fill(last, -1);

        int i = n - 1;
        int j = m - 1;

        // Build suffix information from right to left
        while (i >= 0 && j >= 0)
        {
            if (word1[i] == word2[j])
            {
                last[j] = i;
                j--;
            }

            i--;
        }

        // We can use at most ONE mismatching character
        bool canSkip = true;

        j = 0;

        for (i = 0; i < n; i++)
        {
            if (j == m)
                break;

            // Normal matching character
            if (word1[i] == word2[j])
            {
                ans[j] = i;
                j++;
            }
            // Use our one allowed mismatch
            else if (canSkip &&
                     (j == m - 1 || i < last[j + 1]))
            {
                ans[j] = i;
                j++;
                canSkip = false;
            }
        }

        // Couldn't match all characters
        if (j != m)
            return Array.Empty<int>();

        return ans;
    }
}