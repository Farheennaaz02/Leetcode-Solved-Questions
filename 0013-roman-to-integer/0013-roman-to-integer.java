class Solution {
    public int romanToInt(String s) {
        int sum =0;
        for ( int i =0;i<s.length();i++){
            int current = value (s.charAt(i));
            if (i<s.length()-1&& current<value(s.charAt(i+1))){
                sum-= current ;
            }
            else {
                sum+=current;
            }
        }
        return sum;
    }
    public int value ( char ch ){
        if (ch =='I')return 1;
        if (ch  == 'V') return 5;
        if (ch == 'X')return 10;
        if (ch =='L')return 50;
        if (ch  == 'D') return 500;
        if (ch == 'C')return 100;
        return 1000;
    }
}