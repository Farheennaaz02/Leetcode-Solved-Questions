class Solution {
    class TrieNode {
        TrieNode [] kids = new TrieNode[26];
        List<String> suggestions = new ArrayList<>();
    }
    TrieNode root = new TrieNode();

    public List<List<String>> suggestedProducts(String[] products, String searchWord) {
        Arrays.sort (products);
        for (String product : products){
            TrieNode current = root;
            for (char ch : product.toCharArray()){
                int index =ch-'a';
                if (current.kids[index]==null){
                    current.kids[index]= new TrieNode();
                }
                current = current.kids[index];
                if (current.suggestions.size()<3){
                    current.suggestions.add(product);
                }
            }
        }
        List<List<String>>  result = new ArrayList<>();
        TrieNode current = root;
        for (char ch :searchWord.toCharArray()){
            int index =ch-'a';
            if (current!=null && current.kids[index]!=null ){
                current = current.kids[index];
                result.add(current.suggestions);
            }
            else{
                current = null;
                result.add(new ArrayList<>());
            }
        }
        return result ;

        
    }
}