using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleServiceApp
{
    class DoltServiceEngine
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private string dbConfig;

        public static String DEFAULT_CONFIG = "dolt.xml";

        public DoltServiceEngine()
        {
        }

        public DoltServiceEngine(string dbConfig)
        {
            logger.Info("Initializing the Service Engine with configuration: {}.", dbConfig);
            this.dbConfig = dbConfig;
        }


        internal void Initialize()
        {
            throw new NotImplementedException();
        }

        internal void stopEngine()
        {
            throw new NotImplementedException();
        }

        internal void startEngine()
        {
            throw new NotImplementedException();
        }

        public Boolean isStopped()
        {
            
            return true;
        }

        public Boolean isStarted()
        {
            return true;
        }
    }
}
