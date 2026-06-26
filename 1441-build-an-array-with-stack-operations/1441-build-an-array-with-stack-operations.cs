public class Solution {
    public IList<string> BuildArray(int[] target, int n) {
        int j =0;
        int i =0;
        List <int>  arr = new ();
        List < string > result = new ();

        for ( int k =1 ; k<=n;k++){
            arr.Add(k);
        }
        while ( i <target.Length){
            if ( arr[j]==target[i]){
                result.Add( "Push");
                i++;
                j++;
            }
            else {
                result.Add("Push");
                result.Add("Pop");
                j++;

            }
        }
            return result ;}}