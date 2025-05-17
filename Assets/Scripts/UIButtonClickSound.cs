using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonClickSound : MonoBehaviour, IPointerClickHandler
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        GameObject audioObject = GameObject.Find("UI_Audio");
        if (audioObject != null)
        {
            audioSource = audioObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogWarning("UI_Audio object not found in scene!");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
