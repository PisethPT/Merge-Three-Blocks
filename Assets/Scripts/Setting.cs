using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;

    enum Settings
    {
        SETTING,
        RESUME,
        NEW_GAME

    };
    private void EnableObjective(bool isBool, int gravity)
    {
        for (int i = 0; i < FindAnyObjectByType<InstantiateDices>().rules.childCount; i++)
        {
            for (int j = 0; j < FindAnyObjectByType<InstantiateDices>().rules.GetChild(i).childCount; j++)
            {
                FindAnyObjectByType<InstantiateDices>().rules.GetChild(i).GetChild(j).GetComponent<BoxCollider2D>().enabled = isBool;
                FindAnyObjectByType<InstantiateDices>().rules.GetChild(i).GetChild(j).GetComponent<Rigidbody2D>().gravityScale = gravity;
            }
        }
    }

    [System.Obsolete]
    private void Selection(Settings setting)
    {
        FindAnyObjectByType<ScoresandLevels>().saveLevel();
        PlayerPrefs.SetInt("hight", FindObjectOfType<ScoresandLevels>().highScores);
        FindAnyObjectByType<ScoresandLevels>().getLevels();
        settingPanel.SetActive(false);
        if (setting.Equals(Settings.SETTING))
        {
            settingPanel.SetActive(true);
            Time.timeScale = 0f;
            EnableObjective(false, 0);
        }
        else if (setting.Equals(Settings.RESUME))
        {
            EnableObjective(true, 1);
            Time.timeScale = 1f;
        }
        else if (setting.Equals(Settings.NEW_GAME))
        {
            Time.timeScale = 1f;
            EnableObjective(true, 1);
            InstantiateDices.UpdateGame();
            InstantiateDices.count = -1;
            TransformPositions.Clear();
            FindAnyObjectByType<ScoresandLevels>().saveLevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    [System.Obsolete]
    public void ButtonSetting()
    {
        Selection(Settings.SETTING);
    }
    [System.Obsolete]
    public void ButtonResume()
    {
        Selection(Settings.RESUME);
    }
    [System.Obsolete]
    public void ButtonNewGame()
    {
        Selection(Settings.NEW_GAME);
    }
    [System.Obsolete]
    public void Exit(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
    }
}
