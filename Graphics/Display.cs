﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using NLog;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Geometry;

namespace Graphics
{
    class Display : IDisposable
    {
        private readonly GameWindow _window;
        private readonly Stopwatch _loopTimeStopwatch;
        private readonly Stopwatch _fpsLoggerStopwatch;
        private readonly Logger _logger;
        private readonly int _fpsRefreshTime;
        private int _frameCounter;
        private readonly List<BallToIcosahedron> _balls;
        private Pose _cameraPose;

        public Display()
        {
            _balls = new List<BallToIcosahedron>();
            _window = new GameWindow();
            _logger = LogManager.GetCurrentClassLogger();
            _loopTimeStopwatch = new Stopwatch();
            _fpsLoggerStopwatch = new Stopwatch();
            _cameraPose = new Pose(new Position(0, 0, 0), new Orientation(0, 0, -1));

            _frameCounter = 0;
            _fpsRefreshTime = 2;

            _window.Load += OnLoad;
            _window.Resize += OnResize;
            _window.UpdateFrame += UpdateFrame;
            _window.RenderFrame += RenderFrame;
        }

        public void Dispose()
        {
            _window.Dispose();
        }

        public void Run()
        {
            _logger.Info("starting display");
            _loopTimeStopwatch.Restart();
            _fpsLoggerStopwatch.Restart();
            _window.Run(60);
        }

        public void AddBall(Ball ball)
        {
            _balls.Add(new BallToIcosahedron(ball));
        }

        private void DrawTriangle(Triangle triangle, Color color)
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(color);

            foreach (var vertex in triangle.Vertices)
            {
                var vertexShifted = Position.Subtract(_cameraPose.Position, vertex);
                GL.Vertex3(vertexShifted.X, vertexShifted.Y, vertexShifted.Z);
            }

            GL.End();
        }

        private void RenderFrame(object sender, FrameEventArgs frameEventArgs)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);

            var colors = new List<Color>
            {
                Color.DarkGreen,
                Color.DarkRed,
                Color.DarkBlue,
                Color.DarkCyan,
                Color.DarkGoldenrod,
                Color.DarkGray,
                Color.DarkMagenta,
                Color.DarkKhaki,
                Color.DarkOrange,
                Color.DarkOrchid
            };
            var i = 0;

            foreach (var ballToIcosahedron in _balls)
            {
                ballToIcosahedron.UpdatePose();
                var faces = ballToIcosahedron.Icosahedron.CreateFaces();

                foreach (var face in faces)
                {
                    DrawTriangle(face, colors[i%10]);
                    i++;
                }

            }

            _window.SwapBuffers();
            _frameCounter++;
        }

        private void UpdateFrame(object sender, FrameEventArgs frameEventArgs)
        {
            if (_window.Keyboard[Key.Escape])
                _window.Exit();

            var loopTime = _loopTimeStopwatch.Elapsed.TotalSeconds;
            _loopTimeStopwatch.Restart();
            RaiseOnUpdate(loopTime);

            LogFps();
        }

        private void LogFps()
        {
            var fpsTime = _fpsLoggerStopwatch.Elapsed.TotalSeconds;

            if (!(fpsTime >= _fpsRefreshTime)) 
                return;

            var fps = _frameCounter/fpsTime;
            _fpsLoggerStopwatch.Restart();
            _frameCounter = 0;
            _logger.Info("running with " + fps.ToString("N1") + " FPS");
        }

        private void RaiseOnUpdate(double timeElapsed)
        {
            if (OnUpdate != null)
                OnUpdate(timeElapsed);
        }

        private void OnResize(object sender, EventArgs eventArgs)
        {
            GL.Viewport(0, 0, _window.Width, _window.Height);
        }

        private void OnLoad(object sender, EventArgs eventArgs)
        {
            _window.VSync = VSyncMode.On;
        }

        public delegate void UpdateHandler(double timeElapsed);

        public event UpdateHandler OnUpdate;
    }
}
