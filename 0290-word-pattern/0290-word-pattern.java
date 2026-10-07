class Solution {
    public boolean wordPattern(String pattern, String s) {
        String[] words = s.split (" ");
        if (pattern.length()!=  words.length){
            return false ;
        }
        // a=> dog 
        // dog=> a  hona chye isliye 2 hashmap 
        HashMap<Character, String > map = new HashMap<>();
        HashMap <String , Character > reversemap = new HashMap <>();
        for ( int i =0;i<pattern.length();i++){
            char c = pattern.charAt(i);
            String word = words[i];
            if (map.containsKey(c)){
                // map toh connnatins krta h 
                // but a!=dog h esa to return false 
                if (!map.get(c).equals(word)){
                    return false ;
                }
            }
            if (reversemap.containsKey(word)){
                if (reversemap.get (word)!=c){
                    return false ;
                }
            }
            map.put(c,word);
            reversemap.put(word ,c);

        }
        return true ;

        
    }
}