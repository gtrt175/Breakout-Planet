using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBlockCtrl : MonoBehaviour
{
    private Vector3 q;
    public float angle_x = 0;
    public float angle_y = 0;
    public float angle_z = 0;

    // Start is called before the first frame update
    void Start()
    {
        //自分のトランスフォームを取得
        Transform myTra = this.transform;
        //自分の座標をmyPosに取得
        Vector3 myPos = myTra.position;
        this.q = Quaternion.Euler(this.angle_x,this.angle_y,this.angle_z) * myPos;
        transform.position = q;
        transform.rotation = Quaternion.Euler(this.angle_x, this.angle_y, this.angle_z);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine("Wait");
        }

        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }


}
