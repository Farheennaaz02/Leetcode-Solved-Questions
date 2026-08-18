public class Solution {
    int index =0;
    public string DecodeString(string s) {
        return Decode (s);
    }
    public string Decode ( string s ){
        string result = "";
        int num =0;
        while ( index<s.Length){
            char c = s[index ];
            if ( char.IsDigit (c)){
                num = num *10+( c-'0');
            }
            else if ( c=='['){
                index ++;
                string inner = Decode ( s);
                for ( int i =0;i<num;i++){
                    result+=inner ;
                }
                num =0;
            }
            else if ( c==']'){
                return result ;
            }
            else {
                result+=c;

            }
            index++;
        }
        return result ;
    }
}