using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Toast : MonoBehaviour
{
    private static Toast _instance;
    [SerializeField] private TextMeshProUGUI _contentTxt;
    private bool IsStop;
    public static void Show(string content, bool isStop=false)
    {
        CheckInstance(()=>
        {
            _instance.ApperBot(content, isStop);
        });
    }
    private static void CheckInstance(Action completed)
    {
        if (_instance == null)
        {
            var laddAsset = Resources.LoadAsync<Toast>("Popups/Toast/Toast");
            var asset = laddAsset.asset as Toast;
            if (asset != null)
            {
                _instance = Instantiate(asset, Popups.Instance.transform, false);
                if (completed != null)
                {
                    completed();
                }
            }
        }
        else
        {
            if (completed != null)
            {
                completed();
            }
        }
    }

    private void ApperBot(string content, bool isStop)
    {
        if (IsStop) return;
        IsStop = isStop;

        _contentTxt.text = content;


    }
}
