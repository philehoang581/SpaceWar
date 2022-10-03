using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseManager : Singleton<FirebaseManager>
{
    public static FirebaseManager Instance;
    private void Start()
    {
        Instance = this;

        Toast.Show("Start Game");
    }
}
