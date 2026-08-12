public class Solution {
    public int Compress(char[] chars) {
        int i=0;
        int index=0;
        int n =chars.Length;
        
        while (i<n){
            char currentchar = chars[i];
            int count =0;
            while(i<n&& chars[i]==currentchar){
                count++;
                i++;
            }
            chars[index]= currentchar;
            index++;
            if (count>1){
                string countstr = count.ToString();
                foreach ( char ch in countstr){
                    chars[index]=ch;
                    index++;
                }
            }
        }
        return index;
        
    }
}