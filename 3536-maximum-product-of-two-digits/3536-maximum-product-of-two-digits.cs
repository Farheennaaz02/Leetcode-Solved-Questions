public class Solution {
    public int MaxProduct(int n) {
        List <int > digit = new ();
        while (n>0){
            digit.Add(n%10);
            n=n/10;
        }

        digit.Sort ();
        int length = digit.Count;
        return digit[length-1]* digit[length-2];
        
    }
}