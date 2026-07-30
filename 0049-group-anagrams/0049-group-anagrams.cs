public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary <string,List<string>> map = new ();
        foreach ( string s in strs){
            char [] element = s.ToCharArray();
            Array.Sort (element);
            if (!map.ContainsKey(new string (element))){
                map[new string(element)]= new List <string >();

            }
            map [new string (element)].Add(s);
        }
        return map.Values.Cast<IList<string>>().ToList();
        
    }
}