using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField currentUserNameField;
    public static string currentUserName;
    public TextMeshProUGUI userScore;
    DataManager dataManagerInstance;

    private void Start()
    {
        dataManagerInstance = DataManager.Instance;
        DataManager.Instance.LoadUserNames();
        currentUserNameField.text = dataManagerInstance.userName;
        userScore.GetComponent<TextMeshProUGUI>().text = "Best Score : " + dataManagerInstance.userName.ToString() + ":" + dataManagerInstance.userScore.ToString();

    }

    public void StartGame()
    {
        VerifyUserName();
        SceneManager.LoadScene(1);
    }
    private void VerifyUserName()
    {
        if (string.IsNullOrEmpty(currentUserNameField.text))
        {
            currentUserName = "Player";
        }
        else
        {
            currentUserName = currentUserNameField.text;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }

}