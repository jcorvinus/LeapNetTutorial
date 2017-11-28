using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

using Leap.Unity;

public class NetHandVisibility : NetworkBehaviour
{
    [SerializeField]
    GameObject leftHand;
    [SerializeField]
    GameObject rightHand;

    public void SetVisible(bool left)
    {
        CmdSetVisible(left, true);
    }

    public void SetInvisible(bool left)
    {
        CmdSetVisible(left, false);
    }

    [Command]
    void CmdSetVisible(bool left, bool visible)
    {
        if (!isServer) return;

        RpcSetVisible(left, visible);
        DoActalVisibility(left, visible); // doing this so that our server updates?
    }

    [ClientRpc]
    void RpcSetVisible(bool left, bool visible)
    {
        DoActalVisibility(left, visible);
    }

    private void DoActalVisibility(bool left, bool Visible)
    {
        GameObject handObject = (left) ? leftHand : rightHand;
        handObject.SetActive(Visible);

        Debug.Log(((left) ? "left" : "right") + ((Visible) ? "visible" : "invisible"));
    }
}
