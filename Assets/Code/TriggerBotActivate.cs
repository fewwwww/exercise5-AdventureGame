using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBotActivate : MonoBehaviour
{
    public string botNames;
    private string[] activateList;

    void Start()
    {
        activateList = botNames.Split(",");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            print("activate bots");
            foreach (string botName in activateList) {
                GameObject bot = GameObject.Find(botName);
                if (bot != null) {
                    bot.GetComponent<BotActivate>().ActivateBot();
                }
            }
        }
    }
}
