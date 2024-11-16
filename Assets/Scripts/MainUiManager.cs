using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUiManager : MonoBehaviour
{
    public GameObject highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (DataManager.INSTANCE != null)
        {
            int highScore = DataManager.INSTANCE.highScore;
            string highScoreUserName = DataManager.INSTANCE.highScoreUserName;

            highScoreText.GetComponent<Text>().text = "Best Score : " + highScoreUserName  + " : " + highScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
