namespace ThryDEngine.Engine
{
    public class ScreenManager
    {
        readonly List<GameScreen> _screens = new List<GameScreen>();
        readonly List<GameScreen> _screensToUpdate = new List<GameScreen>();

        public ScreenManager()
        {

        }

        public void Update()
        {
            _screensToUpdate.Clear();

            foreach (var screen in _screens)
                _screensToUpdate.Add(screen);

            while (_screensToUpdate.Count > 0)
            {
                var screen = _screensToUpdate[_screensToUpdate.Count - 1];
                _screensToUpdate.RemoveAt(_screensToUpdate.Count - 1);
                screen.Update();
            }
        }

        public void Draw()
        {
            foreach (var screen in _screens)
                screen.Draw();
        }

        public void AddScreen(GameScreen screen)
        {
            screen.ScreenManager = this;
            screen.LoadContent();

            _screens.Add(screen);
        }

        public void RemoveScreen(GameScreen screen)
        {
            _screens.Remove(screen);
            _screensToUpdate.Remove(screen);

            screen.UnloadContent();
        }

        public GameScreen[] GetScreens() => _screens.ToArray();
    }
}
