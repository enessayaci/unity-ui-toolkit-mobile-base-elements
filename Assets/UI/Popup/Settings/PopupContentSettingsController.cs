using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UIElements.Toggle;

public class PopupContentSettingsController
{
    public void Initialize()
    {
        AttachEventListeners();
    }

    private static void AttachEventListeners()
    {
        VisualElement popupBodySettings = PopupController.popup.Q<VisualElement>("PopupBodySettings");

        //Find MusicToggle element in ModalBodySettings element and set its value changed event
        Toggle musicToggle = popupBodySettings.Q<Toggle>("MusicToggle");
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
        Toggle soundToggle = popupBodySettings.Q<Toggle>("SoundToggle");
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
    }
}
