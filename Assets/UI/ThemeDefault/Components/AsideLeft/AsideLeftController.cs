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
        UIManager.root.Query<TemplateContainer>("SettingsButtonInstance").Children<Button>().First().clicked += OnClickSettingsButton;
    }

    private void OnClickSettingsButton()
    {
        Debug.Log("Clicked Settings Button!");
    }

}
