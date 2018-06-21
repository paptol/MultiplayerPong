using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Drawing.Imaging;

namespace PongGame
{
    class AIDificulty : MainMenuScene
    {

        public AIDificulty(SceneManager sceneManager) : base(sceneManager)
        {

            // Set the title of the window
            sceneManager.Title = "Pong - Main Menu";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;


        }

        public new void Update(FrameEventArgs e)
        {
        }

        public new void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Width, sceneManager.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, sceneManager.Width, 0, sceneManager.Height, -1, 1);

            GUI.clearColour = Color.CornflowerBlue;

           // Display the Title
            float width = sceneManager.Width, height = sceneManager.Height, fontSize = Math.Min(width, height) / 12f;
            GUI.Label(new Rectangle(0, (int)(fontSize / 2f), (int)width, (int)(fontSize * 2f)), "Chose AI difficulty ", (int)fontSize, StringAlignment.Center);


            // AI Easy
            float aa = sceneManager.Width, bb = sceneManager.Height / 2, cc = Math.Min(aa, bb) / 10f;
            GUI.Label(new Rectangle(0, (int)(cc / 2f), (int)aa, (int)(cc * 15f)), "5. Easy", (int)cc, StringAlignment.Center);

            

            // AI Hard
            float rr = sceneManager.Width, tt = sceneManager.Height / 2, yy = Math.Min(rr, tt) / 10f;
            GUI.Label(new Rectangle(0, (int)(yy / 2f), (int)rr, (int)(yy * 21f)), "6. Hard ", (int)yy, StringAlignment.Center);

            // Return
            float pp = sceneManager.Width, ww = sceneManager.Height / 2, mm = Math.Min(pp, ww) / 10f;
            GUI.Label(new Rectangle(0, (int)(mm / 2f), (int)rr, (int)(mm * 27f)), "9. Return  ", (int)mm, StringAlignment.Center);





            GUI.Render();
        }
    }
}
