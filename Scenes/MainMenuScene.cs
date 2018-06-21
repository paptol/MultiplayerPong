using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Drawing.Imaging;

namespace PongGame
{
    class MainMenuScene : Scene, IScene
    {
        public MainMenuScene(SceneManager sceneManager) : base(sceneManager)
        {
            // Set the title of the window
            sceneManager.Title = "Pong - Main Menu";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;

        }



        public void Update(FrameEventArgs e)
        {
        }

        public void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Width, sceneManager.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, sceneManager.Width, 0, sceneManager.Height, -1, 1);

            GUI.clearColour = Color.CornflowerBlue;

            //Display the Title
            float width = sceneManager.Width, height = sceneManager.Height, fontSize = Math.Min(width, height) / 10f;
            GUI.Label(new Rectangle(0, (int)(fontSize / 2f), (int)width, (int)(fontSize * 2f)), "Pong Game", (int)fontSize, StringAlignment.Center);

            // Top Score
            float aa = sceneManager.Width, bb = sceneManager.Height/2, cc = Math.Min(aa, bb) / 10f;
            GUI.Label(new Rectangle(0, (int)(cc / 2f), (int)aa, (int)(cc * 15f)), " 1. Display highscores", (int)cc, StringAlignment.Center);

            // New Single
            float qq = sceneManager.Width, ww = sceneManager.Height / 2, ee = Math.Min(qq, ww) / 10f;
            GUI.Label(new Rectangle(0, (int)(ee / 2f), (int)qq, (int)(ee * 18f)), " 2. Start Single Player ", (int)ee, StringAlignment.Center);

            // New Multi
            float rr = sceneManager.Width, tt = sceneManager.Height / 2, yy = Math.Min(rr, tt) / 10f;
            GUI.Label(new Rectangle(0, (int)(yy / 2f), (int)rr, (int)(yy * 21f)), "       3. Start multiplayer game ", (int)yy, StringAlignment.Center);

            // Networked multi 
            // Top Score
            float zz = sceneManager.Width, xx = sceneManager.Height / 2, vv = Math.Min(zz, xx) / 10f;
            GUI.Label(new Rectangle(0, (int)(vv / 2f), (int)zz, (int)(vv * 24f)), "       4. Start Networked game", (int)vv, StringAlignment.Center);




            GUI.Render();
        }
    }
}