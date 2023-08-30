using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    public GameObject pegsParent;
    private Vector3 mousePos;
    private bool draggingMode = false;
    private Rigidbody2D rb;
    private bool collided = false;
    private bool isFirstFrame = true; //used so the player sticks to the pegs on the first frame

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        //rb.bodyType = RigidbodyType2D.Dynamic;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && draggingMode)
        {
            this.gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, this.gameObject.transform.position.z);
        }
        else {
            draggingMode = false;
            if (collided)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
            }
            else {
                rb.constraints = RigidbodyConstraints2D.None;
                
            }
            

        }
    }
    
    private void OnMouseOver()
    {
        //they clicked the circle
        if (Input.GetMouseButtonDown(0)) {
            draggingMode = true;
        } 

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Peg" && (Input.GetMouseButton(0) || isFirstFrame))
        {
            Debug.Log("collided with peg");
            collided = true;
            isFirstFrame = false;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Peg")
        {
            Debug.Log("out of peg");
            collided = false;

        }
    }
}
