﻿namespace ThryDEngine.Engine
{
    public abstract class GameScreen
    {
        protected bool _isPopUp = false;
        public bool IsPopUp
        {
            get { return _isPopUp; }
            set { _isPopUp = value; }
        }

        protected bool _isExiting = false;
        public bool IsExiting
        {
            get { return _isExiting; }
            set { _isExiting = value; }
        }

        protected bool _isInFocus = false;
        public bool IsInFocus
        {
            get { return _isInFocus; }
            set { _isInFocus = value; }
        }

        protected ScreenManager _screenManager;
        public ScreenManager ScreenManager
        {
            get { return _screenManager; }
            set { _screenManager = value; }
        }

        public virtual void LoadContent() { }
        public virtual void UnloadContent() { }
        public virtual void Update()
        {
            if (_isExiting)
            {
                ScreenManager.RemoveScreen(this);
                _isExiting = false;
            }
        }
        public abstract void Draw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
        public virtual void ExitScreen()
        {
            _isExiting = true;
            ScreenManager.RemoveScreen(this);
        }
    }
}