namespace ThryDEngine.Engine
{
    /// <summary>
    /// Vector2 base class.
    /// </summary>
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2()
        {
            X = Zero().X;
            Y = Zero().Y;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns X and Y as 0.
        /// </summary>
        public static Vector2 Zero() => new(0, 0);
    }
}
