namespace Supermarket_Management_system.Core;

public class HashTable
{
    private Node[] buckets;
    private int count;

    public HashTable()
    {
        buckets = new Node[16];
        count = 0;
    }

    private int Hash(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash = (hash * 31) + c;
        }
        if (hash < 0)
            hash = -hash;

        return hash % buckets.Length;
    }

    public void Add(string key, string value)
    {
        int index = Hash(key);
        Node node = buckets[index];


        while (node != null)
        {
            if (node.Key == key)
            {
                throw new Exception("Duplicate key: " + key);
            }
            node = node.Next;
        }
        Node newNode = new Node();
        newNode.Key = key;
        newNode.Value = value;
        newNode.Next = buckets[index];

        buckets[index] = newNode;
        count++;
    }
    public string Get(string key)
    {
        int index = Hash(key);
        Node node = buckets[index];

        while (node != null)
        {
            if (node.Key == key)
            {
                return node.Value;
        }
            node = node.Next;
        }
        return null;
    }


    public void Remove(string key)
    {
        int index = Hash(key);
        Node current = buckets[index];
        Node previous = null;

        while (current != null)
        {
            if (current.Key == key) 
            {
                if (previous == null)
                {
                    buckets[index] = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                count--;
                return;
            }
            previous = current;
            current = current.Next; 
        }
    }
}