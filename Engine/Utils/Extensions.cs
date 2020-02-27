using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core.Input;
using SFML.Graphics;


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

    public static bool Contains(this Shape s, PointF pos)
    {
        var bounds = s.GetGlobalBounds();
        return bounds.Top > pos.Y && bounds.Top - bounds.Height < pos.Y && bounds.Left < pos.X &&
               bounds.Left + bounds.Width > pos.X;
    }

    public static bool Contains(this Sprite s, PointF pos)
    {
        var bounds = s.GetGlobalBounds();
        return bounds.Top > pos.Y && bounds.Top - bounds.Height < pos.Y && bounds.Left < pos.X &&
               bounds.Left + bounds.Width > pos.X;
    }
}

