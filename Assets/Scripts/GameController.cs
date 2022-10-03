
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [HideInInspector]
    public List<Transform> listPos = new List<Transform>(12);
    public List<GameObject> listEnemy = new List<GameObject>();
    //public EnemyController[] arrEnemy = new EnemyController[12];

    public int noCurrentPos = 0;

    public GameObject enemyPrefab;
    public Transform spawPointEnemy;

    public bool isArranged = false;
    public bool isEndGame = false;

    public Text txtWin;

    public static int checkNum = 0;

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
        // txtWin.enabled = false;
        txtWin.gameObject.SetActive(false);
        StartCoroutine(SpawEnemy(0.5f));
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void ResetInfoScene()
    {
        noCurrentPos = 0;
        isArranged = false;
        //isEndGame = false;
    }
    public int GetCheckNum()
    {
        checkNum++;
        return checkNum;
    }
    IEnumerator SpawEnemy(float delay = 3f)
    {
        yield return new WaitForSeconds(delay);
        //txtWin.enabled = false;
        txtWin.gameObject.SetActive(false);
        for (int i = 0; i < 12; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject temp = Instantiate(enemyPrefab, spawPointEnemy.position, Quaternion.identity) as GameObject;
            temp.SetActive(true);
            listEnemy.Add(temp);
        }
        isEndGame = false;
        //arrEnemy = FindObjectsOfType<EnemyController>();       
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
        //Invoke(nameof(LoadScene), 3f);
    }
    public void CheckEndGame()
    {
        for (int i = 0; i < listEnemy.Count; i++)
        {
            if (listEnemy[i] == null)
            {
                listEnemy.Remove(listEnemy[i]);
            }
        }
        // Debug.Log($"listCount is : {listEnemy.Count}");
        if (listEnemy.Count == 1 && !isEndGame)
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