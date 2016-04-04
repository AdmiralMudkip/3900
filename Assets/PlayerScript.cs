using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        offset = transform.position - target.transform.position;
    }

    float movementSpeed = 1;
    float turningSpeed = 60;

    public GameObject target;
    public float damping = 1;
    Vector3 offset;
    public float smoothing = 15f, dampening = 0.1f;
    
    // Update is called once per frame
    void Update () {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

        
        if (Input.GetKey(KeyCode.W))
        {

        }
        else if (Input.GetKey(KeyCode.A))
        {

        }
        else if (Input.GetKey(KeyCode.S))
        {
            
        }
        else if (Input.GetKey(KeyCode.D))
        {

        }
	}

    void LateUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position;

        transform.LookAt(target.transform.position);
    }


    void Awake()
    {

    }
}
