namespace ThryDEngine.Engine
{
    public class ScreenManager
    {
        readonly List<GameScreen> _screens = new();
        readonly List<GameScreen> _screensToUpdate = new();

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

        public void GetKeyDown(KeyEventArgs e)
        {
            foreach (var screen in _screens)
                if (screen.IsInFocus)
                    screen.GetKeyDown(e);
        }

        public void GetKeyUp(KeyEventArgs e)
        {
            foreach (var screen in _screens)
                if (screen.IsInFocus)
                    screen.GetKeyUp(e);
        }

        public void Draw()
        {
            foreach (var screen in _screens)
                screen.Draw();
        }

        public void AddScreen(GameScreen screen)
        {
            screen.ScreenManager = this;
            screen.OnLoad();

            _screens.Add(screen);
        }

        public void RemoveScreen(GameScreen screen)
        {
            _screens.Remove(screen);
            _screensToUpdate.Remove(screen);

            screen.Unload();
        }

        public GameScreen[] GetScreens() => _screens.ToArray();
    }
}
