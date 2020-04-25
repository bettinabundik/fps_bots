using System;

namespace FPSbots
{
    class Program
    {
        static void Main(string[] args)
        {
            GameModel model = new GameModel();

            model.TrainAllControllers();
        }
    }
}
