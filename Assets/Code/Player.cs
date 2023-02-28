using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Player : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;
    GameManager _gameManager;
    private MeshRenderer _renderer;

    void Start()
    {
        // Get the NavMeshAgent component
        _navMeshAgent = GetComponent<NavMeshAgent>();
        // Get the main camera
        mainCam = Camera.main;
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // Move to mouse click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200))
            {
                _navMeshAgent.destination = hit.point;
            }
        }
    }

    IEnumerator FlashRed() {
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(.1f);
        _renderer.material.color = Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            // Key name is "KeyX" where X is the key number
            int keyNum = Int32.Parse(other.gameObject.name.Substring(3));
            print("Key " + keyNum + " picked up");
            Destroy(other.gameObject);
            PublicVars.hasKey[keyNum] = true;
        } else if (other.CompareTag("Enemy") || other.CompareTag("Poison")){
            _gameManager.loseLife(1);
            StartCoroutine(FlashRed());
        }
    }
}
