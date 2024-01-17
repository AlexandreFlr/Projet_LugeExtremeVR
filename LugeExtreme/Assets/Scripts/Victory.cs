using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource collisionSound ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            if(collisionSound){
                collisionSound.Play();
            }
            SceneManager.LoadScene("VictoryMenu");
        }
    }
}
