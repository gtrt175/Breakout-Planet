using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject BallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Gene();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Gene()
    {

            GameObject Ball = Instantiate(BallPrefab) as GameObject;
            Ball.transform.position = new Vector3(0, 4.23f, 0);
        
    }


}
