public class Solution {
    public string ShortestBeautifulSubstring(string s, int k) {
        // shortest beautiful ki length nikalni h 
        // konsi string h yeh print karana h 
        string ans ="";
        int left =0;
        int right=0;
        int count =0;
        int n = s.Length ;
        int minlen =int.MaxValue;
        while (right <n){
            if (s[right]=='1'){
                count ++; 
            }
            right ++;
            while (count==k){
                int len = right - left ;
                string curr= s.Substring ( left, len);
                if (len <minlen ||len==minlen&&curr.CompareTo(ans)<0){
                    minlen = len;
                    ans = curr;

                }
                if (s[left]=='1'){
                    count--;
                   
                }
                left++;
            }

        }
        return ans;
        
    }
}