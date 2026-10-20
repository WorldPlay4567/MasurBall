using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{


    public Text text;
    public int count;
    public GameObject aniamted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<Text>();
        RectTransform t = GetComponent<RectTransform>();
        t.anchoredPosition = new Vector2(-Screen.width / 2 + 200, 0 + 50);
    }


    public void addCount()
    {
        count++;
        SpriteAnimation sprite = aniamted.gameObject.GetComponent<SpriteAnimation>();
        sprite.start();
    }

    // Update is called once per frame
    void Update()
    {

        text.text = "Î×ÊÈ: " + count;
    }
}
