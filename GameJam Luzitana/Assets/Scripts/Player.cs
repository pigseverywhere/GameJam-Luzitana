using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum STATE
    {
        N,
        S,
        L,
        O,
        PARADO

    };

    STATE state;

    public string[] coord;
    public Vector3 movimento = Vector3.zero;

    public ObjectStatic[] script;
    public GameObject[] objects;

    List<bool> direction = new List<bool>();

    void Start()
    {
        transform.position = movimento;
        direction = ChangeChoise();

    }

    
    void Update()
    {


        Movimentacao(Time.deltaTime);
        UpdateChoise(Time.deltaTime);


    }

    public List<bool> ChangeChoise()
    {

        List<bool> aux = new List<bool>();
        for (int i = 0; i < 4; i++)
        {

            if (i == 0 && coord[i] == "N")
            {
                aux.Add(true);

            }
            else
            {
                aux.Add(false);
            }

            if (i == 1 && coord[i] == "L")
            {
                aux.Add(true);

            }
            else
            {
                aux.Add(false);
            }
            if (i == 2 && coord[i] == "S")
            {
                aux.Add(true);
            }
            else
            {
                aux.Add(false);
            }
            if (i == 3 && coord[i] == "O")
            {
                aux.Add(true);


            }
            else
            {
                aux.Add(false);
            }



        }
        return aux;
    }
    private void Movimentacao(float deltaTime)
     {
        
        for (int i = 0; i < 4; i++)
        {



            if (coord[i] == "N")
            {

                if (Input.GetKey(KeyCode.W))
                {

                    state = STATE.N;
                }

            }

            if ( coord[i] == "L")
            {

                if (Input.GetKey(KeyCode.D))
                {
                    state = STATE.L;
                }

            }
            if ( coord[i] == "S")
            {

                if (Input.GetKey(KeyCode.S))
                {

                    state = STATE.S;
                }

            }
            if (coord[i] == "O")
            {

                if (Input.GetKey(KeyCode.A))
                {

                    state = STATE.O;
                }

            }




            
        }

       



    }
    public void UpdateChoise(float deltaTime)
    {

        switch (state)
        {
            case STATE.N:
                movimento -= new Vector3(0, 0, 5 * deltaTime);
                transform.position = movimento;
                break;
            case STATE.S:
                movimento += new Vector3(0, 0, 5 * deltaTime);
                transform.position = movimento;
                break;
            case STATE.L:
                movimento -= new Vector3(5 * deltaTime, 0, 0);
                transform.position = movimento;
                break;
            case STATE.O:
                movimento += new Vector3(5 * deltaTime, 0, 0);
                transform.position = movimento;
                break;
            case STATE.PARADO:
                
                break;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
       

        if (other.tag.Equals("static"))
        {

            for (int i = 0; i < objects.Length; i++)
            {

                if (other.gameObject == objects[i])
                {

                    coord = script[i].coord;

                    direction = ChangeChoise();
                    state = STATE.PARADO;
                    
                }

            }

        }

        if (other.tag.Equals("inimigo"))
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");

        }

    }


}
