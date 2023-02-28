using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    GameObject player;
    public GameObject explosion;

    void Start()
    {
        // Get the NavMeshAgent component
        _navMeshAgent = GetComponent<NavMeshAgent>();
        // Get the player
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        // Start chasing the player
        StartCoroutine(ChasePlayer());
    }

    // Chase the player
    IEnumerator ChasePlayer()
    {
        while (true)
        {
            // Wait a second
            yield return new WaitForSeconds(1f);
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
