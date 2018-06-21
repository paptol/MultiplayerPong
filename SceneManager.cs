using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Threading;


namespace PongGame
{
    class SceneManager : GameWindow
    {
        Scene scene;
        public static string diff = null;
        public static string multi = null;
        static int width = 0;
        static int height = 0;

        public delegate void SceneDelegate(FrameEventArgs e);
        public SceneDelegate renderer;
        public SceneDelegate updater;
        GameScene a;

        public SceneManager()
        {
           
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);

            base.Width = 1024;
            base.Height = 512;
            SceneManager.width = Width;
            SceneManager.height = Height;

            //Load the GUI
            GUI.SetUpGUI(Width, Height);
            scene = new MainMenuScene(this);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            updater(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            renderer(e);

            GL.Flush();
            SwapBuffers();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == 27) // ESC
            {
                Exit();
            }

            switch (e.KeyChar)
            {
                case '1':
                    Score();
               break;
             
                case '2': // Forward
                    AIMenu();
                    break;

                case '3':
                    StartNewGame2();
                   
                    
                    break;

                case '4':
                    string IP = null;
                    do
                    {

                        Console.WriteLine("Insert IP to conect witch Server!");
                        IP = Console.ReadLine();
                        Console.WriteLine(IP);
                        if (Console.ReadKey().Key == ConsoleKey.Escape) // ESC
                        {
                            break;
                        }


                    }
                    while (!Whois.MakeATest(IP));
                    Console.WriteLine("OK");
                    break;
               

                case '5':
                    diff = "easy";

                    StartNewGame();
                    break;

                case'6':
                    diff = "hard";
                    StartNewGame();
                    break;

                case '7':
                    
                    Whois.GetTopSingle();
                    Whois.DisplayTopSingle();

                    break;
                case '8':
                    Whois.GetTopMulti();
                    Whois.DisplayTopMulti();
                   
                    break;
                case '9':

                    StartMenu();

                     break;

            }               
           
        }

    

        public void StartNewGame()
        {
            scene = new GameScene(this);
           
        }
        public void StartNewGame2()
        {            
            scene = new GameScene2(this);
            
        }

        public void StartMenu()
        {
            
            scene = new MainMenuScene(this);
        }
        public void AIMenu()
        {

            scene = new AIDificulty(this);
        }
        public void Score()
        {
;            scene = new MultiScore(this);
        }



        public static int WindowWidth
        {
            get { return width; }
        }

        public static int WindowHeight
        {
            get { return height; }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            SceneManager.width = Width;
            SceneManager.height = Height;

            //Load the GUI
            GUI.SetUpGUI(Width, Height);
        }
    }

}

