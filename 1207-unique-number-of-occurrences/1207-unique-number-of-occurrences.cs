public class Solution {
    public bool UniqueOccurrences(int[] arr) {
        Dictionary <int , int> freq = new ();
        foreach ( int i in arr){
            if (!freq.ContainsKey(i)){
                freq[i]=1;
            }
            freq[i]++;
        }
        HashSet<int> uni = new ();
        foreach ( int value  in freq.Values){
            if (uni.Contains(value)){
                return false;
            }
            else{
                uni.Add(value);
            }
        }
        return true ;

        
    }
}