using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common;
using Common.Tools;
using UnityEngine.UI;

public class PlayerInfoRequest : Request {

    [HideInInspector]
    public string Username;
    [HideInInspector]
    public int Level;

    public Text level_text;

    void Awake() {
       
    }

    public override void Start() {
        base.Start();
        Username = PlayersInfo._instance.username;
    }

    public override void DefaultRequest() {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)Common.ParameterCode.Username, Username);
        bool ans = PhotoEngine.Peer.OpCustom((byte)operationCode, data, true);
        Debug.Log("send" + ans);
    }

    public override void OnOperationResponse(OperationResponse opResponse) {
        Debug.Log("响应服务器" + opResponse.ReturnCode);

        Dictionary<byte, object> data = opResponse.Parameters;
        //if (data == null) Debug.Log("啥也没收到");
        //Debug.Log(data.Count);
        //object username;
        //bool ans = data.TryGetValue((byte)Common.ParameterCode.Username, out username);
        //level_text.text = username.ToString();
        //Debug.Log("收到" + username.ToString());
        int level = (int)DictTool.GetValue<byte, object>(opResponse.Parameters, (byte)Common.ParameterCode.Level);
        level_text.text = level.ToString();
        //Debug.Log(DictTool.GetValue<byte, object>(opResponse.Parameters, (byte)Common.ParameterCode.Username));
    }

}
