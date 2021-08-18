using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.5f;
    public Vector3 offset;
    public float xMin, xMax, yMin, yMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
           clamp();
       
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        
    }
    void clamp()
    {
        float clampX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float clampY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector2(clampX, clampY);


    }
}
