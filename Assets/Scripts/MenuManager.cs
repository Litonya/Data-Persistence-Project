using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nameTextField;

    private void Start()
    {
        if (DataManager.Instance.playerName != null)
        {
            nameTextField.text = DataManager.Instance.playerName;
        }
    }

    public void ChangeScene(int SceneIndex)
    {
        DataManager.Instance.keepName(nameTextField.text);
        SceneManager.LoadScene(SceneIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
