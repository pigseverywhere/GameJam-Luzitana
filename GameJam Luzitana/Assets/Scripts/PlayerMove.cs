using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // movimento velocidade
    public float speed = 200f;

    private Rigidbody rb;


    private Camera mainCamera;



    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        mainCamera = FindObjectOfType<Camera>();

        
    }

    private void FixedUpdate() {
        
        
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");


        Vector3 movimento = new Vector3(moveHorizontal, 0.0f, moveVertical); // direção do vetor
    

    rb.AddForce(movimento * speed);



    Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
    Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
    float rayLenght;

    if(groundPlane.Raycast(cameraRay, out rayLenght))
    {

        Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
        Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

        transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

    }
    }

    


        
   
}
