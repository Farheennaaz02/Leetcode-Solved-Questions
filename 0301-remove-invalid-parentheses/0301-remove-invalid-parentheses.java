class Solution {

    Set<String> result = new HashSet<>();

    public List<String> removeInvalidParentheses(String s) {

        int leftremove = 0;
        int rightremove = 0;

        for (char c : s.toCharArray()) {

            if (c == '(') {
                leftremove++;
            }

            else if (c == ')') {

                if (leftremove > 0) {
                    leftremove--;
                }
                else {
                    rightremove++;
                }
            }
        }

        solve(s, 0, 0, leftremove, rightremove, "");

        return new ArrayList<>(result);
    }

    private void solve(
        String s,
        int index,
        int balance,
        int leftremove,
        int rightremove,
        String current
    ) {

        // Base case
        if (index == s.length()) {

            if (balance == 0 &&
                leftremove == 0 &&
                rightremove == 0) {

                result.add(current);
            }

            return;
        }

        char c = s.charAt(index);

        // '('
        if (c == '(') {

            // Remove '('
            if (leftremove > 0) {
                solve(
                    s,
                    index + 1,
                    balance,
                    leftremove - 1,
                    rightremove,
                    current
                );
            }

            // Keep '('
            solve(
                s,
                index + 1,
                balance + 1,
                leftremove,
                rightremove,
                current + c
            );
        }

        // ')'
        else if (c == ')') {

            // Remove ')'
            if (rightremove > 0) {
                solve(
                    s,
                    index + 1,
                    balance,
                    leftremove,
                    rightremove - 1,
                    current
                );
            }

            // Keep ')' only when there is '(' available
            if (balance > 0) {
                solve(
                    s,
                    index + 1,
                    balance - 1,
                    leftremove,
                    rightremove,
                    current + c
                );
            }
        }

        // Normal character
        else {
            solve(
                s,
                index + 1,
                balance,
                leftremove,
                rightremove,
                current + c
            );
        }
    }
}