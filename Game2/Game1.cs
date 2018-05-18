using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3DModelingApp
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Matrix projectionMatrix;
        Matrix viewMatrix;
        Matrix worldMatrix;

        Model model; // переменная для хранения модели

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            viewMatrix = Matrix.CreateLookAt(new Vector3(0, 0, 6), new Vector3(0, 0, 0), Vector3.Up);

            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                (float)Window.ClientBounds.Width / (float)Window.ClientBounds.Height,
                1, 100);

            worldMatrix = Matrix.CreateWorld(new Vector3(0f, 0f, 0f), new Vector3(0, 0, -1), Vector3.Up);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            model = Content.Load<Model>("horseIn.max");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                worldMatrix *= Matrix.CreateRotationX(MathHelper.ToRadians(1));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                worldMatrix *= Matrix.CreateRotationX(-1 * MathHelper.ToRadians(1));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                worldMatrix *= Matrix.CreateRotationY(MathHelper.ToRadians(1));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                worldMatrix *= Matrix.CreateRotationY(-1 * MathHelper.ToRadians(1));
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.View = viewMatrix;
                    effect.World = worldMatrix;
                    effect.Projection = projectionMatrix;
                }
                mesh.Draw();
            }
            base.Draw(gameTime);
        }
    }
}