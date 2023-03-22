using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

//public class testovski : EditorWindow
//{
//    [SerializeField]
//    private VisualTreeAsset m_VisualTreeAsset = default;

//    [SerializeField] private VisualTreeAsset uxmlToSearch;
//    [MenuItem("Window/UI Toolkit/testovski")]
//    public static void ShowExample()
//    {
//        testovski wnd = GetWindow<testovski>();
//        wnd.titleContent = new GUIContent("testovski");
//    }

//    public void CreateGUI()
//    {
//        // Each editor window contains a root VisualElement object
//        VisualElement root = rootVisualElement;

//        // VisualElements objects can contain other VisualElement following a tree hierarchy.
//        VisualElement label = new Label("Hello World! From C#");
//        root.Add(label);

//        Button button = new Button();
//        button.text = "tıhla bağa";
//        button.clicked += () =>
//        {
//            IterateElements(uxmlToSearch.Instantiate());
//            EditorUtility.SetDirty(uxmlToSearch);
//            AssetDatabase.SaveAssets();
//            //EnumerateVisualElementHierarchy(uxmlToSearch.Instantiate());
//        };
//        root.Add(button);
//        // Instantiate UXML
//        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
//        root.Add(labelFromUXML);
//    }

//    private void IterateElements(VisualElement element)
//    {

//        if (element.ClassListContains("btn-3d-horizontal-instance"))
//        {
//            Debug.Log($"Element: {element.name}, Tooltip: {element.tooltip}");
//            Label l = element.Query().Children<Button>().First().Query<Label>("text").First();
//            l.text = element.tooltip;

//        }

//        for (int i = 0; i < element.childCount; i++)
//        {
//            IterateElements(element[i]);
//        }
//    }

//    //public IEnumerable<VisualElement> EnumerateVisualElementHierarchy(this VisualElement element)
//    //{
//    //    yield return element;

//    //    foreach (VisualElement childElement in element.Children())
//    //    {
//    //        childElement.EnumerateVisualElementHierarchy();
//    //    }
//    //}

//}
