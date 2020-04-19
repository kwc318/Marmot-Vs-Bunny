using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroVideo : MonoBehaviour
{
    public GameObject videoplayer;
    public float stoptime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stoptime -= Time.deltaTime;
		if (stoptime <= 0)
		{
			SceneManager.LoadScene("SampleScene");
		}
    }
}
