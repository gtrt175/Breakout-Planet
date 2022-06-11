using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 1.02f;   // 回転速度
    [SerializeField] public Transform player;          // 注視対象プレイヤー
    [SerializeField] private float distance = 15.0f;    // 注視対象プレイヤーからカメラを離す距離
    [SerializeField] private Quaternion vRotation;      // カメラの垂直回転(見下ろし回転)
    [SerializeField] public Quaternion hRotation;      // カメラの水平回転
    
    
    public float viewAngle = 60.0f;
    public float inputX;
    public float inputY;


    void Start()
    {
        // 回転の初期化
        vRotation = Quaternion.Euler(20, 0, 0);         // 垂直回転(X軸を軸とする回転)は、30度見下ろす回転
        hRotation = Quaternion.Euler(0, 0, 0);                // 水平回転(Y軸を軸とする回転)は、無回転
        transform.rotation = hRotation * vRotation;     // 最終的なカメラの回転は、垂直回転してから水平回転する合成回転

        // 位置の初期化
        // player位置から距離distanceだけ手前に引いた位置を設定します
        transform.position = player.position - transform.rotation * Vector3.forward * distance;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void LateUpdate()
    {

        inputX = Input.GetAxis("Mouse X");
        inputY = Input.GetAxis("Mouse Y");

        hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * turnSpeed, 0);

        Rotate(inputX, inputY, viewAngle);

        // カメラの回転(transform.rotation)の更新
        // 方法1 : 垂直回転してから水平回転する合成回転とします
        //transform.rotation = hRotation * (vRotation);

        // カメラの位置(transform.position)の更新
        // player位置から距離distanceだけ手前に引いた位置を設定します(位置補正版)
        transform.position = player.position + new Vector3(0, 1, 0) - transform.rotation * Vector3.forward * distance;
    }



    void Rotate(float inputX,float inputY,float limit)
    {
        //X軸回転
        float maxlimit = limit;
        float minlimit = 360 - maxlimit;
        var localAngle = transform.localEulerAngles;

        localAngle.x -= inputY * turnSpeed;
        if (localAngle.x > maxlimit && localAngle.x < 180)
            localAngle.x = maxlimit;
        if (localAngle.x < minlimit && localAngle.x > 180)
            localAngle.x = minlimit;
        transform.localEulerAngles = localAngle;

        //Y軸回転
        var angle = transform.eulerAngles;
        angle.y += inputX * turnSpeed;
        transform.eulerAngles = angle;



    }

    



}
