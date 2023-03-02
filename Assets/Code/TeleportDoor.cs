using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    public bool locked = true;
    // Key number
    public int keyNum = 0;
    GameObject player;
    public Transform teleportDest;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        print(CanOpen());
        if (other.gameObject.CompareTag("Player") && CanOpen())
        {
            print("teleport");
            locked = false;
            TeleportPlayer();
            PublicVars.hasKey[keyNum] = false;
            
        }
    }

    public bool CanOpen() {
        return !locked || PublicVars.hasKey[keyNum];
    }

    void TeleportPlayer() {
        player.transform.position = teleportDest.transform.position;
    }
}
