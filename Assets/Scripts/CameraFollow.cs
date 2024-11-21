using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float xc;

    [SerializeField]
    private float yc;

    public Transform target;
    

    void Start() {
        transform.position = new Vector3(PlayerStats.playerPos[0], PlayerStats.playerPos[1], -1);
    } // Start

    // Update is called once per frame
    void Update() {
        float x = transform.position.x, y = transform.position.y;

        float t = target.transform.position.y;
        if (t < yc && t  > - yc) 
            y = t;

        t = target.position.x;
        if (t < xc && t > -xc)
            x = t;
                                                    
        transform.position = new Vector3(x, y, -1);

    } // Update
}
