using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClearDirector : MonoBehaviour
{
    public GameObject resultText;
    public int resultpoint;
    public GameObject loadPanel;
    public Slider loadSlider;
    public Text loadProgressText;
    AsyncOperation async;
    public Button StartButton;


    // Start is called before the first frame update
    void Start()
    {
        this.resultpoint = GameDirector.getPoint();
        this.resultText.GetComponent<Text>().text = this.resultpoint.ToString() + " Point";
        loadSlider.GetComponent<Slider>();
        loadProgressText.GetComponent<Text>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // Type == Number の場合
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(this.resultpoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }

        if (Input.GetKey(KeyCode.X))
        {
            Application.Quit();
        }

    }


    public IEnumerator LoadScene(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        //loadPanelを実行
        loadPanel.SetActive(true);

        while (!async.isDone)
        {
            loadProgressText.text = "進行中..." + (async.progress * 100) + "%";

            float progressValue = async.progress;
            loadSlider.value = progressValue;
            yield return null;
        }
        if (async.isDone)
        {
            loadPanel.SetActive(false);
        }


    }

    public void ToStart()
    {
        StartButton.gameObject.SetActive(false);
        StartCoroutine(LoadScene("Start"));
    }



}
