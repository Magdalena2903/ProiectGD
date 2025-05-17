using UnityEngine;
using UnityEngine.UI;

public class UIBalloonSpawnerEnd : MonoBehaviour
{
    public GameObject balloonPrefab;
    public RectTransform canvasTransform;
    public float spawnInterval = 1.2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnBalloon), 0f, spawnInterval);
    }

    void SpawnBalloon()
    {
        GameObject balloon = Instantiate(balloonPrefab, canvasTransform);

        // Plaseaza balonul peste fundal, dar sub texte
        balloon.transform.SetSiblingIndex(1);

        RectTransform rt = balloon.GetComponent<RectTransform>();

        // Latimea reala a canvasului
        float canvasWidth = canvasTransform.rect.width;

        // Pozitie aleatoare pe X (acopera tot ecranul)
        float randomX = Random.Range(-canvasWidth / 2f + 50f, canvasWidth / 2f - 50f);

        // Apare jos de tot
        float spawnY = -canvasTransform.rect.height / 2f - 100f;

        rt.anchoredPosition = new Vector2(randomX, spawnY);

        // Culoare random
        Image image = balloon.GetComponent<Image>();
        image.color = GetRandomColor();

        balloon.AddComponent<UIBalloonMovement>();
    }

    Color GetRandomColor()
    {
        float r = Random.Range(0.4f, 1f);
        float g = Random.Range(0.4f, 1f);
        float b = Random.Range(0.4f, 1f);
        return new Color(r, g, b, 1f);
    }
}
