using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using FluffyUnderware.Curvy.Controllers;
using TMPro;

[RequireComponent(typeof(InputData))]
public class cubeRotation : MonoBehaviour
{
    public Transform cubeTransform;

    public float smooth = 1.5f;

    private InputData _input_data;
    private int _left_rot_score = 0;
    private int _right_rot_score = 0;

    private SplineController sc;

    private Quaternion previousRotation; // Stores the previous rotation of the hand

    // Start is called before the first frame update
    void Start()
    {
        _input_data = GetComponent<InputData>();
        sc = GetComponent<SplineController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input_data._left_controller.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion leftRotation) && _input_data._right_controller.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rightRotation))
        {
            _left_rot_score = Mathf.RoundToInt(leftRotation.eulerAngles.z);
            _right_rot_score = Mathf.RoundToInt(rightRotation.eulerAngles.z);

            if ((_left_rot_score >= 0 && _left_rot_score <= 360) && (_right_rot_score >= 0 && _right_rot_score <= 360))
            {
                float mean = (_left_rot_score + _right_rot_score) / 2f;
                float offset_percentage = (0.0f < mean && mean <=180.0f)? mean/90.0f : (360.0f - mean)/90.0f;
                //float offset_percentage = (0.0f < leftScore && leftScore <=180.0f)? leftScore/90.0f : (360.0f - leftScore)/90.0f;

                float radius = offset_percentage * 57.0f;
                //cubeTransform.rotation = Quaternion.Euler(0f, -mean, 0f);
                sc.OffsetAngle = -90.0f;

                sc.OffsetRadius = Mathf.Lerp(sc.OffsetRadius, (0.0f <= mean && mean <=180.0f) ? -radius : radius, smooth * Time.deltaTime);
                //sc.OffsetRadius = Mathf.Lerp(sc.OffsetRadius, (0.0f <= leftScore && leftScore <=180.0f) ? -radius : radius, smooth * Time.deltaTime);
            }

            /*float rotationAngle = Quaternion.Angle(previousRotation, leftRotation); // Calculate the rotation angle
            Vector3 rotationAxis = Vector3.zero; // Calculate the rotation axis
            float leftScore;
            leftRotation.ToAngleAxis(out leftScore, out rotationAxis);
            float rotationDirection = Vector3.Dot(rotationAxis, Vector3.up); // Determine the rotation direction
            if (rotationAngle > 0.0f)
            {
                float offset_percentage = rotationAngle;

                float radius = offset_percentage * 57.0f;
                if (rotationDirection > 0.0f)
                {
                    Debug.Log("Clockwise rotation detected!"); 
                // Clockwise rotation detected
                    sc.OffsetRadius = Mathf.Lerp(sc.OffsetRadius,  -radius, smooth * Time.deltaTime);
                }
                else
                {
                    Debug.Log("Counterclockwise rotation detected!");                             
                // Counterclockwise rotation detected
                    sc.OffsetRadius = Mathf.Lerp(sc.OffsetRadius,  radius, smooth * Time.deltaTime);
                }
            }
            previousRotation = leftRotation; // Store the current rotation as the previous rotation for the next frame*/

        }
    }
}
