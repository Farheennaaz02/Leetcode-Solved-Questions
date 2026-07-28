public class Solution {
    public bool CheckPalindromeFormation(string a, string b) {
        return Check(a,b)|| Check(b,a);
    }

    public bool Check(string a, string b) {
        int left = 0;
        int right = a.Length-1;
        while (left <right && a[left]==b[right]){
            left ++;
            right --;
        }
        return Ispalindrome(a,left , right )|| Ispalindrome (b , left , right );
        
    }
    private bool Ispalindrome(string s , int left , int right){
        while (left <right ){
            if (s[left]!=s[right]){
                return false;

            }
            left ++;
            right --;
        }
        return true;
    }
}