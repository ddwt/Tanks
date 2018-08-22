using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common;
using Common.Tools;

public class LoginRequest : Request {
    [HideInInspector]
    public string Account;
    [HideInInspector]
    public string Pwd;

    private LoginPanel loginPanel;

    public override void Start() {
        base.Start();
        loginPanel = GetComponent<LoginPanel>();
    }

    public override void DefaultRequest() {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)Common.ParameterCode.Account, Account);
        data.Add((byte)Common.ParameterCode.Pwd, Pwd);
        bool ans = PhotoEngine.Peer.OpCustom((byte)operationCode, data, true);
        Debug.Log("send " + ans);
    }

    public bool CheckId() {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)Common.ParameterCode.Account, Account);
        data.Add((byte)Common.ParameterCode.Pwd, Pwd);
        bool ans = PhotoEngine.Peer.OpCustom((byte)operationCode, data, true);
        return ans;
    }

    public override void OnOperationResponse(OperationResponse opResponse) {
        ReturnCode returnCode = (ReturnCode)opResponse.ReturnCode;
        Dictionary<byte, object> data = opResponse.Parameters;
        string username = (string)DictTool.GetValue<byte, object>(opResponse.Parameters, (byte)Common.ParameterCode.Username);
        if (returnCode == ReturnCode.Success) {
            PhotoEngine.username = username;
            PlayersInfo._instance.username = username;
            Debug.Log("验证成功");
        }
        //loginPanel.OnLoginResponse(returnCode);
    }
}
