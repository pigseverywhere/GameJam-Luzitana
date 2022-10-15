using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Player : MonoBehaviour
{


    public Transform followPlayer;

    private Transform cameraTransform;

    // definir posição da camera
    public Vector3 playerOffset;

    // velocidade da camera 
    public float MoveSpeed = 200f;


    // Start is called before the first frame update
    void Start()
    {
        
        cameraTransform = transform;

    }

    // atualizar posição do jogador
    public void SetTarget(Transform newTransformTarget){

        followPlayer =  newTransformTarget;

    }


       
    


    private void LateUpdate(){

         if(followPlayer != null) {

            cameraTransform.position = Vector3.Lerp(cameraTransform.position, followPlayer.position + playerOffset, MoveSpeed * Time.deltaTime);    
        }


    }

       

    
}
