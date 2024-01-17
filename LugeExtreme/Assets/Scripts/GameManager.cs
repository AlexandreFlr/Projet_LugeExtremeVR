using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private int pv;

    public static GameManager Instance;
    public AudioSource failAudio;

    void Awake()
    {
        if(Instance == null) Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pv = 3;
    }

    public void DecreasePV()
    {
        pv --;
    }

    void Update()
    {
        if(pv == 0)
        {
            if(failAudio){
                failAudio.Play();
            }
        StartCoroutine(fail());
        SceneManager.LoadScene("LoseMenu");
        }
        
    }

    IEnumerator fail(){
       
        yield return new WaitForSeconds(2f);
        
    }
}
