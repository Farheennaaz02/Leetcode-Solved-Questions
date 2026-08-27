public class Solution
{
    public string LexGreaterPermutation(string s, string target)
    {
        int n = s.Length;

        int[] original = new int[26];

        foreach (char c in s)
        {
            original[c - 'a']++;
        }

        // Try every position from right to left
        for (int i = n - 1; i >= 0; i--)
        {
            int[] count = (int[])original.Clone();

            // Use target[0 ... i-1]
            bool possible = true;

            for (int j = 0; j < i; j++)
            {
                int x = target[j] - 'a';

                count[x]--;

                if (count[x] < 0)
                {
                    possible = false;
                    break;
                }
            }

            if (!possible)
                continue;

            // At position i, we need a character
            // strictly greater than target[i]
            int cur = target[i] - 'a';

            for (int c = cur + 1; c < 26; c++)
            {
                if (count[c] > 0)
                {
                    count[c]--;

                    string ans = target.Substring(0, i);

                    ans += (char)('a' + c);

                    // Put remaining characters
                    // in smallest lexicographical order
                    for (int k = 0; k < 26; k++)
                    {
                        ans += new string(
                            (char)('a' + k),
                            count[k]
                        );
                    }

                    return ans;
                }
            }
        }

        return "";
    }
}