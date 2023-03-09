using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBots : MonoBehaviour
{
    public string botNames;
    private string[] killList;
    public GameObject explosion;
    AudioSource _audioSource;
    public AudioClip explodeSound;

    void Start()
    {
        killList = botNames.Split(",");
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            print("kill bots");
            _audioSource.PlayOneShot(explodeSound);
            foreach (string botName in killList) {
                GameObject bot = GameObject.Find(botName);
                if (bot != null) {
                    Instantiate(explosion, bot.transform.position, Quaternion.identity);
                    Destroy(bot);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
