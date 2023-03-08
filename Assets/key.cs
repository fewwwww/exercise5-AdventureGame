using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public doorHinge currDoor;
    public GameObject wall;
    public GameObject wall2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 60*Time.deltaTime, 30 * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            currDoor.open = true;
            Destroy(wall2);
            Destroy(wall);
            Destroy(gameObject);
        }
    }
}
