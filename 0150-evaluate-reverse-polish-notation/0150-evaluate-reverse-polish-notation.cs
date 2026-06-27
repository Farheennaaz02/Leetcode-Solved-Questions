public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack <int > stack = new ();
        foreach ( string i in tokens ){
            if ( i !="+"&& i!="-"&& i!="/"&&i!="*"){
                stack.Push(Convert.ToInt32(i));
            }
            else {
                int sec = stack.Pop();
                int first = stack.Pop();
                if ( i =="+"){
                    stack.Push ( first + sec );

                }
                else if ( i =="-"){
                    stack.Push( first - sec );

                }
                else if ( i =="*"){
                    stack.Push ( first * sec);
                }
                else{
                    stack.Push ( first / sec);
                }
            }
        }
        return stack.Peek ();
    }
}