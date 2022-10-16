using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public string[] coord;
    Vector3 movimento = Vector3.zero;

    public ObjectStatic[] script;
    public GameObject[] objects;

    bool[] direction = {true,true,true,true };

    void Start()
    {
        


    }

    
    void Update()
    {


        Movimentacao(Time.deltaTime);



    }


    private void Movimentacao(float deltaTime)
    {

        if (direction[0] == true)
        {

            if (Input.GetKey(KeyCode.W))
            {

                movimento += new Vector3(0, 0, 8 * deltaTime);
                transform.position = movimento;
            }

        }

    }


}
