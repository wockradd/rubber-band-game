using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRubberBand : MonoBehaviour
{

    public GameObject startCircle;
    public GameObject endCircle;
    public GameObject middleCircle;
    public GameObject lineRenderer;
    public int numberOfPoints;

    private GameObject[] points;
    private GameObject line;

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints+2];

        Vector3 startPos = startCircle.transform.position;
        Vector3 endPos = endCircle.transform.position;
        Vector3 distanceBetweenStartAndEnd = endPos - startPos;
        Vector3 distanceBetweenEachPoint = distanceBetweenStartAndEnd / (numberOfPoints+1);

        //build the points
        for (int i=0; i<points.Length; i++) {
            if (i==0) {
                points[i] = startCircle;
                continue;
            }
            if (i==points.Length-1) {
                points[i] = endCircle;
                continue;
            }
            points[i] = Instantiate(middleCircle,startPos + i*distanceBetweenEachPoint,Quaternion.identity);
            points[i].transform.SetParent(this.gameObject.transform);
            points[i].transform.SetSiblingIndex(i);
        }

            line = Instantiate(lineRenderer);
            line.transform.SetParent(this.gameObject.transform);
        


        //set the points springs
        SpringJoint2D springJoint;
        for (int i = 0; i < points.Length-1; i++)
        {
            springJoint = points[i].GetComponent<SpringJoint2D>();
            springJoint.connectedBody = points[i + 1].GetComponent<Rigidbody2D>();
            springJoint.distance = distanceBetweenEachPoint.magnitude/1.5f;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
