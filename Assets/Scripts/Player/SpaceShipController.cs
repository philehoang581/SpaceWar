using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    // Start is called before the first frame update
    public Joystick joystick;

    public Transform spawPointBulletMain;
    public Transform spawPointBulletLeft;
    public Transform spawPointBulletRight;
    public GameObject bulletPrefab;


    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;
    private float xVlue;
    private float yVlue;

    private float xMove;
    private float yMove;
    public float moveSpeed = 5f;
    private Vector2 moveDirection;
    void Start()
    {
        StartCoroutine(nameof(FireBullet));
    }

    // Update is called once per frame
    void Update()
    {
       
        xMove = joystick.Horizontal;
        yMove = joystick.Vertical;
        moveDirection = new Vector2(xMove, yMove);
        moveDirection.Normalize();
        transform.Translate(moveDirection * moveSpeed*Time.deltaTime);
       
        xVlue = transform.position.x;
        yVlue = transform.position.y;
        
        xVlue = Mathf.Clamp(xVlue, xMin, xMax);
        yVlue = Mathf.Clamp(yVlue, yMin, yMax);
        transform.position = new Vector2(xVlue, yVlue);

       
    }
    private void LateUpdate()
    {

        

    }
    IEnumerator FireBullet()
    {
        yield return new WaitForSeconds(10f);
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            Vector2 tempPos = spawPointBulletMain.position;
            Instantiate(bulletPrefab,tempPos, spawPointBulletMain.rotation);

            Vector2 tempPosLeft = spawPointBulletLeft.position;
            Instantiate(bulletPrefab, tempPosLeft, spawPointBulletLeft.rotation);

            Vector2 tempPosRight = spawPointBulletRight.position;
            Instantiate(bulletPrefab, tempPosRight, spawPointBulletRight.rotation);
        }
       
    }
    public void FireBullets()
    {

        Instantiate(bulletPrefab, spawPointBulletMain, spawPointBulletMain);
    }
}
