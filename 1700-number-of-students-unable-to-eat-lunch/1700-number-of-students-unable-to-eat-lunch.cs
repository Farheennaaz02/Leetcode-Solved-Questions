public class Solution {
    public int CountStudents(int[] students, int[] sandwiches) {
        Queue<int> queue= new Queue<int > (students);
        int index =0;
        int count =0;
        while (queue.Count>0){
            int std = queue.Dequeue();
            if ( std == sandwiches[index]){
                index++;
                count =0;
            }
            else{
                queue.Enqueue(std);
                count ++;
            }
            if ( count  == queue.Count ){
            break ;
        }
        }
        return queue.Count ;
    }
}