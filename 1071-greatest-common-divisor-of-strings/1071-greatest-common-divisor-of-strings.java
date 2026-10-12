class Solution {
    public String gcdOfStrings(String str1, String str2) {
        String con1 = str1+str2;
        String con2= str2+str1;
        if (con1.equals(con2)){
            int len1 = str1.length();
            int len2= str2.length();
            int gcd = GCD (len1 , len2);
            return str1.substring(0, gcd);

        }
        else {
            return "";
        }
        
    }
    public int GCD ( int  a , int b ){
        while (b!=0){
            int temp= a%b;
            a=b;
            b= temp;
        }
        return a ;
    }
}