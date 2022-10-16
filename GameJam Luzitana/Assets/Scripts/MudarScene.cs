using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarScene : MonoBehaviour
{
    public string nome;
     void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void MudarCena()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(nome);

    }

}
