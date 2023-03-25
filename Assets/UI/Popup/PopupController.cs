using System.Collections.Generic;
using UnityEngine.UIElements;

public class PopupController
{
    private static List<TemplateContainer> popupContents; //It is for all popup contents, for example: PopupContentSettings. There is only one popup frame taking place in MainMenu.uxml, every popup content takes place inside popup body and display:flex when needed.
    public static TemplateContainer popup;
    private static VisualElement backdrop;
    public void Initialize()
    {
        backdrop = UIManager.root.Q<VisualElement>("Backdrop");
        popup = UIManager.root.Q<TemplateContainer>("Popup");
        popupContents = popup.Query<VisualElement>("PopupDialog").Children<TemplateContainer>().ToList();
        AttachEventListeners();
    }

    public static void ShowPopup(string modalContentToShow)
    {
        backdrop.AddToClassList("show");
        popup.AddToClassList("show");

        foreach (TemplateContainer modalContent in popupContents)
        {
            if (modalContent.name == modalContentToShow)
            {
                modalContent.RemoveFromClassList("display-none");
                modalContent.AddToClassList("show");
            }
            else
            {
                modalContent.AddToClassList("display-none");
                modalContent.RemoveFromClassList("show");
            }
        }
    }

    public static void HidePopup()
    {
        backdrop.RemoveFromClassList("show");
        popup.RemoveFromClassList("show");
    }

    private void AttachEventListeners()
    {
        //Find all ClosePopupButton buttons and attach their on click events
        foreach (TemplateContainer popupHeader in popup.Query<TemplateContainer>("PopupHeader").ToList())
        {
            Button closeModalButton = popupHeader.Q<Button>("ClosePopupButton");

            closeModalButton.clicked += () =>
            {
                HidePopup();
            };
        }

        Button backgroundButton = popup.Q<Button>("BackgroundButton");
        backgroundButton.clicked += () =>
        {
            HidePopup();
        };

    }

}
