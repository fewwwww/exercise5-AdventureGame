using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class teleporter : MonoBehaviour
{
    public GameObject teleportLocation;
    public GameObject wall;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("collided");
        if (col.gameObject.CompareTag("Player"))
        {
            player = col.gameObject;
            StartCoroutine(waitABit());
        }
    }
    IEnumerator waitABit()
    {
        wall.GetComponent<NavMeshObstacle>().carving = false;
        wall.GetComponent<NavMeshObstacle>().carveOnlyStationary = false;
        yield return new WaitForSeconds(0.2f);
        player.transform.position = teleportLocation.transform.position;
        yield return new WaitForSeconds(0.2f);
        wall.GetComponent<NavMeshObstacle>().carving = true;
        wall.GetComponent<NavMeshObstacle>().carveOnlyStationary = true;
    }
}
