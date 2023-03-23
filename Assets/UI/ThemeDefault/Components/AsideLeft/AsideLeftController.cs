using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class AsideLeftController
{

    public void Initialize()
    {
        AttachClickEvents();
    }

    private void AttachClickEvents()
    {
        //Find SettingsButton and attach its on click events
        Button settingsButton = UIManager.root.Query<TemplateContainer>("SettingsButtonInstance").Children<Button>().First();
        settingsButton.clicked += () =>
        {
            //Modal content to show will be detected from clicked button's tooltip value. eg: to show ModalContentSettings, you must set tooltip value of clicked button as "ModalContentSettings".
            ModalController.ShowModal(settingsButton.tooltip);
        };

        //Find LevelsButton and attach its on click events
        Button levelsButton = UIManager.root.Q<Button>("LevelsButton");
        levelsButton.clicked += () =>
        {
            //Modal content to show will be detected from clicked button's tooltip value. eg: to show ModalContentSettings, you must set tooltip value of clicked button as "ModalContentSettings".
            ModalController.ShowModal(levelsButton.tooltip);
        };
    }

}
