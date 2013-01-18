using Meton.Liegen.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meton.Liegen
{
    public class Parameter
    {
        public string Name { get; private set; }
        public object Value { get; private set; }

        // multipart/form-data
        public string FileName { get; set; }

        public Parameter(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        public Parameter(string name, byte[] value, string fileName)
        {
            this.Name = name;
            this.Value = value;
            this.FileName = fileName;
        }

        public override string ToString()
        {
            var v = string.Empty;
            if (Value is bool)
            {
                v = Value.ToString().ToLower();
            }
            else
            {
                v = Value.ToString();
            }
            return Name.UrlEncode() + "=" + v.UrlEncode();
        }
    }

    public class ParameterCollection : IEnumerable<Parameter>
    {
        private List<Parameter> list = new List<Parameter>();

        public ParameterCollection()
        {
        }

        public ParameterCollection(Parameter parameter)
        {
            this.list.Add(parameter);
        }

        public ParameterCollection(IEnumerable<Parameter> parameters)
        {
            this.list.AddRange(parameters);
        }

        public ParameterCollection(params Parameter[] parameters)
        {
            this.list.AddRange(parameters.AsEnumerable());
        }

        public void Add(Parameter parameter)
        {
            this.list.Add(parameter);
        }

        public void Add(string key, object value)
        {
            this.list.Add(new Parameter(key, value));
        }

        public void Add(IEnumerable<Parameter> parameters)
        {
            this.list.AddRange(parameters);
        }

        public IEnumerator<Parameter> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class ParameterExtensions
    {
        public static string ToUrlParameter(this IEnumerable<Parameter> parameters)
        {
            return parameters
                .Where(p => p.Value != null)
                .Select(p => p.ToString())
                .Aggregate(new StringBuilder(), (sb, o) => (sb.Length == 0) ? sb.Append(o) : sb.Append("&" + o))
                .ToString();
        }
    }
}