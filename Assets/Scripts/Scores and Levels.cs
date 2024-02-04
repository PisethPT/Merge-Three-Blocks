using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static InstantiateDices;
using static TransformPositions;

public class ScoresandLevels : MonoBehaviour
{ 
    public static ScoresandLevels instance;
    public  int scores = 0;
    public int levels = 1;
    public static int targets = 100;
    public  int highScores = 0;
    private string key_score = "score";
    private string key_level = "level";
    private string key_hight_score = "hight";

    [System.Obsolete]
    private void Awake()
    {
      count = count1 = count2 = count3 = count4 = 0;
      Clear();
      UpdateGame();
      scores = PlayerPrefs.GetInt("score");
      highScores = PlayerPrefs.GetInt("hight");
      getLevel();
      FindAnyObjectByType<TransformPositions>().score.text = "SCORE: " + FindAnyObjectByType<ScoresandLevels>().scores.ToString();
      FindAnyObjectByType<TransformPositions>().highScore.text = "HIGH SCORE: " + FindAnyObjectByType<ScoresandLevels>().highScores.ToString();
      FindAnyObjectByType<TransformPositions>().level.text = "LEVEL: " + FindAnyObjectByType<ScoresandLevels>().levels.ToString();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void saveLevel()
    {
        PlayerPrefs.SetInt(key_score, scores);
        PlayerPrefs.SetInt(key_hight_score, highScores);
        // Debug.Log("score: "+scores);
        //  Debug.Log("high score: "+highScores);
    }

    [System.Obsolete]
    public void getLevels()
    {
        if (scores >= targets)
        {
            levels++;
            targets = levels * 100;
            highScores = scores;
            saveLevel();
            // Clear();
            // UpdateGame();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    public void getLevel()
    {
        //if(scores>=targets){
        levels = scores / 100;
        targets = levels * 100 + 100;
        //}
    }
}
