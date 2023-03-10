using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class orangeTeleporter : MonoBehaviour
{
    public GameObject teleportLocation;
    public GameObject wall;
    public GameObject wall2;
    public GameObject wall3;
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
        wall2.GetComponent<NavMeshObstacle>().carving = false;
        wall2.GetComponent<NavMeshObstacle>().carveOnlyStationary = false;
        wall3.GetComponent<NavMeshObstacle>().carving = false;
        wall3.GetComponent<NavMeshObstacle>().carveOnlyStationary = false;
        yield return new WaitForSeconds(0.2f);
        player.transform.position = teleportLocation.transform.position;
        yield return new WaitForSeconds(0.2f);
        wall.GetComponent<NavMeshObstacle>().carving = true;
        wall.GetComponent<NavMeshObstacle>().carveOnlyStationary = true;
        wall2.GetComponent<NavMeshObstacle>().carving = true;
        wall2.GetComponent<NavMeshObstacle>().carveOnlyStationary = true;
        wall3.GetComponent<NavMeshObstacle>().carving = true;
        wall3.GetComponent<NavMeshObstacle>().carveOnlyStationary = true;
    }
}
