using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ModalController
{
    public void Initialize()
    {
        AttachEventListeners();
    }

    public static void ShowModal(string modalContentToShow)
    {
        UIManager.backdrop.AddToClassList("show");
        UIManager.modal.AddToClassList("show");

        foreach (TemplateContainer modalContent in UIManager.modalContents)
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

    public static void HideModal()
    {
        UIManager.backdrop.RemoveFromClassList("show");
        UIManager.modal.RemoveFromClassList("show");
    }

    private void AttachEventListeners()
    {
        //Find all CloseModalButton buttons and attach their on click events
        foreach (TemplateContainer modalHeader in UIManager.modal.Query<TemplateContainer>("ModalHeader").ToList())
        {
            Button closeModalButton = modalHeader.Q<Button>("CloseModalButton");

            closeModalButton.clicked += () =>
            {
                HideModal();
            };
        }

        Button backgroundButton = UIManager.modal.Q<Button>("BackgroundButton");
        backgroundButton.clicked += () =>
        {
            HideModal();
        };

    }

}
