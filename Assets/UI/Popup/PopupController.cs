using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine.UIElements;

public class PopupController
{
    public static List<TemplateContainer> popups; //It is for all popup contents, for example: PopupContentSettings. There is only one popup frame taking place in MainMenu.uxml, every popup content takes place inside popup body and display:flex when needed.
    public void Initialize()
    {
        popups = UIManager.root.Query<TemplateContainer>().Where((x) => x.ClassListContains("popup-instance")).ToList();
        AttachEventListeners();
    }

    public static void ShowPopup(string popupToShow)
    {
        TemplateContainer popup = FindPopup(popupToShow);

        popup.Q<VisualElement>("Backdrop").AddToClassList("show"); //Show Backdrop of the popup
        popup.AddToClassList("show"); // add show class to make visible contents of the popup with animations 
    }

    public static void HidePopup(string popupToHide)
    {
        TemplateContainer popup = FindPopup(popupToHide);

        popup.Q<VisualElement>("Backdrop").RemoveFromClassList("show"); //Hide Backdrop of the popup
        popup.RemoveFromClassList("show");
    }

    public static TemplateContainer FindPopup(string popupToFind)
    {
        TemplateContainer result = new();
        foreach (TemplateContainer popup in popups)
        {
            if (popup.name == popupToFind)
            {
                result = popup;
            }
        }

        return result;
    }

    private void AttachEventListeners()
    {
        //Find all ClosePopupButton buttons and attach their on click events to close their popups
        foreach (TemplateContainer popup in popups)
        {
            Button closePopupButton = popup.Q<TemplateContainer>("PopupHeader").Q<Button>("ClosePopupButton");

            closePopupButton.clicked += () =>
            {
                HidePopup(popup.name);
            };
        }

        //Find all BackgroundButton buttons and attach their on click events to close their popups if it doesn't has "disable-background-click"
        foreach (TemplateContainer popup in popups)
        {
            if (popup.ClassListContains("disable-background-click")) continue;

            Button backgroundButton = popup.Q<Button>("BackgroundButton");

            backgroundButton.clicked += () =>
            {
                HidePopup(popup.name);
            };
        }

    }

}
