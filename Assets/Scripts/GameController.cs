using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public List<Transform> listPos = new List<Transform>(12);
    public List<GameObject> listEnemy = new List<GameObject>(12);
    public EnemyController[] arrEnemy = new EnemyController[12];
    public int noCurrentPos = 0;
    public GameObject enemyPrefab;
    public Transform spawPointEnemy;
    public bool isArranged;
    public Text txtWin;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
 
        txtWin.gameObject.SetActive(false);
        StartCoroutine(SpawEnemy(0.5f));
 
    }
     
    IEnumerator SpawEnemy()
    {
 
        noCurrentPos = 0;
        isArranged = false;       
     
    }
    public int GetCheckNum()
    {
        checkNum++;
        return checkNum;
    }
    IEnumerator SpawEnemy(float delay = 3f)
    {
        yield return new WaitForSeconds(delay);
   
        txtWin.gameObject.SetActive(false);
 
        for (int i = 0; i < 12; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject temp = Instantiate(enemyPrefab, spawPointEnemy.position, Quaternion.identity)as GameObject;
            temp.SetActive(true);
            listEnemy.Add(temp);
        }
        arrEnemy = FindObjectsOfType<EnemyController>();
    }
    public void EndGame()
    {
 
        isEndGame = true;
        txtWin.gameObject.SetActive(true);
        if (isEndGame)
        {
            StartCoroutine(SpawEnemy(3f));
            ResetInfoScene();
        }                
 
    }
    public void CheckEndGame()
    {
        
        
        arrEnemy = FindObjectsOfType<EnemyController>();
        if(arrEnemy.Length<2)
        {
            Debug.Log("EndGame");
            EndGame();
        }      
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
