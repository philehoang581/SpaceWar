using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> objArr = new List<GameObject>();
    public GameObject[] objList = new GameObject[10];
    public Test[] testArr;
    public int no = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (objArr[no] == null)
            {
                Debug.Log("null");
                objArr[no] = null;
                objList[no] = null;
            }
            
            else
            {
                Destroy(objArr[no]);

            }
            foreach (var item in objList)
            {
                Debug.Log(item);
            }
            testArr = GameObject.FindObjectsOfType<Test>();
        }
    }
}
