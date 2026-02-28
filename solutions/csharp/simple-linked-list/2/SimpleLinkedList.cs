using System.Collections;
using System.Threading;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public T Value { get; }
        public Node Next { get; set; }
        public Node(T value)
        {
            Value = value;
        }
    }
    //构造函数，初始化单链表
    public SimpleLinkedList()
    {
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
    public int Count => _count;

    //在链表头部增加一个值
    public void Push(T value)
    {
        Node newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
            _count++;
        }
        else
        {
            newNode.Next = _head;
            _head = newNode;
            _count++;
        }
    }

    //在链表移除并返回头部的一个值
    public T Pop()
    {
        T result = _head.Value;
        if (_head == null)
        {
            throw new InvalidOperationException("InvalidOperationException");
        }
        else
        {
            var newHead = _head.Next;
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