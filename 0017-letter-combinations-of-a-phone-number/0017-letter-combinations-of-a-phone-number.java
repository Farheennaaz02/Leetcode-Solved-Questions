class Solution {
    public List<String> letterCombinations(String digits) {
        List <String> result = new ArrayList ();
        if ( digits.length() == 0){
            return result ;
        }
        String[] map = {
            "","","abc", "def","ghi","jkl","mno","pqrs","tuv","wxyz"
        };
        solve(digits , 0 , "",result  , map );
        return result ;
        
    }
    void solve (String digits , int index , String temp , List <String> result , String[] map ){
        if ( index == digits.length() ){
            result.add (temp);
            return ;
        }
        String letters = map[digits.charAt(index) -'0'];
        for (char ch :letters.toCharArray()){
            solve ( digits , index+1 , temp+ch , result , map );
        }

    }

}