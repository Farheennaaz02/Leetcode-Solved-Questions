using System;
using System.Text;
using System.Numerics;

public class Solution
{
    const int LIMIT = 1000000;

    public string SmallestPalindrome(string s, int k)
    {
        int[] freq = new int[26];

        foreach (char c in s)
            freq[c - 'a']++;

        int[] half = new int[26];
        int halfLen = 0;
        char mid = '\0';

        for (int i = 0; i < 26; i++)
        {
            if ((freq[i] & 1) == 1)
                mid = (char)('a' + i);

            half[i] = freq[i] / 2;
            halfLen += half[i];
        }

        BigInteger ways = CountWays(half, halfLen);

        if (ways < k)
            return "";

        StringBuilder left = new StringBuilder();

        int remaining = halfLen;

        for (int pos = 0; pos < halfLen; pos++)
        {
            for (int c = 0; c < 26; c++)
            {
                if (half[c] == 0)
                    continue;

                BigInteger nextWays = ways * half[c] / remaining;

                if (nextWays >= k)
                {
                    left.Append((char)('a' + c));
                    ways = nextWays;
                    half[c]--;
                    remaining--;
                    break;
                }

                k -= (int)nextWays;
            }
        }

        string first = left.ToString();

        char[] rev = first.ToCharArray();
        Array.Reverse(rev);

        if (mid == '\0')
            return first + new string(rev);

        return first + mid + new string(rev);
    }

    private BigInteger CountWays(int[] cnt, int total)
    {
        BigInteger ans = Factorial(total);

        foreach (int x in cnt)
        {
            if (x > 1)
                ans /= Factorial(x);
        }

        return ans;
    }

    private BigInteger Factorial(int n)
    {
        BigInteger ans = 1;

        for (int i = 2; i <= n; i++)
            ans *= i;

        return ans;
    }
}
