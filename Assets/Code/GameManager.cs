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
    public TextMeshProUGUI reduceHealthUI;
    AudioSource _audioSource;
    public AudioClip sheepSound;

    private void Awake()
    {
        reduceHealthUI.gameObject.SetActive(false);  
    }

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene(); // get the current scene
        gameOverScene = scene.name;
        lives = totalLives;
        reduceHealthUI.gameObject.SetActive(false);  
        _audioSource = GetComponent<AudioSource>();
        /*if(GameObject.FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }*/
    }

    public void loseLife(int numLives){
        lives -= numLives;
        
        if (lives<=0){
            StartCoroutine(PlayerDeath());
        }
        reduceHealthUI.text = "-" + numLives;
        ReduceHealthText();
    }

    IEnumerator PlayerDeath() {
        _audioSource.PlayOneShot(sheepSound);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(explosion, player.transform.position, Quaternion.identity);
        Destroy(player);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(gameOverScene);
        lives = totalLives;
    }

    public void ReduceHealthText(){
        reduceHealthUI.gameObject.SetActive(true);
        Invoke("SetInactive", .5f);
    }

    public void SetInactive(){
        reduceHealthUI.gameObject.SetActive(false);
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
