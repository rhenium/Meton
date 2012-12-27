using System;

namespace Meton.Liegen.OAuth
{
    public enum XAuthAccessType
    {
        Read,
        Write
    }

    public static class XAuthAccessTypeExtension
    {
        public static string ToStringExt(this XAuthAccessType type)
        {
            switch (type)
            {
                case XAuthAccessType.Read:
                    return "read";
                case XAuthAccessType.Write:
                    return "write";
                default:
                    throw new InvalidOperationException("Unknown XAuthAccessType: " + type.ToString());
            }
        }
    }
}
