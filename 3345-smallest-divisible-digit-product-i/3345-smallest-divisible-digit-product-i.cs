public class Solution {
    public int SmallestNumber(int n, int t) {
        // n is a starting digit
        int num = n;
        while (true){
            if (digitproduct(num)%t==0){
                return num;
            }
            num++;

        }



        
    }
    private int digitproduct(int x){
        int product=1;
        while(x>0){
            product = product *(x%10);
            x= x/10;
        }
        return product;
    }
}