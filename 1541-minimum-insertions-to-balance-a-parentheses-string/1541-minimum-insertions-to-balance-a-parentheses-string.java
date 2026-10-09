
class Solution {
    public int minInsertions(String s) {
        int insertions = 0;
        int open = 0;

        for (int i = 0; i < s.length(); i++) {
            char ch = s.charAt(i);

            if (ch == '(') {
                open++;
            } 
            else {
                // If two consecutive ')' are not available
                if (i + 1 < s.length() && s.charAt(i + 1) == ')') {
                    i++;
                } 
                else {
                    // Insert one ')' to make a pair
                    insertions++;
                }

                // Match the pair )) with an opening (
                if (open > 0) {
                    open--;
                } 
                else {
                    // Insert '(' because no opening bracket exists
                    insertions++;
                }
            }
        }

        // Every remaining '(' needs two ')'
        insertions += open * 2;

        return insertions;
    }
}