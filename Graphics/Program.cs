using System;

namespace Graphics
{
    internal class Program
    {
        [STAThread]
        public static void Main()
        {
            using(var display = new Display())
                display.Run();
        }
    }
}
