using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;

public class NetworkManagerUI : MonoBehaviour
{

    [SerializeField] private Button connectBtn;
    [SerializeField] private Button disconnectBtn;
    [SerializeField] private TMP_InputField nameInput;

    [SerializeField] private GameObject connectParent;
    [SerializeField] private GameObject disconnectParent;

    public string playerName = string.Empty;

    bool isConnected = false;

    // Start is called before the first frame update
    private void Awake() {
        connectBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
            isConnected = true;
            playerName = nameInput.text;
        });

        disconnectBtn.onClick.AddListener(() => {
            if (NetworkManager.Singleton.IsConnectedClient)
            {
                isConnected = false;
                NetworkManager.Singleton.Shutdown();
                
            }            
        });
    }

    private void Update()
    {

        if (isConnected)
        {
            disconnectParent.SetActive(true);
            connectParent.SetActive(false);
        } else
        {
            disconnectParent.SetActive(false);
            connectParent.SetActive(true);
        }

    }
}
