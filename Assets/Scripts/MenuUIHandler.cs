using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField enteredName;
    public TextMeshProUGUI bestScoreText;

    public void Start()
    {
        UpdateHighScore();
    }
    public void StartNew()
    {
        MenuManager.Instance.inputName = enteredName.text;
        SceneManager.LoadScene(1);
       
    }
    public void Exit()
    {
       
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
    public void UpdateHighScore()
    {
        bestScoreText.text = "Best Score: " + MenuManager.Instance.topName + ": " + MenuManager.Instance.highScore;
    }
}
