public class Solution {
    public IList<int> SequentialDigits(int low, int high) {

        // sliding window 
        string s = "123456789";
        List<int> ans= new ();
        for ( int i =2;i<=9 ;i++){
            for ( int start =0;start +i <=s.Length ;start++){
                int digit =int.Parse( s.Substring (start , i ));
                if ( digit >= low && digit <= high ){
                    ans.Add( digit);
                }

            }
        }
        return ans ;
    }
}