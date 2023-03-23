using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static VisualElement root;
    public static List<TemplateContainer> modalContents;
    public static TemplateContainer modal;
    public static VisualElement backdrop;
    public static bool isModalActive = false;

    private MainInfoController _MainInfoController;
    private AsideLeftController _AsideLeftController;
    private ModalController _ModalController;
    private ModalContentSettingsController _ModalContentSettingsController;

    private void OnEnable()
    {
        UIDocument menu = GetComponent<UIDocument>();
        root = menu.rootVisualElement;
        backdrop = root.Q<VisualElement>("Backdrop");
        modal = root.Q<TemplateContainer>("Modal");
        modalContents = modal.Query<VisualElement>("ModalDialog").Children<TemplateContainer>().ToList();

        //Components' custom scripts below

        _MainInfoController = new();
        _MainInfoController.Initialize();

        _AsideLeftController = new();
        _AsideLeftController.Initialize();

        _ModalController = new();
        _ModalController.Initialize();

        _ModalContentSettingsController = new();
        _ModalContentSettingsController.Initialize();

    }



}
