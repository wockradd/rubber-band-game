using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform startCircle;
    public Transform endCircle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = endCircle.position - startCircle.position;
        Vector3 midPoint = startCircle.position + distance / 2;
        this.transform.position = new Vector3(midPoint.x,midPoint.y,gameObject.transform.position.z);
    }
}
