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
    AudioSource _audioSource;
    private SkinnedMeshRenderer _renderer;
    // get audio source
    public AudioClip collectKeySound;
    public AudioClip hitSound;
    public CanvasLives canvasLives;
    public GameObject body;
    public Material sheepMaterial;
    public Material redMaterial;

    void Start()
    {
        // Get the NavMeshAgent component
        _navMeshAgent = GetComponent<NavMeshAgent>();
        // Get the main camera
        mainCam = Camera.main;
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _renderer = body.GetComponent<SkinnedMeshRenderer>();
        _renderer.material = sheepMaterial;
        // Get audio source component
        _audioSource = GetComponent<AudioSource>();
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
        _renderer.material = redMaterial;
        yield return new WaitForSeconds(.1f);
        _renderer.material = sheepMaterial;
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
            // play sound
            _audioSource.PlayOneShot(collectKeySound);
        } else if (other.CompareTag("Enemy")){
            // play sound
            _audioSource.PlayOneShot(hitSound);
            StartCoroutine(FlashRed());
            _gameManager.loseLife(1);
            canvasLives.SetLivesText();
        } else if (other.CompareTag("KillWall")){
            // play sound
            _audioSource.PlayOneShot(hitSound);
            _gameManager.loseLife(3);
            
        }
    }
}
