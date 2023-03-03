using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHinge : MonoBehaviour
{
    // Start is called before the first frame update
    public bool open = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open && transform.localRotation.y <= 0.96)
        {
            transform.Rotate(0, transform.rotation.y + 0.1f, 0);
        }
        //Debug.Log(transform.rotation.y);
    }
}
