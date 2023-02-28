using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool locked = true;
    // Key number
    public int keyNum = 0;
    public string levelToLoad;
    AudioSource _audioSource;
    public AudioClip lockedSound;
    public AudioClip unlockedSound;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(PublicVars.hasKey[keyNum]);
        // If the door is unlocked, load the level
        if (!locked)
        {
            SceneManager.LoadScene(levelToLoad);
            _audioSource.PlayOneShot(unlockedSound);
        }
        // If the door is locked, check if the player has the correct key
        else if (other.gameObject.CompareTag("Player"))
        {
            if (PublicVars.hasKey[keyNum])
            {
                PublicVars.hasKey[keyNum] = false;
                _audioSource.PlayOneShot(unlockedSound);
                SceneManager.LoadScene(levelToLoad);
            }
            else
            {
                _audioSource.PlayOneShot(lockedSound);
            }
        }
    }
}
