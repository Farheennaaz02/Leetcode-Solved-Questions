public class Solution
{
    public int DistinctSubseqII(string s)
    {
        long[] end = new long[26];
        long MOD = 1000000007;

        foreach (char ch in s)
        {
            long total = 1;
            for (int i = 0; i < 26; i++)
                total = (total + end[i]) % MOD;

            end[ch - 'a'] = total;
        }

        long ans = 0;
        for (int i = 0; i < 26; i++)
            ans = (ans + end[i]) % MOD;

        return (int)ans;
    }
}