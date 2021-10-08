using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using Engine.ErrorHandler;

namespace Engine.IO
{
    public class PoutineXmlReader : IDisposable
    {
        private XmlReader _xmlReader;
        private bool disposedValue;

        public string Path { get; }

        public PoutineXmlReader(string path)
        {
            Path = path;
            _xmlReader = new XmlTextReader(path);
        }

        public PoutineXmlElement GetNextXmlElement()
        {
            var elementStack = new Stack<PoutineXmlElement>();
            PoutineXmlElement element = null;
            while (_xmlReader.Read())
            {
                switch (_xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        elementStack.Push(new PoutineXmlElement());
                        var currentElement = elementStack.Peek();
                        currentElement.Name = _xmlReader.Name;

                        AddAttributes(ref currentElement);

                        break;
                    case XmlNodeType.Text:
                        elementStack.Peek().Value = _xmlReader.Value;
                        break;
                    case XmlNodeType.EndElement:
                        var endedElement = elementStack.Pop();

                        if (!elementStack.Any())
                        {
                            element = endedElement;
                            break;
                        }
                        else
                        {
                            elementStack.Peek().Children.Add(endedElement);
                        }

                        break;
                }
            }

            return element;
        }



        private void AddAttributes(ref PoutineXmlElement element)
        {
            while (_xmlReader.MoveToNextAttribute())
            {
                element.Attributes.Add(_xmlReader.Name, _xmlReader.Value);
            }
        }

        

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _xmlReader.Dispose();
                }

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public class PoutineXmlElement
    {
        public string Name { get; internal set; }
        public string Value { get; internal set; }
        public bool IsEmpty => Name == string.Empty;
        public List<PoutineXmlElement> Children { get; internal set; }
        public Dictionary<string, string> Attributes { get; internal set; }


        public PoutineXmlElement(string name, string value, List<PoutineXmlElement> children, Dictionary<string, string> attributes)
        {
            Name = name;
            Value = value;
            Children = children;
            Attributes = attributes;
        }

        public PoutineXmlElement()
        {
            Name = string.Empty;
            Value = string.Empty;
            Children = new List<PoutineXmlElement>();
            Attributes = new Dictionary<string, string>();
        }
    }
}