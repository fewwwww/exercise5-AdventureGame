using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotActivate : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    GameObject player;
    GameObject key;
    public GameObject explosion;
    public int waitSecs = 1;

    void Start()
    {
        // Get the NavMeshAgent component
        _navMeshAgent = GetComponent<NavMeshAgent>();
        // Get the player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ActivateBot() {
        StartCoroutine(ChasePlayer());
    }

    IEnumerator ChasePlayer() {
        while (true) {
            // Set the destination to the player's position
            yield return new WaitForSeconds(waitSecs);
            if (player != null) {
                _navMeshAgent.destination = player.transform.position;
            } else {
                Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
