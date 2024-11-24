using System;

public class ArrayList
{
    private object[] data;
    private int SIZE;

    public ArrayList(int cap)
    {
        data = new object[cap];
        SIZE = 0;
    }

    public void Add(object e)
    {
        if (SIZE == data.Length) EnsureCapacity();
        data[SIZE++] = e;
    }

    private void EnsureCapacity()
    {
        object[] tempData = new object[2 * data.Length];
        Array.Copy(data, tempData, data.Length);
        data = tempData;
    }

    public Tile GetTile(int index)
    {
        if (index >= SIZE || index < 0) throw new IndexOutOfRangeException();
        return (Tile)data[index];
    }

    public void Set(int index, object e)
    {
        if (index >= SIZE || index < 0) throw new IndexOutOfRangeException();
        data[index] = e;
    }

    public int Size()
    {
        return SIZE;
    }
}
