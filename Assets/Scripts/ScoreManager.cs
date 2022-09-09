using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private List<TMPro.TextMeshProUGUI> scoreText;

    private void Start()
    {
        for (int i = 0; i < scoreText.Count; i++)
        {
            print(i);
            scoreText[i].text = i+". " + DataManager.Instance.bestPlayerNames[i] +"   " + DataManager.Instance.bestPlayerScores[i].ToString();
        }
    }

    public void backMenu()
    {
        SceneManager.LoadScene(0);
    }
}
