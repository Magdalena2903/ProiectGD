using UnityEngine;

public class BalloonClickDestroy : MonoBehaviour
{
    public AudioClip popSound;

    public void DestroyBalloon()
    {
        // Reda sunetul POP
        AudioSource.PlayClipAtPoint(popSound, Camera.main.transform.position);

        // Distruge obiectul
        Destroy(gameObject);
    }
}
