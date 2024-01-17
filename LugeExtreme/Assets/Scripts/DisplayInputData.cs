using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour
{
    public TextMeshProUGUI _left_score;
    public TextMeshProUGUI _right_score;
    public Transform cubeTransform;

    private InputData _input_data;
    private int _left_max_score = 0;
    private int _right_max_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        _input_data = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input_data._left_controller.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion leftRotation) && _input_data._right_controller.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rightRotation))
        {
            _left_max_score = Mathf.RoundToInt(leftRotation.eulerAngles.z);
            _left_score.text = _left_max_score.ToString("F2");
            _right_max_score = Mathf.RoundToInt(rightRotation.eulerAngles.z);
            _right_score.text = _right_max_score.ToString("F2");

            if ((_left_max_score > 0 && _left_max_score < 360) && (_right_max_score > 0 && _right_max_score < 360))
            {
                cubeTransform.rotation = Quaternion.Euler(0f, -(_left_max_score + _right_max_score) / 2f, 0f);
                _left_score.text = "Rotate left!";
                _right_score.text = "Rotate left!";
            }
        }

    }
}
