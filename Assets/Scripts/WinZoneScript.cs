using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZoneScript : MonoBehaviour
{

    private bool ballInZone = false;
    private bool startCircleInZone = false;
    private bool endCircleInZone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ballInZone && startCircleInZone && endCircleInZone) {
            FindObjectOfType<GameManager>().HandleWinning();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag) {
            case "Ball":
                ballInZone = true;
                break;
            case "Start Circle":
                startCircleInZone = true;
                break;
            case "End Circle":
                endCircleInZone = true;
                break;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ball":
                ballInZone = false;
                break;
            case "Start Circle":
                startCircleInZone = false;
                break;
            case "End Circle":
                endCircleInZone = false;
                break;
        }
    }
}
