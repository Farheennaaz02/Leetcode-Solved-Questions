public class Solution
{
    public int[] MovesToStamp(string stamp, string target)
    {
        int m = stamp.Length;
        int n = target.Length;

        // Target ko char array mein convert kar rahe hain
        // taaki characters ko '*' se replace kar saken.
        char[] arr = target.ToCharArray();

        // Yahan stamping positions store hongi.
        List<int> answer = new();

        // Marks whether a window has already been stamped.
        bool[] visited = new bool[n];

        // Count of characters already converted to '*'
        int stars = 0;

        // Jab tak poori string '*' na ban jaye
        while (stars < n)
        {
            bool stampedInThisRound = false;

            // Har possible window check karo
            for (int i = 0; i <= n - m; i++)
            {
                // Agar is window ko pehle process kar chuke hain
                // to dobara check mat karo.
                if (visited[i])
                    continue;

                // Check:
                // Kya stamp is window par apply ho sakta hai?
                if (CanStamp(arr, i, stamp))
                {
                    // Window ko '*' mein convert karo
                    int newlyCreatedStars = DoStamp(arr, i, m);

                    // Agar koi naya character '*' bana hai
                    if (newlyCreatedStars > 0)
                    {
                        stars += newlyCreatedStars;
                        stampedInThisRound = true;

                        // Position save karo
                        answer.Add(i);
                    }

                    visited[i] = true;

                    // Agar poori string '*' ban gayi
                    if (stars == n)
                        break;
                }
            }

            // Agar poore round mein ek bhi stamp nahi laga
            // to answer impossible hai.
            if (!stampedInThisRound)
                return Array.Empty<int>();
        }

        // Hum reverse process mein positions collect kar rahe the.
        // Isliye final answer reverse karna padega.
        answer.Reverse();

        return answer.ToArray();
    }

    //--------------------------------------------------
    // Check whether stamp can be applied at position start
    //--------------------------------------------------
    private bool CanStamp(char[] target, int start, string stamp)
    {
        bool hasRealMatch = false;

        for (int j = 0; j < stamp.Length; j++)
        {
            // '*' wildcard ki tarah behave karta hai
            if (target[start + j] == '*')
                continue;

            // Character mismatch
            if (target[start + j] != stamp[j])
                return false;

            // Kam se kam ek real character match hua
            hasRealMatch = true;
        }

        // Sirf "***" ko dobara stamp nahi karna
        return hasRealMatch;
    }

    //--------------------------------------------------
    // Convert matched window into stars
    //--------------------------------------------------
    private int DoStamp(char[] target, int start, int stampLength)
    {
        int starsCreated = 0;

        for (int j = 0; j < stampLength; j++)
        {
            if (target[start + j] != '*')
            {
                target[start + j] = '*';
                starsCreated++;
            }
        }

        return starsCreated;
    }
}