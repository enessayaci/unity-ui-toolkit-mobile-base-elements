using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController 
{
    private Label CoinText;
    public void Initialize()
    {
        //Find base parent nodes to avoid iterate all hierarchy when need a inner element like buttons, labels etc... 
        VisualElement mainMenuView = UIManager.root.Q<VisualElement>("MainMenuView");
        Debug.Log("mainMenuView: " + mainMenuView.name);
        VisualElement header = mainMenuView.Q<VisualElement>("Header");
        Debug.Log("header: " + header.name);
        VisualElement body = mainMenuView.Q<VisualElement>("Body");
        Debug.Log("body: " + body.name);
        VisualElement asideLeft = body.Q<VisualElement>("AsideLeft");
        Debug.Log("asideLeft: " + asideLeft.name);
        VisualElement bodyMain = body.Q<VisualElement>("Main");
        VisualElement asideRight = body.Q<VisualElement>("AsideRight");

        AttachSettingsButton(asideLeft);
        AssingCoinLabel(header);
        GameData.OnUpdateCoin += OnUpdateCoin;
        
    }

    private void AttachSettingsButton(VisualElement parentToSearch)
    {
        //Find SettingsButton and attach its on click events
        Button settingsButton = parentToSearch.Q<TemplateContainer>("SettingsButton").Q<Button>();
        settingsButton.clicked += () =>
        {
            //Modal content to show will be detected from clicked button's tooltip value. eg: to show ModalContentSettings, you must set tooltip value of clicked button as "ModalContentSettings".
            ModalController.ShowModal(settingsButton.tooltip);
        };
    }

    private void AssingCoinLabel(VisualElement parentToSearch)
    {
        //Find CoinLabel and assign it
        TemplateContainer CoinLabel = parentToSearch.Q<TemplateContainer>(name: "CoinLabel");
        CoinText = CoinLabel.Q<Label>(name: "label-text");
    }

    public void OnUpdateCoin(string coin)
    {
        CoinText.text = coin;
    }
}
