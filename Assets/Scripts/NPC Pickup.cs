using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class NPCPickup : MonoBehaviour
{
    public GameObject pressEKEy;
    public bool isCarrying;
    public static NPCPickup instance;
    public AudioClip audioClip;
    public AudioSource audioSource;
    private bool inBox;
    void Awake()
    {
        instance = this;
        pressEKEy = GameObject.FindGameObjectWithTag("PressE");
        pressEKEy.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    void Update()
    {
        if(Keyboard.current.eKey.wasPressedThisFrame && inBox && !GameManager.instance.isCarrying)
        {
            Debug.Log("Pickup");
            audioSource = GameObject.FindGameObjectWithTag("PickSound").GetComponent<AudioSource>();
            audioSource.Play();
            pressEKEy.GetComponent<TextMeshProUGUI>().enabled = false;
            GameManager.instance.isCarrying = true;
            gameObject.SetActive(false);
            UiManager.instance.objective.text = "Objective: Carrying 1 Person -- Take to BUNKER"; 
            //isCarrying = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        pressEKEy.GetComponent<TextMeshProUGUI>().enabled = true;
        
        if(other.CompareTag("Player"))
        {
            inBox = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        inBox = false;
        pressEKEy.GetComponent<TextMeshProUGUI>().enabled = false;
    }
}
