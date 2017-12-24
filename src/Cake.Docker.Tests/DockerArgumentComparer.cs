using System;
using System.Collections;

namespace Cake.Docker.Tests
{
    public class DockerArgumentComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (ReferenceEquals(x, null) || !(x is DockerArgument))
            {
                throw new ArgumentException(nameof(x));
            }
            if (ReferenceEquals(y, null) ||!(y is DockerArgument))
            {
                throw new ArgumentNullException(nameof(y));
            }
            var a = (DockerArgument)x;
            var b = (DockerArgument)y;
            int keyCompare = CompareStrings(a.Key, b.Key);
            if (keyCompare != 0)
            {
                return keyCompare;
            }
            int valueCompare = CompareStrings(a.Value, b.Value);
            if (valueCompare != 0)
            {
                return valueCompare;
            }
            return a.Quoting.CompareTo(b.Quoting);

        }
        static int CompareStrings(string a, string b)
        {
            if (a == b)
            {
                return 0;
            }
            if (a == null)
            {
                return 1;
            }
            if (b == null)
            {
                return -1;
            }
            return a.CompareTo(b);
        }
    }
}
