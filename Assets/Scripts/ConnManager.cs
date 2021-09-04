using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnManager : MonoBehaviourPunCallbacks
{
    
    void Start()
    {

    }
    public void OnStart()
    {
        
        Debug.Log("Start");
        PhotonNetwork.GameVersion = "0.1";

        //���ӿ��� ����� ������� �̸��� ��������
        int num = Random.Range(0,1000);
        PhotonNetwork.NickName = "Player " + num;

        //���ӿ� �����ϸ� ������ Ŭ���̾�Ʈ�� ������ ���� �ڵ����� ����ȭ�ϵ��� �Ѵ�.
        PhotonNetwork.AutomaticallySyncScene = true;

        //���� ����
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnected()
    {
        Debug.Log("OnConnected");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("OnDisconnected" + cause);
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
    }
    public void JoinLobby()
    {
        if(PhotonNetwork.IsConnected == false)
        {
            Debug.Log("�������� �ȵǾ����� JoinLobby Fail");

            return;
        }
        
        Debug.Log("JoinLobby");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ���� �Ϸ�!");
        RoomOptions ro = new RoomOptions() {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 8
        };
        PhotonNetwork.JoinOrCreateRoom("NetTest", ro, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("�� ����!");

        //�ݰ� 2m �̳��� Player�������� �����Ѵ�.
        Vector2 originPos = Random.insideUnitCircle * 2.0f;
        PhotonNetwork.Instantiate("Player", new Vector3(originPos.x, 0, originPos.y), Quaternion.identity);
    }

}
