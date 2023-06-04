using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;
using Unity.Collections;

public class PlayerNetwork : NetworkBehaviour
{

    [SerializeField] private Canvas playerNameCanvas;
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private float moveSpeed = 3f;

    private NetworkVariable<FixedString32Bytes> playerNetworkName = new NetworkVariable<FixedString32Bytes>("");


    public override void OnNetworkSpawn()
    {
        Debug.Log("Connected Name: " + playerNameText.text);
        playerNameCanvas.worldCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        playerNameCanvas.transform.LookAt(playerNameCanvas.transform.position + playerNameCanvas.worldCamera.transform.rotation * Vector3.forward, playerNameCanvas.worldCamera.transform.rotation * Vector3.up);

        playerNetworkName.OnValueChanged += (FixedString32Bytes previousValue, FixedString32Bytes newValue) => {
            playerNameText.text = newValue.ToString();
        };

      
        UpdatePlayerNameServerRpc(OwnerClientId, GameObject.Find("NetworkManagerUI").GetComponent<NetworkManagerUI>().playerName);
    }

    [ServerRpc]
    private void UpdatePlayerNameServerRpc(ulong OwnerClientId, string playerName)
    {
        Debug.Log($"Client: {OwnerClientId} connected - setting username to {playerName}");
        playerNetworkName.Value = playerName;
    }

    [ServerRpc]
    private void UpdatePlayerPositionServerRpc(Vector3 moveDir)
    {
        transform.position += moveSpeed * Time.deltaTime * moveDir;
    }

    private void Update()
    {
        if (!IsOwner) return;


        if (Input.GetKeyDown(KeyCode.T))
        {
            TestServerRpc();
        }

        Vector3 moveDir = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.W)) moveDir.z = +1f;
        if (Input.GetKey(KeyCode.S)) moveDir.z = -1f;
        if (Input.GetKey(KeyCode.A)) moveDir.x = -1f;
        if (Input.GetKey(KeyCode.D)) moveDir.x = +1f;

        if (moveDir != Vector3.zero)
        {
            Debug.Log(transform.position + (moveSpeed * Time.deltaTime * moveDir));
            transform.position += Time.deltaTime * moveDir * moveSpeed;
        }
                        
    }

    [ServerRpc]
    private void TestServerRpc()
    {
        Debug.Log("Test Server RPC: " + OwnerClientId);
    }
}


