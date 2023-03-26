using UnityEngine;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UIElements.Toggle;
using Button = UnityEngine.UIElements.Button;
public class PopupSettingsController
{
    public void Initialize()
    {
        AttachEventListeners();
    }

    private static void AttachEventListeners()
    {
        TemplateContainer popupSettings = PopupController.FindPopup("PopupSettings");

        //Find MusicToggle element in ModalBodySettings element and set its value changed event
        Toggle musicToggle = popupSettings.Q<Toggle>("MusicToggle");
        musicToggle.RegisterValueChangedCallback((evt) =>
        {
            if (evt.newValue == true)
            {
                //if checked, do this
            }
            else
            {
                //if unchecked, do this
            }
            Debug.Log(evt.newValue);
        });


        //Find SoundToggle element in ModalBodySettings element and set its value changed event
        Toggle soundToggle = popupSettings.Q<Toggle>("SoundToggle");
        soundToggle.RegisterValueChangedCallback((evt) =>
        {
            if (evt.newValue == true)
            {
                //if checked, do this
            }
            else
            {
                //if unchecked, do this
            }
            Debug.Log(evt.newValue);
        });

        //Find WinButton and attach its on click events
        Button winButton = popupSettings.Q<Button>("WinButtonSettings");
        winButton.clicked += () =>
        {
            //Popup content to show will be detected from clicked button's tooltip value. eg: to show PopupContentSettings, you must set tooltip value of clicked button as "PopupContentSettings".
            PopupController.HidePopup("PopupSettings");
            PopupController.ShowPopup("PopupWin");
        };
    }
}
