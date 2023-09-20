using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFollowBallPositions : MonoBehaviour
{
    private LineRenderer lr;
    private GameObject rubberBand;
    private PolygonCollider2D pc;
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        pc = gameObject.GetComponent<PolygonCollider2D>();
        rubberBand = GameObject.FindGameObjectWithTag("Player");

        lr.positionCount = rubberBand.transform.childCount - 1;
        
        /*Mesh mesh = new Mesh();
        lr.BakeMesh(mesh);
        Vector2[] mesh2d = new Vector2[mesh.triangles.Length];

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Debug.Log(mesh.vertices[i]);
            mesh2d[i] = new Vector2(mesh.vertices[mesh.triangles[i]].x, mesh.vertices[mesh.triangles[i]].y);
        }

        PolygonCollider2D pc = gameObject.AddComponent<PolygonCollider2D>();
        for(int i=0; i<mesh.triangles.Length; i++) {
            Debug.Log(mesh.triangles[i]);
            mesh2d[i] = new Vector2(mesh.vertices[mesh.triangles[i]].x, mesh.vertices[mesh.triangles[i]].y);
        }

        pc.SetPath(0, mesh2d);*/
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < lr.positionCount; i++)
        {
            lr.SetPosition(i, rubberBand.transform.GetChild(i).transform.position);
        }

        Vector3[] points3d = new Vector3[lr.positionCount];
        Vector2[] points2d = new Vector2[lr.positionCount];

        lr.GetPositions(points3d);
        for (int i=0; i<points2d.Length; i++) {

                points2d[i] = new Vector2(points3d[i].x, points3d[i].y);
            
            
        }

        pc.points = points2d;
    }
}
