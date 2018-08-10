using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using ExitGames.Logging;
using System.IO;
using ExitGames.Logging.Log4Net;
using log4net.Config;

namespace MyGameServer {
    //服务端
    public class MyGameServer : ApplicationBase {
        public static readonly ILogger log = LogManager.GetCurrentClassLogger();
        //处理链接
        protected override PeerBase CreatePeer(InitRequest initRequest) {
            log.Info("新建客户端链接+1");
            return new ClientPeer(initRequest);
        }

        //初始化
        protected override void Setup() {
            //初始化日志
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
            FileInfo configFileInfo = new FileInfo(Path.Combine( this.BinaryPath, "log4net.config"));
            if (configFileInfo.Exists) {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                XmlConfigurator.ConfigureAndWatch(configFileInfo);
            }
            log.Info("setup compeleted!");
        }

        //断开链接
        protected override void TearDown() {
            log.Info("服务器关闭了");
        }
    }
}
