using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Numerics;
using SFML.System;
using SFML.Graphics;
using Color = SFML.Graphics.Color;
using Engine.Render;

namespace Engine.Core
{
    public class SelectionManager
    {
        private static SelectionManager _instance;

        public static SelectionManager Instance => _instance ?? (_instance = new SelectionManager());
        private readonly List<GameObject> _selection = new List<GameObject>();
        public EventHandler SelectionChanged;

        public int SelectionSize => _selection.Count;
        public bool IsEmpty => SelectionSize == 0;

        private SelectionManager()
        {

        }

        public void Select(GameObject gameObject)
        {
            Clear();
            gameObject.IsSelected = true;
            _selection.Add(gameObject);
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public void AddSelection(GameObject gameObject)
        {
            gameObject.IsSelected = true;
            _selection.Add(gameObject);
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public void MoveSelectionTo(PointF pos)
        {
            foreach (var selection in _selection)
            {
                selection.Transform.Position = new Vector2(pos.X, pos.Y);
            }
        }

        public void MoveSelectionBy(PointF delta)
        {
            foreach (var selection in _selection)
            {
                var pos = selection.Transform.Position;
                selection.Transform.Position = new Vector2(pos.X - delta.X, pos.Y - delta.Y);
            }
        }

        public void AddSelections(IEnumerable<GameObject> gameObjects)
        {
            //If selection contains the objects
            //if (_selection.Any(x => gameObjects.Any(y => y == x)))
            //{
              //  _selection.AddRange(gameObjects);
            //}

            foreach (var gameObject in gameObjects)
            {
                gameObject.IsSelected = true;
            }

            _selection.AddRange(gameObjects);
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveSelection(GameObject gameObject)
        {
            gameObject.IsSelected = false;
            _selection.Remove(gameObject);
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveLast()
        {
            _selection[_selection.Count - 1].IsSelected = false;
            _selection.RemoveAt(_selection.Count - 1);
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveFirst()
        {
            _selection[0].IsSelected = false;
            _selection.RemoveAt(0);
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Clear()
        {
            foreach (var gameObject in _selection)
            {
                gameObject.IsSelected = false;
            }

            _selection.Clear();
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public void DrawDebugGizmos()
        {
#if DEBUG
            /*
            if (_selection.Any())
            {
                var positions = new List<Vector2>();

                foreach(var selected in _selection)
                {
                    var r = selected.GetComponent<RenderComponent>();
                    positions.Add(selected.Transform.Position);
                }

                var boundingBox = PoutineMath.GetBoundingBox(positions);
                var centroid = PoutineMath.GetMeanOfPoints(positions);
                var rectangleDimensions = PoutineMath.GetRectangleFromPoints(boundingBox);
                var boundingRectangle = new Render.Shapes.Rectangle(rectangleDimensions.X, rectangleDimensions.Y, rectangleDimensions.Z, rectangleDimensions.W);

                var color = new Color(Color.Green);

                color.A = 100;
                boundingRectangle.FillColor = color;

                Render.Graphics.DrawArrows(new Vector2f(centroid.X, centroid.Y), new Vector2f(1f, 1f));
                Render.Graphics.Draw(boundingRectangle);
            }
            */
        #endif
        }
    }
}
