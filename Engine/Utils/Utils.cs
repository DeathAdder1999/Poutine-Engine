using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Utils
{
    private static readonly DateTime Epoch = new DateTime(1970, 1, 1); 

    //TODO verify if it works
    public static string GetUniqueReference()
    {
        return Guid.NewGuid().ToString();
    }

    public static long GetCurrentTimeMillis()
    {
        return (long) (DateTime.UtcNow - Epoch).TotalMilliseconds;
    }
}

