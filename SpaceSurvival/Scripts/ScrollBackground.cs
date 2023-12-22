using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour
{

    public RawImage image;
    public float y;

    // Update is called once per frame
    void Update()
    {
        Vector2 shift = new Vector2(0, y) * Time.deltaTime;
        image.uvRect = new Rect(image.uvRect.position + shift , image.uvRect.size);
    }
}
