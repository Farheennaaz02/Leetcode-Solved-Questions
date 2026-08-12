public class Solution {
    public string ReverseWords(string s) {
        string [] word = s.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse (word);
        return string.Join (' ',word);
    }
}