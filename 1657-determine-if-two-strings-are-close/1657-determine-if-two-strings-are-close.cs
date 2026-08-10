public class Solution {
    public bool CloseStrings(string word1, string word2) {
        // base condition
        if (word1.Length!=word2.Length){
            return false;

        }
        // swaping => 2 only 
        HashSet <char > uni1= new  HashSet <char > ( word1);
        HashSet <char > uni2 = new HashSet <char > (word2);
        if (uni1.Count != uni2.Count ){
            return false ;
        }
        if (!uni1.SetEquals(uni2))
{
    return false;
}
        Dictionary <char , int > freq = new ();
        foreach ( char ch in word1){
            if (freq.ContainsKey(ch)){
                freq[ch]++;
            }
            else{
                freq[ch]=1;

            }
            
        }
        Dictionary <char , int > freq2= new ();
        foreach ( char ch in word2){
            if (freq2.ContainsKey(ch)){
                freq2[ch]++;

            }
            else{
                freq2[ch]=1;

            }
            
        }
        List <int > f1 = freq.Values.ToList ();
        List <int > f2 = freq2.Values.ToList ();
        f1.Sort();
        f2.Sort ();
        if (f1.SequenceEqual(f2)){
            return true ;
        }
        else {
            return false;
        }




        
    }
}