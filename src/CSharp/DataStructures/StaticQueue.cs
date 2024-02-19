#nullable enable
namespace LeetCode.DataStructures;

public class StaticQueue<T>
{
    private readonly T[] queueArray;
    private readonly int maxSize;
    private int front;
    private int rear;

    public StaticQueue(int size)
    {
        maxSize = size;
        queueArray = new T[maxSize];
        front = -1;
        rear = -1;
    }

    public void Enqueue(T element)
    {
        if (IsFull()) // DynamicQueue is full. Cannot enqueue element.
        {
            return;
        }

        if (IsEmpty())
        {
            front = rear = 0;
        }
        else
        {
            rear = (rear + 1) % maxSize;
        }
        queueArray[rear] = element;
    }

    public T? Dequeue()
    {
        if (IsEmpty())
        {
            return default;
        }

        var element = queueArray[front];
        if (front == rear) // DynamicQueue has only one element
        {
            front = rear = -1;
        }
        else
        {
            front = (front + 1) % maxSize;
        }
        return element;
    }

    public T? Peek()
    {
        return IsEmpty() ? default : queueArray[front];
    }

    public bool IsFull()
    {
        return (rear + 1) % maxSize == front;
    }

    public bool IsEmpty()
    {
        return front == -1;
    }
}
