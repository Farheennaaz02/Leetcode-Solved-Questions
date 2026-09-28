class Solution {
    public int maxDepth(String s) {
        //split it and 
        int maxcount =0;
        int count =0;
        for ( int i =0;i<s.length();i++){
            char ch = s.charAt(i);
            if (ch=='('){
                count ++;
                maxcount= Math.max(maxcount , count );
            }
            if (ch == ')'){
                count --;
            }

        }
        return maxcount ;
        
    }
}