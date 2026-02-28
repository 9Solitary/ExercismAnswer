using System.Collections;
using System.Threading;

public class SimpleLinkedList<T> : IEnumerable<T>
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
    //构造函数，初始化单链表
    public SimpleLinkedList()
    {
        _count = 0;
        _head = null;
        _tail = null;
    }

    public SimpleLinkedList(T value)
    {
        Push(value);
    }

    public SimpleLinkedList(IEnumerable<T> collection)
    {
        foreach (var value in collection)
        {
            Push(value);
        }
    }
    private int _count;
    private Node? _head;
    private Node? _tail;
    public int Count => _count;

    //在链表头部增加一个值
    public void Push(T value)
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

    //在链表移除并返回头部的一个值
    public T Pop()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("InvalidOperationException");
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

    public IEnumerator<T> GetEnumerator()
    {
        Node? currentNode = _head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public SimpleLinkedList<T> Reverse()
    {
        SimpleLinkedList<T> reverseList = new SimpleLinkedList<T>();
        foreach (var value in this)
        {
            reverseList.Push(value);
        }
        return reverseList;
    }
}