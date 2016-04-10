using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    public static GameObject player;
    public GameObject camerass;
    public Rigidbody body;
    public float movementSpeed = 10;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        camerass = GameObject.Find("Main Camera");
        body = player.GetComponent<Rigidbody>();
        CameraController.Target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
                if (hit.transform.gameObject.tag == "Player")
                {
                    player = hit.transform.gameObject;
                    CameraController.Target = player.transform;
                    body = player.GetComponent<Rigidbody>();
                }
        }

        float moveHorizontal = Mathf.Cos(camerass.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Vertical") - Mathf.Sin(camerass.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Horizontal");
        float moveVertical = Mathf.Sin(camerass.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Vertical") + Mathf.Cos(camerass.transform.eulerAngles.y * Mathf.Deg2Rad) * Input.GetAxis("Horizontal");
        float goat = camerass.transform.eulerAngles.x;
        Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);
        body.AddForce(movement * movementSpeed);

    }
}
