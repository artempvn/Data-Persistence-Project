#if UNITY_EDITOR
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField userNameInput;
    public TextMeshProUGUI bestScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (DataManager.INSTANCE != null)
        {
            DataManager.INSTANCE.Load();
            int highScore = DataManager.INSTANCE.highScore;
            string highScoreUserName = DataManager.INSTANCE.highScoreUserName;

            bestScoreText.SetText("Best Score : " + highScoreUserName + " : " + highScore);
            userNameInput.text = DataManager.INSTANCE.userName;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        DataManager.INSTANCE.userName = userNameInput.text;

        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
