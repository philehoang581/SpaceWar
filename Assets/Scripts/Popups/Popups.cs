using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popups : MonoBehaviour
{
    public static Popups Instance;
    static GameObject _canvasPage;
    public static GameObject CanvasPage
    {
        get
        {
            if (_canvasPage == null)
                _canvasPage = GameObject.FindWithTag("Canvas Page");

            return _canvasPage;
        }
    }
    static GameObject _popup;
    public static GameObject Popup
    {
        get
        {
            if (_popup == null)
                _popup = GameObject.FindWithTag("Popup");

            return _popup;
        }
    }
}
