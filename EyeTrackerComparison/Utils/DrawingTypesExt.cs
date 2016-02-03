using System.Drawing;

namespace Extensions
{
    public static class DrawingTypesExt
    {
        public static Point Center(this Rectangle aRef)
        {
            return new Point(aRef.X + aRef.Width / 2, aRef.Y + aRef.Height / 2);
        }
    }
}
