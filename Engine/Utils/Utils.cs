using System;
using System.Collections.Generic;
using System.Numerics;

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

