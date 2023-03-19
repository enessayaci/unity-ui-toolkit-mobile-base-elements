using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Button3DHorizontalController 
{
    private readonly VisualElement root;
    public Button3DHorizontalController(VisualElement root)
    {
        this.root = root;
    }
    private UQueryBuilder<TemplateContainer> GetAllButton3DHorizontal()
    {
        return root.Query<TemplateContainer>(className: "btn-3d-horizontal-instance");
    }

    public void ChangeTexts()
    {
        List<TemplateContainer> instances = (List<TemplateContainer>)GetAllButton3DHorizontal().ToList();
        instances.ForEach((TemplateContainer instance) =>
        {
            Label l = instance.Query<Label>(name: "buttonText");
            l.text = instance.tooltip;
        });
    }
}
