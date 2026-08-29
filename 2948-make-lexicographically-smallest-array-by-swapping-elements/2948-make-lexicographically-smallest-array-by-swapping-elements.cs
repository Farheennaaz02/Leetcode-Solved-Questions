public class Solution
{
    public int[] LexicographicallySmallestArray(int[] nums, int limit)
    {
        int n = nums.Length;

        // Store value + original index
        var arr = new (int value, int index)[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = (nums[i], i);
        }

        // Sort by value
        Array.Sort(arr, (a, b) => a.value.CompareTo(b.value));

        int[] result = new int[n];

        int start = 0;

        while (start < n)
        {
            int end = start;

            // Find the complete group
            while (end + 1 < n &&
                   arr[end + 1].value - arr[end].value <= limit)
            {
                end++;
            }

            // Get original indices of this group
            List<int> indices = new List<int>();

            for (int i = start; i <= end; i++)
            {
                indices.Add(arr[i].index);
            }

            // Smallest original indices first
            indices.Sort();

            // Values are already sorted
            for (int i = 0; i < indices.Count; i++)
            {
                result[indices[i]] = arr[start + i].value;
            }

            start = end + 1;
        }

        return result;
    }
}