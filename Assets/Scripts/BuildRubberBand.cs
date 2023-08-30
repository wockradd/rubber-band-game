using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRubberBand : MonoBehaviour
{

    public GameObject startCircle;
    public GameObject endCircle;
    public GameObject middleCircle;
    public int numberOfPoints;

    private GameObject[] points;

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints-1];

        Vector3 startPos = startCircle.transform.position;
        Vector3 endPos = endCircle.transform.position;
        Vector3 distanceBetweenStartAndEnd = endPos - startPos;
        Vector3 distanceBetweenEachPoint = distanceBetweenStartAndEnd / numberOfPoints;

        //build the points
        for (int i=0; i<points.Length; i++) {
            points[i] = Instantiate(middleCircle,startPos + (i+1)*distanceBetweenEachPoint,Quaternion.identity);
            points[i].transform.SetParent(this.gameObject.transform);
        }

        //set the springs and lines
        LineFollowBallPositions lineScript;
        SpringJoint2D springJoint;

        lineScript = startCircle.GetComponent<LineFollowBallPositions>();
        springJoint = startCircle.GetComponent<SpringJoint2D>();
        lineScript.nextBall = points[0].transform;
        springJoint.connectedBody = points[0].GetComponent<Rigidbody2D>();

        for (int i = 0; i < points.Length; i++){
            lineScript = points[i].GetComponent<LineFollowBallPositions>();
            springJoint = points[i].GetComponent<SpringJoint2D>();

            if (i == points.Length-1){//last point
                lineScript.nextBall = endCircle.transform;
                springJoint.connectedBody = endCircle.GetComponent<Rigidbody2D>();
            }
            else{
                lineScript.nextBall = points[i+1].transform;
                springJoint.connectedBody = points[i+1].GetComponent<Rigidbody2D>();
            }        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
