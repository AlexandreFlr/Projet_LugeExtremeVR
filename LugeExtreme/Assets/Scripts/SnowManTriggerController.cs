using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FluffyUnderware.Curvy.Controllers;
using UnityEngine.SceneManagement;


public class SnowManTriggerController : MonoBehaviour
{

    public AudioSource collisionSound;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(collisionSound){
                collisionSound.Play();
            }
           other.GetComponent<SplineController>().Speed *= 0.5f;
           GameManager.Instance.DecreasePV();
           Destroy(gameObject);
           
        }
    }
}
