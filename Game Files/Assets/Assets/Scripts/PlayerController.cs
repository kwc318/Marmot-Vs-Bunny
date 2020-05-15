using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject marmot;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Marmot movement controls
        if (Input.GetKey(KeyCode.A))
        {
            marmot.transform.position += new Vector3(-speed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            marmot.transform.position += new Vector3(speed, 0);
        }
    }
}
