using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinColliderController : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // ADD COIN TO PLAYER
            other.GetComponent<CoinSystem>().addCoin();
            
            Destroy(gameObject);
        }
    }
}
