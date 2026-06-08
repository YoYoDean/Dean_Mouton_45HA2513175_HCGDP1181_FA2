using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource = GameObject.FindGameObjectWithTag("WaterSound").GetComponent<AudioSource>();
            audioSource.Play();
            GameManager.instance.hydration += 20;
            audioSource.PlayOneShot(audioClip);
            UiManager.instance.UpdateHydration(GameManager.instance.hydration);
            Destroy(this.gameObject);
        }
        //ill later add press e to pickup water
    }
}
