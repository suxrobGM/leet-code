#nullable enable
namespace LeetCode.DataStructures;

public class DynamicQueue<T>
{
    private T[] queueArray;
    private int front;
    private int rear;
    private int size;

    public DynamicQueue(int initialCapacity = 16)
    {
        queueArray = new T[initialCapacity];
        front = 0;
        rear = -1;
        size = 0;
    }

    public void Enqueue(T element)
    {
        if (IsFull())
        {
            ResizeArray();
        }
        
        rear = (rear + 1) % queueArray.Length;
        queueArray[rear] = element;
        size++;
    }

    public T? Dequeue()
    {
        if (IsEmpty())
        {
            return default;
        }

        var element = queueArray[front];
        front = (front + 1) % queueArray.Length;
        size--;
        return element;
    }

    public T? Peek()
    {
        return IsEmpty() ? default : queueArray[front];
    }
    
    public bool IsFull()
    {
        return size == queueArray.Length;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    private void ResizeArray()
    {
        var newSize = queueArray.Length * 2;
        var newArray = new T[newSize];
        
        for (var i = 0; i < size; i++)
        {
            newArray[i] = queueArray[(front + i) % queueArray.Length];
        }
        
        queueArray = newArray;
        front = 0;
        rear = size - 1;
    }
}
