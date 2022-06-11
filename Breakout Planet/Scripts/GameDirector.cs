using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public GameObject timerText;
    public GameObject pointText;
    float time = 70.0f;
    int point = 0;
    public static int Repoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1") + "s";
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " Point";
        Repoint = this.point;

        if(this.time < 0)
        {
            SceneManager.LoadScene("Clear");           
        }

    }

    public void Getpoint()
    {
        this.point += 10;
    }

    public void Minus()
    {
        this.point -= 50;
        if(this.point <= 0)
        {
            this.point = 0;
        }
        
    }

    public static int getPoint()
    {
        return Repoint;
    }


}
