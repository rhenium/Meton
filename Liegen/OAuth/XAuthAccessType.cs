using System;

namespace Meton.Liegen.OAuth
{
    public struct XAuthAccessType
    {
        private enum EnumXAuthAccessType
        {
            Read,
            Write
        }

        private EnumXAuthAccessType _XAuthAccessType;

        private static XAuthAccessType _Read = new XAuthAccessType(EnumXAuthAccessType.Read);
        public static XAuthAccessType Read
        {
            get { return _Read; }
        }

        private static XAuthAccessType _Write = new XAuthAccessType(EnumXAuthAccessType.Write);
        public static XAuthAccessType Write
        {
            get { return _Write; }
        }

        public override string ToString()
        {
            switch (_XAuthAccessType)
            {
                case EnumXAuthAccessType.Read:
                    return "read";
                case EnumXAuthAccessType.Write:
                    return "write";
                default:
                    throw new InvalidCastException("Unknown XAuthAccessType: " + _XAuthAccessType.ToString());
            }
        }

        private XAuthAccessType(EnumXAuthAccessType enumType)
        {
            this._XAuthAccessType = enumType;
        }
    }
}
