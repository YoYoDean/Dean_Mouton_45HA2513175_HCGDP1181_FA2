using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScoreMain;
    public TextMeshProUGUI npcSaveMain;
    public TextMeshProUGUI highScoreGameOver;
    public TextMeshProUGUI npcSaveGameOver;
    public TextMeshProUGUI hydration;
    public float iScore;
    public static UiManager instance;
    public GameObject promptText;
    public TextMeshProUGUI npcCarry;
    public TextMeshProUGUI objective;



    void Awake()
{
    if (instance != null && instance != this)
    {
        Destroy(gameObject);
        return;
    }
    StartCoroutine(TextCountDown());

    instance = this;
}
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "FA2")
        {
            iScore += Time.deltaTime;
            score.text = "Time: " + Math.Round(iScore , 2);
        }
    }
    public void UpdateHealth(float healthIn)
    {
        health.text = "Health: " + Math.Round(healthIn) + "/100";
    }
    public void UpdateNpcUi(float value)
    {
        npcCarry.text = "People Saved: " + value;
    }
    public void UpdateScore()
        {
            if (highScoreGameOver != null && npcSaveGameOver != null) 
            {
                highScoreGameOver.text = "HighScore: " + Math.Round(PlayerPrefs.GetFloat("highScore")) + "  Seconds";
                npcSaveGameOver.text = "People Saved: " + Math.Round(PlayerPrefs.GetFloat("NpcSave"));
            }
            
            if (highScoreMain != null && npcSaveMain != null) 
            {
                highScoreMain.text = "HighScore: " + Math.Round(PlayerPrefs.GetFloat("highScore")) + "  Seconds";
                npcSaveMain.text = "People Saved: " + Math.Round(PlayerPrefs.GetFloat("NpcSave"));
            }
        }

    public void UpdateHydration(float hydrationInp)
    {
        hydration.text = "Hydration: " + Math.Round(hydrationInp) + "/100";
    }

    IEnumerator TextCountDown()
    {
        yield return new WaitForSeconds(3);
        if(SceneManager.GetActiveScene().name == "FA2") promptText.SetActive(false);
    }

}

