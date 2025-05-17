using UnityEngine;
using UnityEngine.UI;

public class UIBalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    public RectTransform canvasTransform;
    public float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnBalloon), 0f, spawnInterval);
    }

    void SpawnBalloon()
    {
        GameObject balloon = Instantiate(balloonPrefab, canvasTransform);
        RectTransform rt = balloon.GetComponent<RectTransform>();

        // Determinã latimea canvasului ca sa alegi un X random corect
        float canvasWidth = canvasTransform.rect.width;
        float randomX = Random.Range(-canvasWidth / 2f + 100f, canvasWidth / 2f - 100f);

        // Pozitioneaza balonul jos (in partea de jos a canvasului)
        rt.anchoredPosition = new Vector2(randomX, -canvasTransform.rect.height / 2f - 100f);

        // Culoare aleatoare
        Image image = balloon.GetComponent<Image>();
        image.color = GetRandomColor();

        // Adaugã miscare
        balloon.AddComponent<UIBalloonMovement>();
    }
    Color GetRandomColor()
    {
        // Gama RGB mai deschisa (evita culori prea intunecate)
        float r = Random.Range(0.4f, 1f);
        float g = Random.Range(0.4f, 1f);
        float b = Random.Range(0.4f, 1f);

        return new Color(r, g, b, 1f);
    }



}
