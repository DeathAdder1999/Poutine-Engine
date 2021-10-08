using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Engine.Render.Shapes;
using SFML.Graphics;
using Engine;

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

    public static bool Contains(this ShapeBase s, PointF pos)
    {
        var bounds = s.GetGlobalBounds();
        return bounds.Top < pos.Y && bounds.Top + bounds.Height > pos.Y && bounds.Left < pos.X &&
               bounds.Left + bounds.Width > pos.X;
    }

    public static bool Contains(this Sprite s, PointF pos)
    {
        var bounds = s.GetGlobalBounds();
        return bounds.Top < pos.Y && bounds.Top + bounds.Height > pos.Y && bounds.Left < pos.X &&
               bounds.Left + bounds.Width > pos.X;
    }

    public static bool IsDefault<T>(this T inObj)
    {
        return EqualityComparer<T>.Default.Equals(inObj, default);
    }

    public static List<T> Copy<T>(this List<T> listToCopy)
    {
        var copy = new List<T>();
        copy.AddRange(listToCopy);
        return copy;
    }

    public static string ToXmlString(this Vector2 v)
    {
        return $"[{v.X} , {v.Y}]";
    }

    public static Dictionary<string, object> GetPersistentProperties(this object o)
    {
        var dict = new Dictionary<string, object>();

        if (o == null) 
        {
            return dict;
        }

        var type = o.GetType();
        var properties = type.GetProperties();

        foreach(var property in properties)
        {
            if(Attribute.IsDefined(property, typeof(PersistentProperty)))
            {
                var value = property.GetValue(o);
                dict.Add(property.Name, value);
            }
        }

        return dict;
    }

    public static bool IsNullOrEmpty(this string s)
    {
        return s == null || s == string.Empty;
    }
}

