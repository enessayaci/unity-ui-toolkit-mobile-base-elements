using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController
{
    private Label CoinText;
    public static List<VisualElement> hideIngameElements_AsideLeft;
    public static List<VisualElement> hideIngameElements_AsideRight;
    public static List<VisualElement> hideIngameElements_Top;
    public static List<VisualElement> hideIngameElements_Middle;
    public static List<VisualElement> hideIngameElements_Bottom;

    public static List<VisualElement> showIngameElements_AsideLeft;
    public static List<VisualElement> showIngameElements_AsideRight;
    public static List<VisualElement> showIngameElements_Top;
    public static List<VisualElement> showIngameElements_Middle;
    public static List<VisualElement> showIngameElements_Bottom;

    public static Button TapToPlayButton;


    public void Initialize()
    {
        //Find base parent nodes to avoid iterate all hierarchy when need a inner element like buttons, labels etc... 
        VisualElement mainMenuView = UIManager.root.Q<VisualElement>("MainMenuView");
        VisualElement header = mainMenuView.Q<VisualElement>("Header");
        VisualElement body = mainMenuView.Q<VisualElement>("Body");
        VisualElement top = body.Q<VisualElement>("Top");
        VisualElement middle = body.Q<VisualElement>("Middle");
        VisualElement bottom = body.Q<VisualElement>("Bottom");
        VisualElement asideLeft = body.Q<VisualElement>("AsideLeft");
        VisualElement bodyMain = body.Q<VisualElement>("Main");
        VisualElement asideRight = body.Q<VisualElement>("AsideRight");

        TapToPlayButton = body.Q<Button>(name: "TapToPlayButton");
        hideIngameElements_AsideLeft = asideLeft.Query(className: "hide-in-game").ToList();
        hideIngameElements_AsideRight = asideRight.Query(className: "hide-in-game").ToList();
        hideIngameElements_Top = top.Query(className: "hide-in-game").ToList();
        hideIngameElements_Middle = middle.Query(className: "hide-in-game").ToList();
        hideIngameElements_Bottom = bottom.Query(className: "hide-in-game").ToList();

        showIngameElements_AsideLeft = asideLeft.Query(className: "show-in-game").ToList();
        showIngameElements_AsideRight = asideRight.Query(className: "show-in-game").ToList();
        showIngameElements_Top = middle.Query(className: "show-in-game").ToList();
        showIngameElements_Middle = middle.Query(className: "show-in-game").ToList();
        showIngameElements_Bottom = middle.Query(className: "show-in-game").ToList();

        SpecifyTransitions();

        AttachTapToPlayButton(body);
        AttachMenuTogglerButton(asideRight);
        AssingCoinLabel(header);
        //GameManager.OnCoinUpdated += OnCoinUpdated;

    }

    private void SpecifyTransitions()
    {
        float transitionDelay = 0f;
        foreach (VisualElement el in hideIngameElements_AsideLeft)
        {
            el.style.transitionDelay = new List<TimeValue> { transitionDelay };
            transitionDelay += 0.1f;
        }

        transitionDelay = 0f;
        foreach (VisualElement el in hideIngameElements_AsideRight)
        {
            el.style.transitionDelay = new List<TimeValue> { transitionDelay };
            transitionDelay += 0.1f;
        }

        transitionDelay = 0f;
        foreach (VisualElement el in hideIngameElements_Top)
        {
            el.style.transitionDelay = new List<TimeValue> { transitionDelay };
            transitionDelay += 0.1f;
        }

        transitionDelay = 0f;
        foreach (VisualElement el in hideIngameElements_Middle)
        {
            el.style.transitionDelay = new List<TimeValue> { transitionDelay };
            transitionDelay += 0.1f;
        }

        transitionDelay = 0f;
        foreach (VisualElement el in hideIngameElements_Bottom)
        {
            el.style.transitionDelay = new List<TimeValue> { transitionDelay };
            transitionDelay += 0.1f;
        }

        foreach (VisualElement el in showIngameElements_AsideLeft)
        {
            el.style.transitionDelay = new List<TimeValue> { transitionDelay };
            transitionDelay += 0.1f;
        }

        transitionDelay = 0f;
        foreach (VisualElement el in showIngameElements_AsideRight)
        {
            el.style.transitionDelay = new List<TimeValue> { transitionDelay };
            transitionDelay += 0.1f;
        }

        transitionDelay = 0f;
        foreach (VisualElement el in showIngameElements_Top)
        {
            el.style.transitionDelay = new List<TimeValue> { transitionDelay };
            transitionDelay += 0.1f;
        }

        transitionDelay = 0f;
        foreach (VisualElement el in showIngameElements_Middle)
        {
            el.style.transitionDelay = new List<TimeValue> { transitionDelay };
            transitionDelay += 0.1f;
        }

        transitionDelay = 0f;
        foreach (VisualElement el in showIngameElements_Bottom)
        {
            el.style.transitionDelay = new List<TimeValue> { transitionDelay };
            transitionDelay += 0.1f;
        }
    }

    private void AttachTapToPlayButton(VisualElement parentToSearch)
    {
        //_body.RegisterCallback<PointerDownEvent>((_ev) =>
        //{
        //    Debug.Log("Tapped!");
        //});

        //Find TapToPlayButton and assign it
        // Clicking TapToPlay means we start the game so we are in the game, then we should hide "hide-in-game" classed elements
        Button TapToPlayButton = parentToSearch.Q<Button>("TapToPlayButton");

        TapToPlayButton.clicked += () =>
        {
            TapToPlayButton.AddToClassList("display-none");
            MakeVisibleInGameElements();
        };
    }

    private void AttachMenuTogglerButton(VisualElement parentToSearch)
    {
        Button MenuTogglerButton = parentToSearch.Q<Button>(name: "MenuTogglerButton");

        // Clicking Menu Toggler means we pause the game so we are not in the game, then we should show back hidden "hide-in-game" classed elements and hide "show-in-game" classed elements
        MenuTogglerButton.clicked += () =>
        {
            TapToPlayButton.RemoveFromClassList("display-none");

            MakeInvisibleInGameElements();
        };
    }

    private void AssingCoinLabel(VisualElement parentToSearch)
    {
        //Find CoinLabel and assign it
        TemplateContainer CoinLabel = parentToSearch.Q<TemplateContainer>(name: "CoinLabel");
        CoinText = CoinLabel.Q<Label>(name: "label-text");
    }

    public void OnCoinUpdated(int coin)
    {
        CoinText.text = coin.ToString();
    }

    public static void MakeVisibleInGameElements()
    {
        foreach (VisualElement el in hideIngameElements_AsideLeft)
        {
            el.AddToClassList("hidden");
        }

        foreach (VisualElement el in showIngameElements_AsideLeft)
        {
            el.RemoveFromClassList("hidden");
        }

        foreach (VisualElement el in hideIngameElements_AsideRight)
        {
            el.AddToClassList("hidden");
        }

        foreach (VisualElement el in showIngameElements_AsideRight)
        {
            el.RemoveFromClassList("hidden");
        }

        foreach (VisualElement el in hideIngameElements_Top)
        {
            el.AddToClassList("hidden");
        }

        foreach (VisualElement el in showIngameElements_Top)
        {
            el.RemoveFromClassList("hidden");
        }

        foreach (VisualElement el in hideIngameElements_Middle)
        {
            el.AddToClassList("hidden");
        }

        foreach (VisualElement el in showIngameElements_Middle)
        {
            el.RemoveFromClassList("hidden");
        }

        foreach (VisualElement el in hideIngameElements_Bottom)
        {
            el.AddToClassList("hidden");
        }

        foreach (VisualElement el in showIngameElements_Bottom)
        {
            el.RemoveFromClassList("hidden");
        }
    }

    public static void MakeInvisibleInGameElements()
    {
        foreach (VisualElement el in hideIngameElements_AsideLeft)
        {
            el.RemoveFromClassList("hidden");
        }

        foreach (VisualElement el in showIngameElements_AsideLeft)
        {
            el.AddToClassList("hidden");
        }

        foreach (VisualElement el in hideIngameElements_AsideRight)
        {
            el.RemoveFromClassList("hidden");
        }

        foreach (VisualElement el in showIngameElements_AsideRight)
        {
            el.AddToClassList("hidden");
        }

        foreach (VisualElement el in hideIngameElements_Top)
        {
            el.RemoveFromClassList("hidden");
        }

        foreach (VisualElement el in showIngameElements_Top)
        {
            el.AddToClassList("hidden");
        }

        foreach (VisualElement el in hideIngameElements_Middle)
        {
            el.RemoveFromClassList("hidden");
        }

        foreach (VisualElement el in showIngameElements_Middle)
        {
            el.AddToClassList("hidden");
        }

        foreach (VisualElement el in hideIngameElements_Bottom)
        {
            el.RemoveFromClassList("hidden");
        }

        foreach (VisualElement el in showIngameElements_Bottom)
        {
            el.AddToClassList("hidden");
        }
    }
}
