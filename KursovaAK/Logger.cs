using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;

namespace KursovaSP
{
    public static class Logger
    {
        public static ILog Log { get; } = LogManager.GetLogger("LOGGER");


        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
