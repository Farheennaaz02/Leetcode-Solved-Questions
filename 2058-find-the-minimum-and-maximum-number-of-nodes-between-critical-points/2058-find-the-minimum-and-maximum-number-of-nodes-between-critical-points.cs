/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        ListNode prev = head ;
        ListNode current = head.next;
        int index =1;
        int first =-1;
        int last = -1;
        int mindis= int.MaxValue; 
        int maxdis = int.MinValue;
        while ( current.next != null){
            ListNode next = current.next ;
            if (current.val<prev.val&& current.val<next.val|| current.val>prev.val&& current.val>next.val){
                if ( first==-1){
                    first = index;
               }
               if ( last != -1){
                mindis= Math.Min (mindis,index - last );
               }
                last = index;
            }

            prev= current ;
            current= next;
            index++;
        }
        if (first ==-1 || first==last){
            return new int []{-1,-1};
        }
        maxdis = last- first;
        return new int []{mindis, maxdis};
        
    }
}