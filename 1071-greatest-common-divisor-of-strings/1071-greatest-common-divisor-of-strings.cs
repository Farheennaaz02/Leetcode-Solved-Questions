public class Solution {
    public string GcdOfStrings(string str1, string str2) {
    
        string new1= str1+str2;
        string  new2 = str2+str1;
        if (new1==new2){
            int len1= str1.Length;
            int len2= str2.Length;
           int gcd= GCD(len1,len2);
            string sub =str1.Substring (0,gcd);
            
            return sub ;
        }
        else {
            return "";
        }

        
    }
    public int GCD ( int a , int b){
        while ( b!=0){
            int temp = a%b;
            a=b;
            b=temp;
        }
        return a;
    }
}