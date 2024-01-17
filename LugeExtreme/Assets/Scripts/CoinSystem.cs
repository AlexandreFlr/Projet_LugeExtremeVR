using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    private int current_value;
    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        current_value = 0;
        audiosource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCoin()
    {
        current_value++;
        audiosource.Play();

    }

    public int getValue(){return current_value;}
}
