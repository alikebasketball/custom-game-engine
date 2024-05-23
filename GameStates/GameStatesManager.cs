using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace custom_game_engine.GameStates
{
    public class GameStatesManager
    {
        private static GameStatesManager _instance;
        private Stack<GameStates> _screens = new Stack<GameStates>();
        private ContentManager _content;

        public static GameStatesManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameStatesManager();
                }
                return _instance;
            }
        }

        public void SetContent(ContentManager content)
        {
            _content = content;
        }

        public void AddScreen(GameStates screen) // Adds a new screen to the stack 
        {
            try
            {
                // Add the screen to the stack
                _screens.Push(screen);
                // Initialize the screen
                _screens.Peek().Initialize();
                // Call the LoadContent on the screen
                if (_content != null)
                {
                    _screens.Peek().LoadContent(_content);
                }
            }
            catch (Exception exception)
            {
                // Log the exception
                Console.WriteLine($"Exception Occurred: {exception.Message}");
            }
        }

        public void RemoveScreen() // Removes the top screen from the stack
        {
            if (_screens.Count > 0)
            {
                try
                {
                    var screen = _screens.Peek();
                    _screens.Pop();
                }
                catch (Exception exception)
                {
                    // Log the exception
                    Console.WriteLine($"Exception Occurred: {exception.Message}");
                }
            }
        }

        public void ClearScreen() // Clears all the screen from the list
        {
            _screens.Clear();
        }

        public void ChangeScreen(GameStates screen) // Removes all screens from the stack and adds a new one 
        {
            try
            {
                ClearScreen();
                AddScreen(screen);
            }
            catch (Exception exception)
            {
                // Log the exception
                Console.WriteLine($"Exception Occurred: {exception.Message}");
            }
        }

        public void Update(GameTime gameTime) // Updates the top screen
        {
            try
            {
                if (_screens.Count > 0)
                {
                    _screens.Peek().Update(gameTime);
                }
            }
            catch (Exception exception)
            {
                // Log the exception
                Console.WriteLine($"Exception Occurred: {exception.Message}");
            }
        }

        public void Draw(SpriteBatch spriteBatch) // Renders the top screen
        {
            try
            {
                if (_screens.Count > 0)
                {
                    _screens.Peek().Draw(spriteBatch);
                }
            }
            catch (Exception exception)
            {
                // Log the exception
                Console.WriteLine($"Exception Occurred: {exception.Message}");
            }
        }

        public void UnloadContent() // Unloads the content from the screen
        {
            foreach (GameStates state in _screens)
            {
                state.UnloadContent();
            }
        }

    }

}