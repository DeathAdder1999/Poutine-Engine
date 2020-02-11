using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Utils
{

    //TODO verify if it works
    public static string GetUniqueReference()
    {
        return Guid.NewGuid().ToString();
    }
}

