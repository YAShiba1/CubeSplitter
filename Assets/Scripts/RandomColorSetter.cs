using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RandomColorSetter : MonoBehaviour
{
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        SetRandomColor();
    }

    private void SetRandomColor()
    {
        float randomRed = Random.value;
        float randomGreen = Random.value;
        float randomBlue = Random.value;

        Color randomColor = new Color(randomRed, randomGreen, randomBlue);

        Material material = _renderer.material;

        material.color = randomColor;
    }
}
