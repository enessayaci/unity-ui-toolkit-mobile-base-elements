using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadingController : MonoBehaviour
{
    #region Loading elements
    private static TemplateContainer Loading;
    private static VisualElement dot1;
    private static VisualElement dot2;
    private static VisualElement dot3;
    private static bool isDot1Up = false;
    private static bool isDot2Up = false;
    private static bool isDot3Up = false;
    private static bool isLoadingVisible = false;
    private static int loadingShowCount;

    private static LoadingController instance;
    #endregion
    public void Initialize()
    {
        instance = new GameObject("LoadingHelper").AddComponent<LoadingController>();
        AssignDots();
    }

    private void AssignDots()
    {
        Loading = UIManager.root.Q<TemplateContainer>("Loading");
        dot1 = Loading.Q<VisualElement>("dot1");
        dot2 = Loading.Q<VisualElement>("dot2");
        dot3 = Loading.Q<VisualElement>("dot3");
    }

    public static void ShowLoading()
    {
        //If already opened
        if (isLoadingVisible)
        {
            loadingShowCount += 1;
            return;
        }


        instance.StartCoroutine(ShowLoadingCoroutine().GetEnumerator());

    }

    private static IEnumerable ShowLoadingCoroutine()
    {
        isLoadingVisible = true;
        Loading.AddToClassList("show");
        loadingShowCount += 1;

        yield return new WaitForSeconds(0.25f);

        //If newly openning 
        dot1.style.transitionDelay = new List<TimeValue> { 0f };
        dot2.style.transitionDelay = new List<TimeValue> { 0.1f };
        dot3.style.transitionDelay = new List<TimeValue> { 0.2f };

        SubscribeTransitionEvents();

        isDot1Up = true;
        dot1.AddToClassList("animate");
        isDot2Up = true;
        dot2.AddToClassList("animate");
        isDot3Up = true;
        dot3.AddToClassList("animate");
    }

    public static void HideLoading()
    {
        //If loading didnt opened. Means that you are trying to hide Loading without Openning it
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

        dot1.style.transitionDelay = new List<TimeValue> { 0f };
        dot2.style.transitionDelay = new List<TimeValue> { 0f };
        dot3.style.transitionDelay = new List<TimeValue> { 0f };

        dot1.RemoveFromClassList("animate");
        dot2.RemoveFromClassList("animate");
        dot3.RemoveFromClassList("animate");

    }

    private static void SubscribeTransitionEvents()
    {

        dot1.RegisterCallback<TransitionEndEvent>(OnTransitionEnd);
        dot2.RegisterCallback<TransitionEndEvent>(OnTransitionEnd);
        dot3.RegisterCallback<TransitionEndEvent>(OnTransitionEnd);
    }

    private static void LeaveTransitionEvents()
    {

        dot1.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);
        dot2.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);
        dot3.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);
    }

    private static void OnTransitionEnd(TransitionEndEvent transitionEndEvent)
    {
        if (!transitionEndEvent.AffectsProperty("translate")) return;

        VisualElement dotUp = (VisualElement)transitionEndEvent.target;
        dotUp.style.transitionDelay = new List<TimeValue> { 0f };

        switch (dotUp.name)
        {
            case "dot1":
                if (isDot1Up)
                {
                    isDot1Up = false;
                    dot1.RemoveFromClassList("animate");
                }
                else
                {
                    isDot1Up = true;
                    dot1.style.transitionDelay = new List<TimeValue> { 0.2f };
                    dot1.AddToClassList("animate");
                }

                break;

            case "dot2":
                if (isDot2Up)
                {
                    isDot2Up = false;

                    dot2.RemoveFromClassList("animate");
                }
                else
                {
                    isDot2Up = true;
                    dot2.style.transitionDelay = new List<TimeValue> { 0.2f };
                    dot2.AddToClassList("animate");
                }

                break;

            case "dot3":
                if (isDot3Up)
                {
                    isDot3Up = false;
                    dot3.RemoveFromClassList("animate");
                }
                else
                {
                    isDot3Up = true;
                    dot3.style.transitionDelay = new List<TimeValue> { 0.2f };
                    dot3.AddToClassList("animate");
                }

                break;
        }
    }
}
