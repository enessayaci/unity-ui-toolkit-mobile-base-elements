using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadingController
{
    #region Loading elements
        private static TemplateContainer Loading;
        private static VisualElement dot1;
        private static VisualElement dot2;
        private static VisualElement dot3;
        private static VisualElement dot4;
        private static bool isDot1Up = false;
        private static bool isDot2Up = false;
        private static bool isDot3Up = false;
        private static bool isDot4Up = false;
        private static bool isLoadingVisible = false;
        private static int loadingShowCount;
    #endregion
    public void Initialize()
    {
        AssignDots();
    }

    private void AssignDots()
    {
        Loading = UIManager.root.Q<TemplateContainer>("Loading");
        dot1 = Loading.Q<VisualElement>("dot1");
        dot2 = Loading.Q<VisualElement>("dot2");
        dot3 = Loading.Q<VisualElement>("dot3");
        dot4 = Loading.Q<VisualElement>("dot4");
    }

    public static void ShowLoading()
    {
        if (isLoadingVisible)
        {
            loadingShowCount += 1;
            return;
        }

        isLoadingVisible = true;
        Loading.AddToClassList("show");
        loadingShowCount += 1;
        SubscribeTransitionEvents();
        isDot1Up = true;
        dot1.AddToClassList("animate");
    }

    public static void HideLoading()
    {
        if (!isLoadingVisible)
        {
            return;
        }

        if (--loadingShowCount != 0)
        {
            return;
        }

        isLoadingVisible = false;
        Loading.RemoveFromClassList("show");

        LeaveTransitionEvents();

        dot1.RemoveFromClassList("animate");
        dot2.RemoveFromClassList("animate");
        dot3.RemoveFromClassList("animate");
        dot4.RemoveFromClassList("animate");

    }

    private static void SubscribeTransitionEvents()
    {

        dot1.RegisterCallback<TransitionEndEvent>(OnTransitionEnd);
        dot2.RegisterCallback<TransitionEndEvent>(OnTransitionEnd);
        dot3.RegisterCallback<TransitionEndEvent>(OnTransitionEnd);
        dot4.RegisterCallback<TransitionEndEvent>(OnTransitionEnd);
    }

    private static void LeaveTransitionEvents()
    {

        dot1.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);
        dot2.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);
        dot3.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);
        dot4.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);
    }

    private static void OnTransitionEnd(TransitionEndEvent transitionEndEvent)
    {
        VisualElement dotUp = (VisualElement)transitionEndEvent.target;

        switch (dotUp.name)
        {
            case "dot1":
                if (isDot1Up)
                {
                    isDot1Up = false;
                    isDot2Up = true;
                    dot1.RemoveFromClassList("animate");
                    dot2.AddToClassList("animate");
                }

                break;

            case "dot2":
                if (isDot2Up)
                {
                    isDot2Up = false;
                    isDot3Up = true;
                    dot2.RemoveFromClassList("animate");
                    dot3.AddToClassList("animate");
                }

                break;

            case "dot3":
                if (isDot3Up)
                {
                    isDot3Up = false;
                    isDot4Up = true;
                    dot3.RemoveFromClassList("animate");
                    dot4.AddToClassList("animate");
                }

                break;

            case "dot4":
                if (isDot4Up)
                {
                    isDot4Up = false;
                    isDot1Up = true;
                    dot4.RemoveFromClassList("animate");
                    dot1.AddToClassList("animate");
                }

                break;
        }


    }
}