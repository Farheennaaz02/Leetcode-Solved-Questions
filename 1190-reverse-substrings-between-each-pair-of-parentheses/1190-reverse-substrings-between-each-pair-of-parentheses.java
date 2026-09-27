class Solution {
    public String reverseParentheses(String s) {

        Stack<String> stack = new Stack<>();
        StringBuilder curr = new StringBuilder();

        for (int i = 0; i < s.length(); i++) {

            char ch = s.charAt(i);

            if (ch == '(') {
                // Current string ko save karo
                stack.push(curr.toString());

                // Naya empty string start
                curr = new StringBuilder();
            }

            else if (ch == ')') {
                // Current part ko reverse karo
                curr.reverse();

                // Previous part ke saath jodo
                curr.insert(0, stack.pop());
            }

            else {
                // Normal character
                curr.append(ch);
            }
        }

        return curr.toString();
    }
}