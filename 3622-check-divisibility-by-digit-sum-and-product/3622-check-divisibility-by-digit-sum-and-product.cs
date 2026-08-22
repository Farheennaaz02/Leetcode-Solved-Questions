public class Solution {
    public bool CheckDivisibility(int n) {
        // true or false 
        int number= n;
        int sumofele= 0;
        int pro=1;
        while(n>0){
            int digit = n% 10;
            sumofele+=digit ;
            pro*=digit;
            n/=10;
        }
        if (number%(sumofele+pro)==0){
            return true ;
        }
        else{
            return false;
        }
       
        
    }
}