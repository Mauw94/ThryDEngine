﻿namespace ThryDEngine.Engine
{
    class Canvas : Form
    {
        public Canvas()
        {
            DoubleBuffered = true;
        }
    }

    public abstract class ExpressedEngine
    {
        public Color BackgroundColor { get; set; } = Color.White;
        private static List<Shape2D> Shapes { get; set; } = new();
        private static List<Sprite2D> Sprites { get; set; } = new();

        private readonly Vector2 _screenSize = new(512, 512);
        private readonly string _title = "ThryDEngine";
        private readonly Canvas? _window = null;
        private readonly Thread? _gameLoopThread = null;

        public ExpressedEngine(Vector2 screenSize, string title)
        {
            Log.Info("Game is starting..");

            _screenSize = screenSize;
            _title = title;

            _window = new();
            _window.Size = new Size((int)_screenSize.X, (int)_screenSize.Y);
            _window.Text = _title;
            _window.Paint += Renderer!;

            _gameLoopThread = new(GameLoop);
            _gameLoopThread.Start();

            Application.Run(_window);
        }

        public abstract void OnLoad();
        public abstract void Initialize();
        public abstract void Update();
        public abstract void Draw();

        public static void RegisterShape(Shape2D shape) => Shapes.Add(shape);
        public static void UnRegisterShape(Shape2D shape) => Shapes.Remove(shape);
        public static void RegisterSprite(Sprite2D sprite) => Sprites.Add(sprite);
        public static void UnRegisterSprite(Sprite2D sprite) => Sprites.Remove(sprite);

        void GameLoop()
        {
            if (_gameLoopThread == null) return;

            OnLoad();

            while (_gameLoopThread.IsAlive)
            {
                try
                {
                    // Order matters here.
                    Draw();
                    _window!.BeginInvoke((MethodInvoker)delegate { _window.Refresh(); });
                    Update();
                    Thread.Sleep(1);
                }
                catch
                {
                    Log.Error("game window has not been found. waiting..");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackgroundColor);

            foreach (var shape in Shapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }

            foreach (var sprite in Sprites)
            {
                g.DrawImage(sprite.Sprite, sprite.Position.X, sprite.Position.Y, sprite.Scale.X, sprite.Scale.Y);
            }
        }
    }

}
