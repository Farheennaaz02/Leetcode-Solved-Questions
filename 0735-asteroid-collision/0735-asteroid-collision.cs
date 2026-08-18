public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        Stack<int > stack  = new ();
        foreach ( int i in asteroids){
            bool destroyed = false;
            while (stack.Count>0&&stack.Peek()>0&&i<0){
                if ( stack.Peek()<-i){
                    stack.Pop();
                }
                else if (stack.Peek()==-i){
                    stack.Pop();
                    destroyed= true;
                    break;
                }
                else {
                    destroyed= true ;
                    break ;
                }
            }
            if (!destroyed){
                stack.Push(i);
            }
        }
        return  stack.Reverse().ToArray();
        
    }
}