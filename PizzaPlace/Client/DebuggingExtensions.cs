using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace PizzaPlace.Client
{
    public static class DebuggingExtensions
    {
        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj, obj.GetType());
        }
    }
}
