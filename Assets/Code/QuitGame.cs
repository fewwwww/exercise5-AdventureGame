using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuitGame : MonoBehaviour
{
    public TextMeshProUGUI QuitUI;
    // Start is called before the first frame update
    void Start()
    {
    #if UNITY_WEBGL
       gameObject.SetActive(false);
       QuitUI.text = "";
    #endif
    }

    private void OnTriggerEnter(Collider other)
    {
    #if !UNITY_WEBGL
        Application.Quit();
    #endif
    }
}
