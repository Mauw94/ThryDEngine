namespace ThryDEngine.Engine
{
    public class SpriteBatch
    {
        public static bool IsInitialized = false;

        private readonly Graphics _graphics;
        private readonly Vector2 _cameraPosition;
        private float _cameraAngle;

        public SpriteBatch(Graphics graphics, Vector2 cameraPosition, float cameraAngle)
        {
            _graphics = graphics;
            _cameraPosition = cameraPosition;
            _cameraAngle = cameraAngle;

            IsInitialized = true;
        }

        /// <summary>
        /// Draw image.
        /// </summary>
        public void Draw(Image image, float x, float y, float width, float height)
        {
            if (_graphics == null) return;
            _graphics.DrawImage(image, x, y, width, height);
        }

        /// <summary>
        /// Move camera.
        /// </summary>
        public void MoveCamera(float dx, float dy)
        {
            _cameraPosition.X += dx;
            _cameraPosition.Y += dy;
        }

        /// <summary>
        /// Rotate.
        /// </summary>
        public void Rotate(float angle)
        {
            _cameraAngle = angle;
        }
    }
}
