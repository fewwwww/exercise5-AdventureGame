using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotStartAfterCollectingKey : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent _navMeshAgent;
    GameObject player;
    GameObject key;
    public GameObject explosion;

    void Start()
    {
        // Get the NavMeshAgent component
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // Get the player
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        // Get the key
        key = GameObject.FindGameObjectsWithTag("Key")[0];
    }

    void Update() {
        if (key == null) {
            // Set the destination to the player's position
            if (player != null) {
                _navMeshAgent.destination = player.transform.position;
            } else {
                Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
