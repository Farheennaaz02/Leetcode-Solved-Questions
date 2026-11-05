class Solution {
    public String minWindow(String s, String t) {

        int[] freq = new int[128];

        for (char c : t.toCharArray()) {
            freq[c]++;
        }

        int left = 0;
        int count = t.length();

        int minLen = Integer.MAX_VALUE;
        int start = 0;

        for (int right = 0; right < s.length(); right++) {

            char c = s.charAt(right);

            if (freq[c] > 0) {
                count--;
            }

            freq[c]--;

            while (count == 0) {

                if (right - left + 1 < minLen) {
                    minLen = right - left + 1;
                    start = left;
                }

                char ch = s.charAt(left);
                freq[ch]++;

                if (freq[ch] > 0) {
                    count++;
                }

                left++;
            }
        }

        if (minLen == Integer.MAX_VALUE) return "";

        return s.substring(start, start + minLen);
    }
}