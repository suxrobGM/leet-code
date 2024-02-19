#nullable enable
namespace LeetCode.DataStructures;

public class Queue<T>
{
    private readonly LinkedList<T> list = new();

    public void Enqueue(T value)
    {
        list.AddLast(value);
    }

    public T? Dequeue()
    {
        return IsEmpty() ? default : list.RemoveFirst();
    }

    public T? Peek()
    {
        if (IsEmpty())
        {
            return default;
        }

        return list.Head is null ? default : list.Head.Value;
    }

    public bool IsEmpty()
    {
        return list.IsEmpty();
    }
}
