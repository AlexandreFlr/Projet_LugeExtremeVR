using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Canvas buttonCanvas;
    public Canvas rulesCanvas;
    public Canvas controlsCanvas;

    void Start(){
        buttonCanvas.gameObject.SetActive(true);
        rulesCanvas.gameObject.SetActive(false);
        controlsCanvas.gameObject.SetActive(false);

    }

    public void OnClick(){
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickRules(){
        buttonCanvas.gameObject.SetActive(false);
        controlsCanvas.gameObject.SetActive(false);
        rulesCanvas.gameObject.SetActive(true);
    }

    public void BackClick(){
        buttonCanvas.gameObject.SetActive(true);
        controlsCanvas.gameObject.SetActive(false);
        rulesCanvas.gameObject.SetActive(false);
    }

    public void OnClickControls(){
        buttonCanvas.gameObject.SetActive(false);
        controlsCanvas.gameObject.SetActive(true);
        rulesCanvas.gameObject.SetActive(false);
    }
}
