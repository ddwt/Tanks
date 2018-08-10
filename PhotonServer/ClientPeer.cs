using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace MyGameServer {

    public class ClientPeer : Photon.SocketServer.ClientPeer {

        public ClientPeer(InitRequest initRequest) : base(initRequest) { }

        //断开链接处理
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail) {
            
        }

        //处理客户端请求
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters) {
            switch (operationRequest.OperationCode) {
                case 1:
                    MyGameServer.log.Info("收到了一个客户端请求");
                    //接收数据
                    Dictionary<byte, object> data = operationRequest.Parameters;
                    object intValue;
                    data.TryGetValue(1, out intValue);
                    object stringValue;
                    data.TryGetValue(2, out stringValue);
                    MyGameServer.log.Info("收到" + intValue.ToString() + stringValue.ToString());
                    //客户端响应
                    OperationResponse opResponse = new OperationResponse(1);
                    Dictionary<byte, object> data2 = new Dictionary<byte, object>();//发送数据
                    data2.Add(1, 100);
                    data2.Add(2, "testString");
                    opResponse.SetParameters(data2);
                    SendOperationResponse(opResponse, sendParameters); //给客户端一个响应
                    //事件
                    EventData ed = new EventData(1);
                    ed.Parameters = data2;
                    SendEvent(ed, new SendParameters());
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}
