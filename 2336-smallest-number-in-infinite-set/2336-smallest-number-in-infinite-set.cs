public class SmallestInfiniteSet {
    int next =1;
    SortedSet <int > set = new ();

    public SmallestInfiniteSet() {
        
    }
    
    public int PopSmallest() {
        if ( set.Count >0){
            int x = set.Min ();
            set.Remove(x);
            return x;
        }
        return next++;
        
    }
    
    public void AddBack(int num) {
        if ( num<next){
            set.Add(num);
        }
        
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */