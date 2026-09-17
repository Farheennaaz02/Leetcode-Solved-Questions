class Trie {
    class TrieNode{
        TrieNode [] child = new TrieNode[26];
        boolean isend =false ;

    }
    TrieNode root ;
    public Trie() {
         root = new TrieNode();
    }
    public void insert(String word) {
        TrieNode current =  root ;
        for ( char ch :word.toCharArray()){
            int index = ch-'a';
            if (current.child[index]== null){
                current.child[index]= new TrieNode();

            }
             current = current.child[index];
        }

        current.isend= true ;
    }
    
    public boolean search(String word) {
        TrieNode current = root;
        for ( char ch :word.toCharArray()){
            int index=ch-'a';
            if(current.child[index]==null){
                return false ;
            }
            current= current.child[index];
        }
        return current.isend ;
        
    }
    
    public boolean startsWith(String prefix) {
        TrieNode current = root;
        for( char ch :prefix.toCharArray()){
            int index = ch-'a';
            if (current.child[index]==null){
                return false ;
            }
            current = current.child[index];

        }
        return true ;
        
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.insert(word);
 * boolean param_2 = obj.search(word);
 * boolean param_3 = obj.startsWith(prefix);
 */