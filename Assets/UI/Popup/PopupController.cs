using UnityEngine.UIElements;

public class PopupController
{
    public void Initialize()
    {
        AttachEventListeners();
    }

    public static void ShowPopup(string modalContentToShow)
    {
        UIManager.backdrop.AddToClassList("show");
        UIManager.popup.AddToClassList("show");

        foreach (TemplateContainer modalContent in UIManager.popupContents)
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
        UIManager.backdrop.RemoveFromClassList("show");
        UIManager.popup.RemoveFromClassList("show");
    }

    private void AttachEventListeners()
    {
        //Find all ClosePopupButton buttons and attach their on click events
        foreach (TemplateContainer popupHeader in UIManager.popup.Query<TemplateContainer>("PopupHeader").ToList())
        {
            Button closeModalButton = popupHeader.Q<Button>("ClosePopupButton");

            closeModalButton.clicked += () =>
            {
                HidePopup();
            };
        }

        Button backgroundButton = UIManager.popup.Q<Button>("BackgroundButton");
        backgroundButton.clicked += () =>
        {
            HidePopup();
        };

    }

}
