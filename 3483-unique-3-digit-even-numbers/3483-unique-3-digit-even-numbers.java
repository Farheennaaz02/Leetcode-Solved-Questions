class Solution {
    public int totalNumbers(int[] digits) {
        // 3 digit banane h 
        int [] freq = new int [10];
        // freq nikalanege 
        for ( int digit : digits){
            freq[digit]++;
        }
        int count =0;
        // hundread place loop 
        for ( int i =1;i<=9;i++){
            if (freq[i]==0){
                continue;
            }
            freq[i]--;
             // tense place loop 
            for ( int j =0;j<=9;j++){
               if (freq[j]==0){
                 continue;
                }
                freq[j]--;
                // unit place loop
                for ( int k =0;k<=8;k+=2){
                   if ( freq[k]>0){
                   count ++;
                   }
                }
                freq[j]++;
            }
            freq[i]++;
        }
        return count ;
    }
}