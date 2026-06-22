public class Solution {
    public string RemoveDuplicateLetters(string s) {
        int [] freq = new int [26];
        foreach ( char ch in s){
            freq[ch-'a']++;
        }
        HashSet <char > instack = new ();
        Stack <char > stack = new ();
        foreach ( char ch in s ){
            freq[ch-'a']--;
            if (instack.Contains(ch)){
                continue;
            }
            while (stack.Count>0&& stack.Peek()>ch&& freq[stack.Peek()-'a']>0){
                char removed = stack.Pop();
                instack.Remove ( removed);
            }
            stack.Push(ch);
            instack.Add(ch);
        }
         char [] result = stack.ToArray();
            Array.Reverse ( result );
          return new string (result);
    }
}