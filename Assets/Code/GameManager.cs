using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject explosion;
    public string gameOverScene = "Start";
    public int totalLives = 3;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        lives = totalLives;
        if(GameObject.FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }

    public void loseLife(int numLives){
        lives -= numLives;
        if (lives<=0){
            StartCoroutine(PlayerDeath());
        }

    }

    IEnumerator PlayerDeath() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(explosion, player.transform.position, Quaternion.identity);
        Destroy(player);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(gameOverScene);
        lives = totalLives;
    }

    public int GetLives() {
        return lives;
    }

    // Update is called once per frame
    void Update()
    {
        // quit game is esc
#if !UNITY_WEBGL
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }
}
