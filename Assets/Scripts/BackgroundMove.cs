using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 startPoint;
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ResetPoint"))
        {
            transform.position = startPoint;
           // Debug.Log("Colide");
        }
    }
}
