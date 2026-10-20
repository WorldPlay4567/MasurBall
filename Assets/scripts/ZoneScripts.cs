using UnityEngine;

public class ZoneScripts : MonoBehaviour
{

    public BoxCollider box;
    public GameObject ball;
    public GameObject text;
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }


    void Update()
    {
        
        



    }

    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (other.gameObject.name.StartsWith(ball.name))
        {

            TextScript textScript = text.GetComponent<TextScript>();
            textScript.addCount();
            Destroy(other.gameObject);
            
        }
    }
}
