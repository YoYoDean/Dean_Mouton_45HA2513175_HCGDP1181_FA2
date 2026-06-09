using UnityEngine;
using UnityEngine.InputSystem;

public class Bunker : MonoBehaviour
{
    
    private bool inBox;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && inBox)
        {
            GameManager.instance.UpdateNpc();
            UiManager.instance.objective.text = "Objective: Find People to Save -- Stay Hydrated!"; 
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        UiManager.instance.npcCarry.text = "E to Drop Person";
        //isCarrying = NPCPickup.instance.isCarrying;
        if (other.CompareTag("Player"))
        {
            inBox = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        UiManager.instance.npcCarry.text = "People Saved: " + GameManager.instance.npcRescue;
        inBox = false;
    }
}
