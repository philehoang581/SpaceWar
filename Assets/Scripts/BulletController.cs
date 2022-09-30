using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 10f;
    void Start()
    {
        Invoke(nameof(DestroyBullet), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.up * bulletSpeed * Time.deltaTime) ;
    }
    public void DestroyBullet()
    {
        if(gameObject!=null)
        {
            //GameController.Instance.CheckEndGame();
            Destroy(gameObject);
        }
       
    }    
}
