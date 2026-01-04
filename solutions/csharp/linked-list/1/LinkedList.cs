public class Deque<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(T value)
        {
            this.Value = value;
        }
    }

    private Node? _head;
    private Node? _tail;
    private int _count;

    public Deque()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public void Push(T value)
    {
        Node newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
        }
        _count++;
    }

    public T Pop()
    {
        if (_head == null)
        {
            throw new ArgumentException("InvalidOperationException");
        }
        T result = _tail.Value;
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            var newTail = _tail.Previous;
            newTail.Next = null;
            _tail.Previous = null;
            _tail = newTail;
        }
        _count--;
        return result;
    }

    public void Unshift(T value)
    {
        Node newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            _count++;
        }
        else
        {
            _head.Previous = newNode;
            newNode.Next = _head;
            _head = newNode;
            _count++;
        }
    }

    public T Shift()
    {
        if (_head == null)
        {
            throw new ArgumentException("InvalidOperationException");
        }
        T result = _head.Value;
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            var newHead = _head.Next;
            newHead.Previous = null;
            _head = newHead;
        }
        _count--;
        return result;
    }
}