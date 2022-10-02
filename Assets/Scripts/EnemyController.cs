using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    GameController gameController;
    // Start is called before the first frame update
    private Transform currentTarget;
    private int noCurrentTarget = 0;
    public float moveSpeed = 5f;
    private Vector2 moveDirection;
    private Vector2 posTarget;
    private bool isArrange = false;
    private bool isPatrol = false;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
    public List<Transform> listPos = new List<Transform>(12);
    public List<Transform> listTarget = new List<Transform>(6);

    public float duration;
    public float distance;
    private Vector3 pointPatrol;
    public Transform point_A;
    public Transform point_B;
    public Transform parent;
    void Start()
    {
        gameController = GameController.Instance;

        currentTarget = listTarget[noCurrentTarget];
        SetDirection(listTarget[0]);
        //Debug.Log(listTarget[0].name);
      
        //transform.DOMove(new Vector3(0, 2, 0), duration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

        //posTarget = gameController.listPos[gameController.noCurrentPos].position;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveToPos(posTarget);
        if (isArrange)
        {
            //Debug.Log("Lerp");
            MoveToPos(posTarget);
        }
        else
        {
            MoveToTarget(moveDirection);
        }
         if(gameController.isArranged && !isPatrol)
        {
            Patrol();
            isPatrol = true;
        }
    }

    private void OnDisable()
    {
        //Debug.Log($"OnDisable {gameController.GetCheckNum()}");
        transform.DOPause();
        gameController.CheckEndGame();
    }
    
    public void Patrol()
    {
        pointPatrol = transform.position;
        pointPatrol.y += distance;
        transform.DOMove(pointPatrol, duration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
    public void SetPos()
    {
        float randomX = Random.Range(point_A.localPosition.x, point_B.localPosition.x);
        float x = Mathf.Clamp(randomX, point_A.localPosition.x, point_B.localPosition.x);
        float randomZ = Random.Range(point_A.localPosition.x, point_B.localPosition.x);
        float z = Mathf.Clamp(randomZ, point_A.localPosition.z, point_B.localPosition.z);
        Vector3 rewardPos = new Vector3(x, 1.08f, z);
        transform.localPosition = rewardPos;
    }

    public void SetDirection(Transform target)
    {
        moveDirection = listTarget[noCurrentTarget].position - transform.position;
        moveDirection.Normalize();
    }
    public void MoveToTarget(Vector2 moveDirection)
    {       
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    public void MoveToPos(Vector2 Position)
    {
        transform.position =  Vector2.Lerp(transform.position, Position, 0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("CheckLine") && !isArrange)
        {
           // Debug.Log("Change Direction");
            noCurrentTarget++;
            if (noCurrentTarget > 5)
            {
                //Debug.Log("NoCurrentTarget was > 6");
                moveDirection = Vector2.zero;
                isArrange = true;
                posTarget = gameController.listPos[gameController.noCurrentPos].position;
                gameController.noCurrentPos++;
                if (gameController.noCurrentPos == 12)
                {
                    Invoke(nameof(SetArranged), 1f);
                }
                noCurrentTarget = 0;
                ////gameController.noCurrentPos = 0;
            }
            else
            {
                currentTarget = listTarget[noCurrentTarget];
                SetDirection(currentTarget);
            }
            
        }
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    public void SetArranged()
    {
        gameController.isArranged = true;
    }
   

}
