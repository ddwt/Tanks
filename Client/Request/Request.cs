using Common;
using UnityEngine;
using ExitGames.Client.Photon;


public abstract class Request : MonoBehaviour {
    public Common.OperationCode operationCode;
    public abstract void DefaultRequest();
    public abstract void OnOperationResponse(OperationResponse opResponse);

    public virtual void Start() {
        PhotoEngine._instance.AddRequest(this);
    }

    public virtual void OnDestroy() {
        PhotoEngine._instance.RemoveRequest(this);
    }
}
