using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManController : MonoBehaviour
{
    public Transform target;
    public float speed = 0.8f;

    private bool isFollowing;
    // Start is called before the first frame update
    void Start()
    {
        isFollowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFollowing) return;
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }

    public void setIsFollowing()
    {
        isFollowing = true;
    }

    public void setTarget(Transform t)
    {
        target = t;
    }
}
