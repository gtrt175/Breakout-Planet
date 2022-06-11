using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCtrl : MonoBehaviour
{
    AudioSource aud;
    public GameObject generator;
    public AudioClip OverSE;

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            aud.PlayOneShot(OverSE);
            this.generator.GetComponent<BallGenerator>().Gene();
        }

    }


}
