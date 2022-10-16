using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{

    public float timer = 60;
    public TextMeshProUGUI textoTimer;


    void Start()
    {


        
        
    }
    
    
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
        int tempo = (int)timer;
        textoTimer.text = tempo.ToString();
    }
}
