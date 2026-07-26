public class Solution {
    public bool CheckIfCanBreak(string s1, string s2) {
        char [] firststring = s1.ToArray();
        char [] secondstring = s2.ToArray ();
        Array.Sort (firststring );
        Array.Sort (secondstring);
        bool abreakb= true ;
        bool bbreaka= true;
    
        for ( int i =0;i<firststring.Length;i++){
            if (firststring[i]>secondstring[i]){
                bbreaka= false ;
            }
            if (firststring[i]<secondstring[i]){
                abreakb= false;
            }
            
        }
        return abreakb|| bbreaka;

        
    }
}