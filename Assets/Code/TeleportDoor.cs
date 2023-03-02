using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeleportDoor : MonoBehaviour
{
    public bool locked = true;
    // Key number
    public int keyNum = 0;
    GameObject player;
    public Transform teleportDest;
    NavMeshObstacle _navMeshObstacle;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
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
        _navMeshObstacle.carving = true;
        _navMeshObstacle.carveOnlyStationary = true;

    }
}
