using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace custom_game_engine;

public class MainGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _slime, _background;

    public MainGame()

    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()    // TODO: Add your initialization logic here
    {
        base.Initialize();
    }

    protected override void LoadContent()   // TODO: use this.Content to load your game content here
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice); 

        _slime = Content.Load<Texture2D>("slime");
        _background = Content.Load<Texture2D>("Background");

    }

    protected override void Update(GameTime gameTime)   // TODO: Add your update logic here
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) // TODO: Add your drawing code here
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        int _width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int _height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        _spriteBatch.Begin();
        _spriteBatch.Draw(_background, new Rectangle(0,0,_width,_height), Color.WhiteSmoke);
        _spriteBatch.Draw(_slime, Vector2.Zero, Color.WhiteSmoke);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}