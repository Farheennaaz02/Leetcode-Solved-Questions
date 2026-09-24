class Solution {
    public String reverseWords(String s) {
        String [] parts = s.trim().split("\\s+");
        Collections.reverse(Arrays.asList(parts));
        return String.join(" ",parts);

        
    }
}