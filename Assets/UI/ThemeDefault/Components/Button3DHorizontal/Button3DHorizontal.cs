
using UnityEngine;
using UnityEngine.UIElements;

public class Button3DHorizontal : MonoBehaviour
{
    private Button3DHorizontalController controller;

    private void OnEnable()
    {
        UIDocument menu = GetComponent<UIDocument>();
        VisualElement root = menu.rootVisualElement;

        controller = new(root);

        controller.ChangeTexts();

    }
}
