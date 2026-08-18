public class Solution {
    public string RemoveStars(string s) {
        Stack <char > stack = new();
        foreach ( char  ch in s){
            if (ch!='*'){
                stack.Push(ch);
            }
            else{
                stack.Pop();
            }
        }
        return new string (stack.Reverse().ToArray());
        
    }
}