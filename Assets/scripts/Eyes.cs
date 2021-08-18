using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    private bool isFollowing;

    public float followSpeed;

    public Transform followTarget;

    public float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        isFollowing = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {   
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
            clamp();
        }
    }
    void clamp()
    {
        float clampX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float clampY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector2(clampX, clampY);


    }
}
