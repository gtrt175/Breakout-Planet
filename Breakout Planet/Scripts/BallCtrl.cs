using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    public Vector3 force = new Vector3(1.0f, 1.0f, 1.0f);
    private Rigidbody rb;
    AudioSource aud;
    public AudioClip pointSE;
    public AudioClip impSE;
    public AudioClip nomal;
    GameObject director;
    


    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.rb.AddForce(force, ForceMode.VelocityChange);
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude < 5)
        {
            Vector3 vec = rb.velocity.normalized;
            this.rb.AddForce(vec * 10f,ForceMode.Force);
        }
        if(rb.velocity.magnitude > 5.2)
        {
            Vector3 vec = rb.velocity.normalized;
            this.rb.AddForce(vec * -10f, ForceMode.Force);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.CompareTag("Player"))
        {
            aud.PlayOneShot(impSE);
            this.rb.AddForce(Vector3.up * 1.2f,ForceMode.VelocityChange);
        }

        if (collision.gameObject.CompareTag("point"))
        {
            aud.PlayOneShot(pointSE);
            this.director.GetComponent<GameDirector>().Getpoint();
        }

        if (collision.gameObject.CompareTag("doom"))
        {
            aud.PlayOneShot(nomal);
            
        }


    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("plane"))
        {

            this.director.GetComponent<GameDirector>().Minus();
            StartCoroutine("Wait");

        }
    }


}
