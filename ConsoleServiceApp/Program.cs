using System;

namespace ConsoleServiceApp
{
    class ServiceStarter
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static ServiceStarter starter = null;
        private DoltServiceEngine engine;
        private ServiceStarter(string dbConfig)
        {
            logger.Info("Initializing DOLT Service Engine with " + dbConfig);
            engine = new DoltServiceEngine(dbConfig);
            try
            {
                engine.Initialize();
            }
            catch (Exception ex)
            {
                logger.Error("Failed to start DOLT Engine Thread: {}", ex.Message.ToString());
                engine = null;
            }
        }
        private ServiceStarter()
        {
            engine = new DoltServiceEngine();
        }
        static void Main(string[] args)
        {
            logger.Info("Starting DOLT Console Service");
            Console.WriteLine("Give me command");
            var cmd = Console.ReadLine();
            if (args.Length > 0)
            {
                Console.WriteLine("Argument: " + args[0]);
                starter = new ServiceStarter(args[0]);
            }
            else
            {
                starter = new ServiceStarter();
            }

            starter.start();
            Console.WriteLine("Enter 'stop' to halt:");
            cmd = Console.ReadLine();
            if (cmd.ToLower().Equals("stop"))
            {
                logger.Info("Stopping DOLT service");
                starter.stop();
            }

        }
        public void start()
        {
            logger.Debug("DOLT Daemon Start");
            initialize();
        }

        private void initialize()
        {
            if (engine != null)
            {
                logger.Info("Starting the DOLT Service Engine Thread");
                try
                {
                    engine.startEngine();
                }
                catch (Exception ex)
                {
                    logger.Error("Failed to start DOLT Service Engine: {}", ex.Message.ToString());
                }
                logger.Info("DOLT Service Engine Thread Started");
            }
            else
            {
                logger.Warn("Failed to start DOLT Service Engine Thread - the engine was missing from this starter.");
            }
        }

        public void stop()
        {
            logger.Debug("DOLT Daemon Stop");
            terminate();
        }
        public void terminate()
        {
            if (engine != null)
            {
                logger.Info("Stopping the DOLT Service Engine");
                try
                {
                    engine.stopEngine();
                    logger.Info("DOLT Service Engine stopped");
                }
                catch (Exception ex)
                {
                    logger.Error("Error Stopping DOLT Service Engine: ", ex.Message.ToString());
                }
            }
            else
            {
                logger.Warn("Failed to stop DOLT Service Engine Thread - the engine was missing from this starter.");
            }
        }

        private void printClasspath()
        {


        }
    }
}
