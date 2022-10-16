using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collectible : MonoBehaviour
{
   

    public TMPro.TextMeshProUGUI scoreText;
    public int StarScore = 0;
    public AudioSource collectSound;



    // Update is called once per frame
    void Update()
    {

        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
        
    }

    void OnTriggerEnter(Collider other){


       if(other.CompareTag("Lua")){

            collectSound.Play();
            StarScore += 1;
            scoreText.text = "Pontuação: " + StarScore;

            Destroy(gameObject);
        }
    }
}
