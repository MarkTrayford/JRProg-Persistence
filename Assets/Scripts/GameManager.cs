using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
[System.Serializable]
    private class ScoreSave {
        public string playerName; 
        public int highScore;
    }

    public string playerName;
    public int highScore;
    public string currentPlayerName;
    
    private void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void SetNewHighScore(int newScore){
        highScore = newScore;
        playerName = currentPlayerName;
        SaveHighScore();
    }

    public void SaveHighScore(){
        ScoreSave scoreSave = new ScoreSave();
        scoreSave.playerName = currentPlayerName;
        scoreSave.highScore = highScore;
        string saveString = JsonUtility.ToJson(scoreSave);
        File.WriteAllText(Application.persistentDataPath + "/highScores.json", saveString);

    }
    public void LoadHighScore(){
        string path = Application.persistentDataPath + "/highScores.json";
        if (File.Exists(path)){
            ScoreSave scoreRead  = JsonUtility.FromJson<ScoreSave>(File.ReadAllText(path));
            playerName = scoreRead.playerName;
            highScore = scoreRead.highScore;

        } else 
        { playerName = "Bob";
         highScore = 1; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
