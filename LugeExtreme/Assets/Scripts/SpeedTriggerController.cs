using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FluffyUnderware.Curvy.Controllers;


public class SpeedTriggerController : MonoBehaviour
{
    public float multiplier = 1.5f;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SplineController sc = other.GetComponent<SplineController>();
            sc.Speed *= multiplier;
        }
    }
}
