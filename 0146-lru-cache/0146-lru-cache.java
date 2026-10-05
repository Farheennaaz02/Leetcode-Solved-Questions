class LRUCache {
    class Node {
        //linked list banani h 
        int key ;
        int value ;
        Node  prev ;
        Node next ;// double ll m prev <- node-> next 
        Node  ( int key , int value ){
            this.key= key ;
            this .value = value;
        } 
    }
    int capacity ;
    HashMap<Integer,Node> map ;
    Node head ;
    Node tail ;
    public LRUCache(int capacity) {
        this.capacity = capacity ;
        map = new HashMap <>();
        head = new Node(0,0);//key ,val 
        tail = new Node (0,0);
        head.next = tail ;
        tail.prev = head ;
    }
    
    public int get(int key) {
        if (!map.containsKey(key)){
            return -1 ;
        }
        Node node = map.get(key);
        remove (node);
        add(node);
        return node.value;
    }
    public void put(int key, int value) {
        if (map.containsKey(key)){
            Node node= map.get(key);
            node.value = value;
            remove (node);
            add(node);

        }
        else{
            Node node = new Node (key , value );
            map.put(key , node);
            add (node);
            if (map.size()>capacity){
                Node lru = head.next ;
                remove (lru);
                map.remove (lru.key);
            }
        }
        
    }
    void remove (Node node){
        Node previous = node.prev;
        Node nextNode = node.next;
        previous.next = nextNode ;
        nextNode.prev= previous;
    }
    void add (Node node){
        Node previous = tail.prev;
        previous.next= node;
        node.prev = previous;
        node.next= tail;
        tail.prev = node;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.get(key);
 * obj.put(key,value);
 */