class Solution {
    public int minOperations(String s) {
        int n = s.length();
        
        boolean sorted = true ;
        for ( int i =1;i<n;i++){
            if (s.charAt(i)<s.charAt(i-1)){
                sorted= false;
                break ;
            }
        }
        if (sorted){
            return 0;
        }
        if (n==2){
            return -1;
        }
        // find min and max
        char minchar ='z';
        char maxchar='a';
        for ( int i =0;i<n;i++){
            char c = s.charAt(i);
            minchar = (char)Math.min(c, minchar);
            maxchar=(char)Math.max(c, maxchar);
        }
        if (s.charAt(0)==minchar|| s.charAt(n-1)==maxchar){
            return 1;
        }
        for ( int i=1;i<n-1;i++){
            char c = s.charAt(i);
            if (c==minchar|| c== maxchar){return 2;
            }
        }
        return 3;
    }
}