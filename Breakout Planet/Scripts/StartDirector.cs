using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
    public GameObject loadPanel;
    public Slider loadSlider;
    public Text loadProgressText;
    public Button StartButton;
    public Button CreditButton;
    public GameObject CreditPanel;
    AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        loadSlider.GetComponent<Slider>();
        loadProgressText.GetComponent<Text>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
          
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

    public void OnClick()
    {
        StartCoroutine(LoadScene("Game"));
        StartButton.gameObject.SetActive(false);
        CreditButton.gameObject.SetActive(false);
    }

    public void CreClick()
    {
        CreditPanel.SetActive(true);
    }

    public void ExitClick()
    {
        CreditPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
