using System.Diagnostics;

namespace ThryDEngine.Engine
{
    class Canvas : Form
    {
        public Canvas()
        {
            DoubleBuffered = true;
        }
    }

    /// <summary>
    /// The main loop for the game engine.
    /// </summary>
    public abstract class Game : IBaseGame
    {
        public Color BackgroundColor { get; set; } = Color.White;
        public Vector2 CameraPosition { get; set; } = Vector2.Zero();
        public float CameraAngle { get; set; } = 0f;
        public ScreenManager ScreenManager { get; private set; }
        public static Graphics Graphics { get; private set; }

        public static TimeSpan ElapsedGameTime { get; private set; }
        public static TimeSpan TotalGameTime => GetTotalElapsedGameTime();
        public static List<Sprite> Sprites { get; set; } = new();

        public Game Engine { get; private set; }

        private static Stopwatch _gameTime;

        private readonly Vector2 _screenSize = new(512, 512);
        private readonly string _title = "ThryDEngine";
        private readonly Canvas? _window = null;
        private readonly Thread? _gameLoopThread = null;

        public Game(Vector2 screenSize, string title)
        {
            Log.Info("Game is starting..");

            _screenSize = screenSize;
            _title = title;

            _window = new();
            _window.Size = new Size((int)_screenSize.X, (int)_screenSize.Y);
            _window.Text = _title;
            _window.Paint += Renderer!;
            _window.KeyDown += Window_KeyDown;
            _window.KeyUp += Window_KeyUp;

            _gameLoopThread = new(GameLoop);
            _gameLoopThread.Start();

            _gameTime = new();
            _gameTime.Start();

            ScreenManager = new();

            Engine = this;

            Application.Run(_window);
        }

        public abstract void OnLoad();
        public abstract void Unload();
        public abstract void Update();
        public abstract void Draw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);

        public static void RegisterSprite(Sprite sprite) => Sprites.Add(sprite);
        public static void UnRegisterSprite(Sprite sprite) => Sprites.Remove(sprite);

        private void Window_KeyDown(object? sender, KeyEventArgs e) => GetKeyDown(e);
        private void Window_KeyUp(object? sender, KeyEventArgs e) => GetKeyUp(e);

        private static TimeSpan GetTotalElapsedGameTime() => _gameTime.Elapsed;

        void GameLoop()
        {
            if (_gameLoopThread == null) return;

            OnLoad();

            while (_gameLoopThread.IsAlive)
            {
                try
                {
                    // Order matters here.
                    StartGameTimer();
                    Draw();
                    _window!.BeginInvoke((MethodInvoker)delegate { _window.Refresh(); });
                    Update();
                    Thread.Sleep(1);
                    StopGameTimer();
                }
                catch
                {
                    Log.Error("game window has not been found. waiting..");
                }
            }
        }

        static void StartGameTimer()
        {
            _gameTime = new();
            _gameTime.Start();
        }

        static void StopGameTimer()
        {
            _gameTime.Stop();
            ElapsedGameTime = _gameTime.Elapsed;
        }

        void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Graphics = g;

            g.Clear(BackgroundColor);

            g.TranslateTransform(CameraPosition.X, CameraPosition.Y);
            g.RotateTransform(CameraAngle);

            foreach (var sprite in Sprites)
                if (!sprite.IsReference)
                    g.DrawImage(sprite.Image, sprite.Position.X, sprite.Position.Y, sprite.Scale.X, sprite.Scale.Y);
        }
    }

}
