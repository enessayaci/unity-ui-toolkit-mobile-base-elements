using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static VisualElement root;
    public static List<TemplateContainer> popupContents; //It is for all popup contents, for example: PopupContentSettings. There is only one popup frame taking place in MainMenu.uxml, every popup content takes place inside popup body and display:flex when needed.
    public static TemplateContainer popup;
    public static VisualElement backdrop;
    public static bool isModalActive = false;

    private MainMenuController _MainMenuController;
    private PopupController _PopupController;
    private PopupContentSettingsController _PopupContentSettingsController;

    private void OnEnable()
    {
        UIDocument menu = GetComponent<UIDocument>();
        root = menu.rootVisualElement;
        backdrop = root.Q<VisualElement>("Backdrop");
        popup = root.Q<TemplateContainer>("Popup");
        popupContents = popup.Query<VisualElement>("PopupDialog").Children<TemplateContainer>().ToList();

        //Components' custom scripts below

        _MainMenuController = new();
        _MainMenuController.Initialize();

        _PopupController = new();
        _PopupController.Initialize();

        _PopupContentSettingsController = new();
        _PopupContentSettingsController.Initialize();

    }



}
