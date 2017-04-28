using SharpGL;
using SharpGL.SceneGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double rotation = 0;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void OpenGLControl_OpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            var gl = args.OpenGL;
            gl.ClearColor(0.3f, 0.3f, 0.3f, 0.3f);
        }

        //private void OpenGLControl_OpenGLDraw(object sender, OpenGLEventArgs args)
        //{
        //    var gl = args.OpenGL;

        //    gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

        //    //gl.Rotate(15, 15, 15, 15);

        //    //gl.DepthRange(90,0.75);



        //    gl.Enable(OpenGL.GL_DEPTH_TEST);
        //    gl.DepthFunc(OpenGL.GL_LESS);

        //    gl.LoadIdentity();

        //    //gl.LookAt(0, 0, 0.5,    0, 0, 0,   0, 1, 0);
        //    //gl.Perspective(45.0f, 350/350 , 0.0f, -1.0f); // перспективная матрица
        //    //gl.Ortho(0.0, 1.0, 0.0, 1.0, -1.0, 1.0); // ортогональная - не нужна

        //    gl.Begin(OpenGL.GL_QUADS);
        //    //задняя стена
        //    gl.Color(0f, 1f, 0f);
        //    gl.Vertex4d(-0.5, -0.5, 0, 1);
        //    gl.Vertex4d(0.5, -0.5, 0, 1);
        //    gl.Vertex4d(0.5, 0.5, 0, 1);
        //    gl.Vertex4d(-0.5, 0.5, 0, 1);
        //    gl.End();

        //    if (a)
        //    {
        //        draw1(args);
        //    }


        //    //отрисовка стен, пола и потолка
        //    gl.Begin(OpenGL.GL_QUADS);
        //    gl.Color(0f, 1f, 1f);
        //    // левая
        //    gl.Vertex4d(-0.5, -0.5, 0, 1);
        //    gl.Vertex4d(-0.5, -0.5, 1, 1);
        //    gl.Vertex4d(-0.5, 0.5, 1, 1);
        //    gl.Vertex4d(-0.5, 0.5, 0, 1);
        //    // потолок
        //    gl.Vertex4d(0.5, 0.5, 0, 1);
        //    gl.Vertex4d(0.5, 0.5, 1, 1);
        //    gl.Vertex4d(-0.5, 0.5, 1, 1);
        //    gl.Vertex4d(-0.5, 0.5, 0, 1);
        //    //пол
        //    gl.Vertex4d(0.5, -0.5, 0, 1);
        //    gl.Vertex4d(0.5, -0.5, 1, 1);
        //    gl.Vertex4d(-0.5, -0.5, 1, 1);
        //    gl.Vertex4d(-0.5, -0.5, 0, 1);
        //    //правая
        //    gl.Vertex4d(0.5, -0.5, 0, 1);
        //    gl.Vertex4d(0.5, -0.5, 1, 1);
        //    gl.Vertex4d(0.5, 0.5, 1, 1);
        //    gl.Vertex4d(0.5, 0.5, 0, 1);

        //    gl.End();




        //}

        private void OpenGLControl_OpenGLDraw(object sender, OpenGLEventArgs args)
        {
            //var gl = args.OpenGL;
            //gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //gl.Begin(OpenGL.GL_TRIANGLES);
            //gl.Color(0f, 1f, 0f);
            //gl.Vertex(-1f, -1f);
            //gl.Vertex(0f, 1f);
            //gl.Vertex(1f, -1f);
            //gl.End();

            //  Get the OpenGL object.
            OpenGL gl = args.OpenGL;

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Load the identity matrix.
            gl.LoadIdentity();

            //  Rotate around the Y axis.
            gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            //  Draw a coloured pyramid.
            gl.Begin(OpenGL.GL_TRIANGLES);
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            // a few more calls like this omitted for clarity!
            gl.End();

            //  Nudge the rotation.
            rotation += 3.0f;
        }
        private void OpenGLControl_Resized(object sender, OpenGLEventArgs args)
        {
            //  Get the OpenGL object.
            OpenGL gl = args.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Use the 'look at' helper function to position and aim the camera.
            gl.LookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        //private void draw1(OpenGLEventArgs args)
        //{
        //    var gl = args.OpenGL;
        //    gl.Begin(OpenGL.GL_QUADS);
        //    gl.Color(1f, 1f, 0f);
        //    gl.Vertex4d(0.5, -0.5, 0, 1);
        //    gl.Vertex4d(1, -0.5, 1.2, 1);
        //    gl.Vertex4d(1, 0.5, 1.2, 1);
        //    gl.Vertex4d(0.5, 0.5, 0, 1);
        //    gl.End();
        //}
    }
}

