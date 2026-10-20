using NUnit.Framework.Constraints;
using System;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    float count;
    public Rigidbody rb;
    public GameObject camera;
    public float SPEED = 1.52f;
    public Vector3 vector3 = new Vector3();


    public GameObject prefabToSpawn; // Ссылка на префаб
    public Transform spawnPoint;





    public Vector3 targetRotate = new Vector3();
    public Vector3 currectRotate = new Vector3();

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        camera = transform.GetChild(0).gameObject;

    }

    void FixedUpdate()
    {

    }
    void Spawn()
    {
        if (spawnPoint != null)
        {
            // Спавн в конкретной точке с поворотом этой точки
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            // Спавн в координатах объекта со скриптом, без поворота (Quaternion.identity)
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
    }
    void Update()
    {
        count += 0.01f;

        Vector3 mouse = Input.mousePositionDelta;
        mouse.z = 0;
        mouse = mouse.normalized * 4f;

        targetRotate += mouse;
        targetRotate.y = +(float)Math.Sin(count) / 20;

        currectRotate = Vector3.Lerp(currectRotate, targetRotate, Time.deltaTime * 3);

        ///vector3.x + (float)Math.Sin(count) / 20
        camera.transform.localEulerAngles = new Vector3(-currectRotate.y, 0 - 90, 0);
        transform.localEulerAngles = new Vector3(0, currectRotate.x, 0);



        {
            rb.AddForce(0, -2, 0);
        }



        /// FIX CURSER
        Mouse.current.WarpCursorPosition(new Vector2(Screen.width / 2, Screen.height / 2));
        move(currectRotate);

        /////////
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }


    public void move(Vector3 vector3)
    {

        double radians = vector3.x * (Math.PI / 180.0);

        double x = Math.Cos(radians);
        double y = Math.Sin(radians);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 40f, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3((float)-x, 0f, (float)y) * SPEED);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3((float)x, 0f, (float)-y) * SPEED);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3((float)y, 0f, (float)x) * SPEED);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3((float)-y, 0f, (float)-x) * SPEED);
        }
    }
}
