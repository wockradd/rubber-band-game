using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFollowBallPositions : MonoBehaviour
{
    public LineRenderer lr;
    public Transform nextBall;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, lr.transform.position);
        lr.SetPosition(1, nextBall.position);
    }
}
