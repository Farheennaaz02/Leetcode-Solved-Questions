/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    public int pairSum(ListNode head) {
        // LL-> mid? -> mid se reverse -> first half+sec half -> max ?
        // mid nikalenge 
        ListNode fast = head ;
        ListNode slow = head ;
        while ( fast!=null && fast.next!=null){
            fast= fast.next.next;
            slow = slow.next;// slow is mid now 
        }
        // reveser 
        ListNode prev = null;
        while ( slow != null){
            ListNode next = slow.next;
            slow.next = prev;
            prev= slow ;
            slow = next ;// prev is mid  now 
        }
        // max find ouut 
        ListNode first = head ;
        ListNode sec= prev;
        int max = 0 ;
        while (sec!= null){
            int sum = first.val + sec.val;
            max = Math.max (max , sum );
            first = first.next;
            sec= sec.next;


            
        }
        return max;


    }
}