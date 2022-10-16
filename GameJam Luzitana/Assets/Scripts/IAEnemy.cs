using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




public class IAEnemy : MonoBehaviour
{

    enum STATE
    {
        N,
        S,
        L,
        O

    };

    public string[] coord;

    public Vector3 movimento = Vector3.zero;
    STATE state;

    int contador;

    public ObjectStatic[] script;
    public GameObject[] objects;

    public GameObject colider;
    public TextMeshProUGUI timer;
    public int []AumentoDoColider;

    void Start()
    {
        state = STATE.N;

        ChangeChoise();
        Debug.Log(state);
    }

    
    void Update()
    {
        //contador += 1;
        //if(contador > 50)
        //{
        //    ChangeChoise();
        //    contador = 0;
        //}

        UpdateChoise(Time.deltaTime);

        int tempo = int.Parse(timer.text);
        if(tempo < AumentoDoColider[0])
        {
            colider.GetComponent<BoxCollider>().size = new Vector3(2f,2f,2f);
            colider.GetComponent<Light>().range = 4;
        }
        if (tempo < AumentoDoColider[1])
        {
            colider.GetComponent<BoxCollider>().size = new Vector3(3f, 3f, 3f);
            colider.GetComponent<Light>().range = 5;
        }
        if (tempo < AumentoDoColider[1])
        {
            colider.GetComponent<BoxCollider>().size = new Vector3(4f, 4f, 4f);
            colider.GetComponent<Light>().range = 6;
        }
    }

    public void ChangeChoise()
    {
        List<string> aux = new List<string>();
        for (int i = 0; i< 4; i++)
        {

            if(i == 0 && coord[i] == "N")
            {
                aux.Add("N");

            }
            if (i == 1 && coord[i] == "L")
            {
                aux.Add("L");

            }
            if (i == 2 && coord[i] == "S")
            {
                aux.Add("S");
            }
            if (i == 3 && coord[i] == "O")
            {
                aux.Add("O");


            }
            
        }

       
        int r = Random.Range(0, aux.Count);
        switch(aux[r])
        {
            case "N":
                state = STATE.N;
                break;
            case "L":
                state = STATE.L;
                break;
            case "S":
                state = STATE.S;
                break;
            case "O":
                state = STATE.O;
                break;


        }

        

    }
    public void UpdateChoise(float deltaTime)
    {

        switch(state)
        {
            case STATE.N:
                movimento += new Vector3(0, 0, 3 * deltaTime);
                transform.position = movimento;
                break;
            case STATE.S:
                movimento -= new Vector3(0, 0, 3 * deltaTime);
                transform.position = movimento;
                break;
            case STATE.L:
                movimento += new Vector3(3 * deltaTime, 0, 0);
                transform.position = movimento;
                break;
            case STATE.O:
                movimento -= new Vector3(3 * deltaTime, 0, 0);
                transform.position = movimento;
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
                    ChangeChoise();
                }

            }

        }



    }


}
