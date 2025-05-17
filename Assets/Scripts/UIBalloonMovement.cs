using UnityEngine;

public class UIBalloonMovement : MonoBehaviour
{
    public float speed = 100f;

    void Update()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.anchoredPosition += new Vector2(0, speed * Time.deltaTime);

        if (rt.anchoredPosition.y > 1200f) // iese din ecran
        {
            Destroy(gameObject);
        }
    }
}
