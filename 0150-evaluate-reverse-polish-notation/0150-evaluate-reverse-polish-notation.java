class Solution {
    public int evalRPN(String[] tokens) {

        Stack<Integer> stack = new Stack<>();

        for (String i : tokens) {

            if (!i.equals("+") && !i.equals("*") &&
                !i.equals("/") && !i.equals("-")) {

                stack.push(Integer.parseInt(i));
            }
            else {
                int sec = stack.pop();
                int first = stack.pop();

                if (i.equals("+")) {
                    stack.push(first + sec);
                }
                else if (i.equals("*")) {
                    stack.push(first * sec);
                }
                else if (i.equals("/")) {
                    stack.push(first / sec);
                }
                else {
                    stack.push(first - sec);
                }
            }
        }

        return stack.peek();
    }
}