using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Extensions
{
    public static bool TryDequeue<T>(this Queue<T> queue, out T value)
    {
        try
        {
            value = queue.Dequeue();
        }
        catch (InvalidOperationException)
        {
            value = default;
            return false;
        }

        return true;
    }
}

