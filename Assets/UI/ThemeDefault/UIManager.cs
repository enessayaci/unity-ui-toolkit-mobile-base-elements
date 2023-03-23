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

    private HeaderController _HeaderController;
    private Button3DHorizontalController _Button3DHorizontalController;
    private AsideLeftController _AsideLeftController;
    private ModalController _ModalController;

    private void OnEnable()
    {
        UIDocument menu = GetComponent<UIDocument>();
        root = menu.rootVisualElement;
        backdrop = root.Q<VisualElement>("Backdrop");
        modal = root.Q<TemplateContainer>("Modal");
        modalContents = modal.Query<VisualElement>("ModalDialog").Children<TemplateContainer>().ToList();

        //Components' custom scripts below

        _HeaderController = new();
        _HeaderController.Initialize();

        _Button3DHorizontalController = new();
        _Button3DHorizontalController.Initialize();

        _AsideLeftController = new();
        _AsideLeftController.Initialize();

        _ModalController = new();
        _ModalController.Initialize();

    }



}
