using System;

namespace TanksVsDinos
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TD_Game game = new TD_Game())
            {
                game.Run();
            }
        }
    }
#endif
}

