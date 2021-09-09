using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        //���� ȭ���� �ػ󵵸� 960 * 640�� â���� ����
        Screen.SetResolution(960, 640, FullScreenMode.Windowed);
        //������ �ۼ��� �󵵸� �� �ʴ� 30ȸ�� ����
        PhotonNetwork.SendRate = 30;
        PhotonNetwork.SerializationRate = 30;
    }

    void Update()
    {
        
    }
}
