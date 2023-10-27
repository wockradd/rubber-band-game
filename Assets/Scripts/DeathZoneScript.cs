using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseScale", 0.5f, 0.01f);
    }

    // Update is called once per frame
    void IncreaseScale()
    {
        this.gameObject.transform.parent.transform.localScale += new Vector3(0,0.001f,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.gameObject.name);
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Start Circle" || collision.gameObject.tag == "End Circle")
        {
            FindObjectOfType<GameManager>().HandleGameOver();
        }
        Destroy(collision.gameObject);
        
    }
}
