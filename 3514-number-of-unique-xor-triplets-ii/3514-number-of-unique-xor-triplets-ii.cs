public class Solution
{
    public int UniqueXorTriplets(int[] nums)
    {
        const int MAX = 2048;

        bool[] one = new bool[MAX];
        bool[] two = new bool[MAX];
        bool[] three = new bool[MAX];

        foreach (int x in nums)
        {
            // Same element can be chosen multiple times (i <= j <= k)

            // Update 3-element XORs
            for (int v = 0; v < MAX; v++)
            {
                if (two[v])
                    three[v ^ x] = true;
            }

            // Update 2-element XORs
            for (int v = 0; v < MAX; v++)
            {
                if (one[v])
                    two[v ^ x] = true;
            }

            // One element
            one[x] = true;
        }

        // Handle repeated indices:
        // x ^ x = 0 and x ^ x ^ x = x
        foreach (int x in nums)
        {
            two[0] = true;      // (x, x)
            three[x] = true;    // (x, x, x)
        }

        int ans = 0;
        for (int i = 0; i < MAX; i++)
        {
            if (three[i])
                ans++;
        }

        return ans;
    }
}