using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Toast : MonoBehaviour
{
    private static Toast _instance;
    [SerializeField] private GameObject Bg;
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
                _instance = Instantiate(asset, Popups.Popup.transform, false);
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

   // [SerializeField] private CanvasGroup Canvas;
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _timeShow = 5;
    private void ApperBot(string content, bool isStop)
    {
       // Bg.SetActive(false);
        if (IsStop) return;
        IsStop = isStop;
        StartCoroutine(ScalePenal());
        //Canvas.alpha = 1;
        _contentTxt.text = content;
        //_contentTxt.transform.localScale = Vector3.zero; 



    }

    private IEnumerator ScalePenal()
    {
        _panel.transform.localScale = Vector3.zero;
        float tempTime = 0;
        while (tempTime<_timeShow)
        {
            yield return new WaitForSeconds(0.1f);
            tempTime += 0.5f;
            _panel.transform.localScale = new Vector3(1, 1, 1)*(tempTime/_timeShow );
        }

        yield return new WaitForSeconds(2f);

        Debug.LogError($"Hide Toast");
        while (tempTime > 0)
        { 
            yield return new WaitForSeconds(0.1f);
            tempTime -= 0.5f;
            _panel.transform.localScale = new Vector3(1, 1, 1) * (tempTime/_timeShow);
        }
    }

}
