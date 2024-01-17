using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPresentController : MonoBehaviour
{
    public CoinSystem cs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = cs.getValue().ToString();
    }
}
