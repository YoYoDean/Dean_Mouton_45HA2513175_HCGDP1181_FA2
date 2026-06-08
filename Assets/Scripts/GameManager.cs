using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float highScore;
    public float hydration = 100;
    public float npcRescue;
    public static GameManager instance;
    public bool isCarrying;


    void Awake()
    {
        instance = this;
        npcRescue = 0;
    }
    void Start()
{
    
    if (PlayerPrefs.HasKey("highScore"))
    {
        highScore = PlayerPrefs.GetFloat("highScore");

        if (SceneManager.GetActiveScene().name == "Start")
        {
            UiManager.instance?.UpdateScore();
        }
        if (SceneManager.GetActiveScene().name == "Game Over")
        {
            UiManager.instance?.UpdateScore();
        }
    }
}

    void Update()
    {

        if(SceneManager.GetActiveScene().name == "FA2")
        {
        if(hydration > 0) 
        {
            hydration -= Time.deltaTime/2.5f;
            UiManager.instance.UpdateHydration(hydration);
        }
        if(hydration > 100) 
        {
            Debug.Log("Hydration Boost ---- Heath Increasing");
            Health.instance.playerHealth += Time.deltaTime;
            UiManager.instance.UpdateHealth(Health.instance.playerHealth);
        }
        if(hydration <= 20) 
        {
            Debug.Log("Dehydrated ----- Find Water");
            Health.instance.playerHealth -= Time.deltaTime/2;
            UiManager.instance.UpdateHealth(Health.instance.playerHealth);
        }
        }
    }
    public void UpdateNpc()
    {
        if(isCarrying)
        {
            npcRescue += 1;
            Debug.Log(npcRescue);
            UiManager.instance.UpdateNpcUi(npcRescue);
            PlayerPrefs.SetFloat("NpcSave", PlayerPrefs.GetFloat("NpcSave") + npcRescue);
            isCarrying = false;
        }
    }
    

    public void UpdateHighScore()
    {
        if (UiManager.instance.iScore > PlayerPrefs.GetFloat("highScore"))
        {
            Debug.Log("New HighScore Saved");
            PlayerPrefs.SetFloat("highScore", UiManager.instance.iScore);
        }
    }

}
