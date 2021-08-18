using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        GameObject G = new GameObject();
        G = GameObject.FindGameObjectWithTag("GameController");

        if (!G)
        {
            Instantiate(music, Vector3.zero, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
