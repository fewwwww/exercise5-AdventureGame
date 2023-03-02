using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasLives : MonoBehaviour
{
    public TextMeshProUGUI livesUI;
    GameManager _gameManager;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    
    public void SetLivesText() {
        lives = _gameManager.lives;
        livesUI.text = "Lives: " + lives; 
    }
}
