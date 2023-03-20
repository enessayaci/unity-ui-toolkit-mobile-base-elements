using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public static VisualElement root;

    private HeaderController _HeaderController;
    private Button3DHorizontalController _Button3DHorizontalController;
    private AsideLeftController _AsideLeftController;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        UIDocument menu = GetComponent<UIDocument>();
        root = menu.rootVisualElement;

        //Components' custom scripts below

        _HeaderController = new();
        _HeaderController.Initialize();

        _Button3DHorizontalController = new();
        _Button3DHorizontalController.Initialize();

        _AsideLeftController = new();
        _AsideLeftController.Initialize();

    }



}
