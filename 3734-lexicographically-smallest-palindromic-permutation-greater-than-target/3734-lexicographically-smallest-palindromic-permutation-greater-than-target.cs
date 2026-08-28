public class Solution
{
    public string LexPalindromicPermutation(string s, string target)
    {
        int[] freq = new int[26];

        foreach (char c in s)
            freq[c - 'a']++;

        // A palindrome can have at most one odd-frequency character
        int odd = 0;
        char middle = '\0';

        for (int i = 0; i < 26; i++)
        {
            if (freq[i] % 2 == 1)
            {
                odd++;
                middle = (char)('a' + i);
            }
        }

        if (odd > 1)
            return "";

        int halfLen = s.Length / 2;

        // Characters available for left half
        int[] half = new int[26];

        for (int i = 0; i < 26; i++)
            half[i] = freq[i] / 2;

        char[] left = new char[halfLen];

        // Find smallest left half that can produce
        // palindrome > target
        if (!Build(left, 0, half, target, middle))
            return "";

        string leftPart = new string(left);

        char[] right = leftPart.ToCharArray();
        Array.Reverse(right);

        return leftPart
             + (middle == '\0' ? "" : middle.ToString())
             + new string(right);
    }

    private bool Build(
        char[] left,
        int pos,
        int[] half,
        string target,
        char middle)
    {
        int halfLen = left.Length;

        if (pos == halfLen)
        {
            string leftPart = new string(left);

            string palindrome =
                leftPart +
                (middle == '\0' ? "" : middle.ToString()) +
                Reverse(leftPart);

            return palindrome.CompareTo(target) > 0;
        }

        // Try smallest character first
        for (int c = 0; c < 26; c++)
        {
            if (half[c] == 0)
                continue;

            left[pos] = (char)('a' + c);
            half[c]--;

            if (CanStillBeGreater(left, pos, target, middle))
            {
                if (Build(left, pos + 1, half, target, middle))
                    return true;
            }

            half[c]++;
        }

        return false;
    }

    private bool CanStillBeGreater(
        char[] left,
        int pos,
        string target,
        char middle)
    {
        // Compare the already-built prefix with target.
        for (int i = 0; i <= pos; i++)
        {
            if (left[i] > target[i])
                return true;

            if (left[i] < target[i])
                return false;
        }

        // Prefix is equal so far.
        // We cannot decide yet.
        return true;
    }

    private string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}