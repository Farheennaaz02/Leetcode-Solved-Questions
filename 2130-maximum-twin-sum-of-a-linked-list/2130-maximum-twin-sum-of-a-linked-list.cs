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
    public int PairSum(ListNode head) {
        ListNode fast = head ;
        ListNode slow = head ;
        while ( fast!=null && fast.next!= null){
            fast= fast.next.next;
            slow = slow.next;
        }

        ListNode prev=null;
        while (slow!= null){
            ListNode next = slow.next ;
            slow.next = prev;
            prev=slow ;
            slow = next;
        }
        ListNode first = head;
        ListNode sec = prev;
        int max =0;
        while ( sec!= null){
            int sum = first.val+ sec.val;
            max= Math.Max( max , sum );
            first= first.next ;
            sec= sec.next;
        }

        return max;
    }
}