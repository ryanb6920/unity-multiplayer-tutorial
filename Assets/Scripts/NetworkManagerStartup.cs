using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor;
using UnityEngine;

public class NetworkManagerStartup : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_SERVER

        Debug.Log("Server Mode");
        NetworkManager.Singleton.StartServer();

#else

        Debug.Log("Client Mode");    

#endif

    }


}
