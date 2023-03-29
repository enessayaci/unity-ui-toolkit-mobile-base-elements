using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static VisualElement root;

    private MainMenuController _MainMenuController;
    private PopupController _PopupController;
    private PopupSettingsController _PopupSettingsController;
    private TabController _TabController;


    private void OnEnable()
    {
        UIDocument menu = GetComponent<UIDocument>();
        root = menu.rootVisualElement;

        //Components' custom scripts below

        _MainMenuController = new();
        _MainMenuController.Initialize();

        _PopupController = new();
        _PopupController.Initialize();

        _PopupSettingsController = new();
        _PopupSettingsController.Initialize();

        new GameObject("LoadingHelper").AddComponent<LoadingController>();

        _TabController = new();
        _TabController.Initialize();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            LoadingController.ShowLoading();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            LoadingController.HideLoading();
        }
    }

}
