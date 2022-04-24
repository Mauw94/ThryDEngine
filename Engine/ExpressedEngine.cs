namespace ThryDEngine.Engine
{
    class Canvas : Form
    {
        public Canvas()
        {
            DoubleBuffered = true;
        }
    }
    public class ExpressedEngine
    {
        private readonly Vector2 _screenSize = new(512, 512);
        private readonly string _title = "ThryDEngine";
        private readonly Canvas? _window = null;

        public ExpressedEngine(Vector2 screenSize, string title)
        {
            _screenSize = screenSize;
            _title = title;

            _window = new();
            _window.Size = new Size((int)_screenSize.X, (int)_screenSize.Y);
            _window.Text = _title;

            Application.Run(_window);
        }
    }
}
