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
    private LoadingController _LoadingController;



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

        _LoadingController = new();
        _LoadingController.Initialize();

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
