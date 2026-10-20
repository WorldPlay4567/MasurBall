using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngineInternal;

public class SpriteAnimation : MonoBehaviour
{


    Vector2 first = new Vector2(0, Screen.height / 2 + 50);
    Vector2 to = new Vector2(0, Screen.height / 2 - 50);


    bool animated;
    float timeAnimated;

    RectTransform transform;

    void Start()
    {
        transform = GetComponent<RectTransform>();
    }


    public void start()
    {
        if (animated) return;

        animated = true;
        timeAnimated = 0;
        transform.anchoredPosition = first;
    }
    // Update is called once per frame
    void Update()
    {

        if (animated) {
            timeAnimated += 0.001f;
            if (timeAnimated > 1.0f) {
                animated = false;
            }
        }






        if (timeAnimated < 0.2)
        {
            float result1 = Mathf.InverseLerp(0.0f, 0.2f, timeAnimated);
            transform.anchoredPosition = Vector2.Lerp(first, to, result1);
        }
        else if (timeAnimated > 0.2 && timeAnimated < 0.7)
        {
            float result1 = Mathf.InverseLerp(0.2f, 0.7f, timeAnimated);
            transform.anchoredPosition = Vector2.Lerp(to, first, result1);

        }
        else {
            float result2 = Mathf.InverseLerp(0.7f, 1.0f, timeAnimated);
            transform.anchoredPosition = Vector2.Lerp(to, first, result2);
        }

    }
}
