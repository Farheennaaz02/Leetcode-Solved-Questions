class Solution {
    public int compress(char[] chars) {
        int read =0;
        int write =0;
        while (read<chars.length){
            int count=0;
            char ch = chars[read];
            while (read<chars.length&& chars[read]==ch){
                count ++;
                read ++;
            }
            chars[write]=ch;
            write++;
            if (count >1){
                String s = String.valueOf(count);
                for ( int i=0;i<s.length();i++){
                    chars[write]=s.charAt(i);
                    write++;
                }


            }
        }
        return write ;
        
    }
}