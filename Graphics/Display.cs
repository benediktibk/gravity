﻿using System;
using System.Diagnostics;
using System.Drawing;
using NLog;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

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

        public Display()
        {
            _window = new GameWindow();
            _window.Load += OnLoad;
            _window.Resize += OnResize;
            _window.UpdateFrame += UpdateFrame;
            _window.RenderFrame += RenderFrame;

            _loopTimeStopwatch = new Stopwatch();
            _fpsLoggerStopwatch = new Stopwatch();

            _logger = LogManager.GetCurrentClassLogger();

            _frameCounter = 0;
            _fpsRefreshTime = 2;
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

        private void RenderFrame(object sender, FrameEventArgs frameEventArgs)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, -1.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();

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