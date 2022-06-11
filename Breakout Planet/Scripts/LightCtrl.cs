using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCtrl : MonoBehaviour
{
    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.ball = GameObject.Find("BallPrefab(Clone)");
        Vector3 BallPos = this.ball.transform.position;
        transform.position = new Vector3(BallPos.x, transform.position.y, BallPos.z);
    }
}
