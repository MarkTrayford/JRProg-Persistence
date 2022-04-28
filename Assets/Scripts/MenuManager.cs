using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    [SerializeField] 
    TextMeshProUGUI highScoreText;
    [SerializeField] 
    TMP_InputField nameText;
    // Start is called before the first frame update
    
    private void Start() {
        highScoreText.text = "High Score: " + GameManager.Instance.playerName + " " + GameManager.Instance.highScore;    
    }


    public void StartGame() {
        if (GameManager.Instance.currentPlayerName == null)
        {
            GameManager.Instance.currentPlayerName = "Player1";
        }
        GameManager.Instance.currentPlayerName = nameText.text;
        SceneManager.LoadScene(1);
    }
    public void ExitGame() {
       #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit(); 
    #endif
    }

   
}
