using UnityEngine.UIElements;

public class TabController
{

    /* Define member variables*/
    private const string tabClassName = "tab";
    // Tab and tab content have the same prefix but different suffix
    // Define the suffix of the tab name
    private const string tabNameSuffix = "Tab";
    // Define the suffix of the tab content name
    private const string contentNameSuffix = "Content";

    public void Initialize()
    {
        RegisterTabCallbacks();
    }

    private void RegisterTabCallbacks()
    {
        UQueryBuilder<Label> tabs = GetAllTabs();
        tabs.ForEach((Label tab) =>
        {
            tab.RegisterCallback<ClickEvent>(TabOnClick);
        });
    }

    /* Method for the tab on-click event: 

       - If it is not selected, find other tabs that are selected, unselect them 
       - Then select the tab that was clicked on
    */
    private void TabOnClick(ClickEvent evt)
    {
        Label clickedTab = evt.currentTarget as Label;
        if (!TabIsCurrentlySelected(clickedTab))
        {
            GetAllTabs().Where(
                (tab) => tab != clickedTab && TabIsCurrentlySelected(tab)
            ).ForEach(UnselectTab);
            SelectTab(clickedTab);
        }
    }
    //Method that returns a Boolean indicating whether a tab is currently selected
    private static bool TabIsCurrentlySelected(Label tab)
    {
        return tab.ClassListContains("show");
    }

    private UQueryBuilder<Label> GetAllTabs()
    {
        return UIManager.root.Query<Label>(className: tabClassName);
    }

    /* Method for the selected tab: 
       -  Takes a tab as a parameter and adds the "show" class
       -  Then finds the tab content and removes the "display-none" class */
    private void SelectTab(Label tab)
    {
        tab.AddToClassList("show");
        VisualElement content = FindContent(tab);
        content.RemoveFromClassList("display-none");
    }

    /* Method for the unselected tab: 
       -  Takes a tab as a parameter and removes the "show" class
       -  Then finds the tab content and adds the "display-none" class */
    private void UnselectTab(Label tab)
    {
        tab.RemoveFromClassList("show");
        VisualElement content = FindContent(tab);
        content.AddToClassList("display-none");
    }

    // Method to generate the associated tab content name by for the given tab name
    private static string GenerateContentName(Label tab) =>
        tab.name.Replace(tabNameSuffix, contentNameSuffix);

    // Method that takes a tab as a parameter and returns the associated content element
    private VisualElement FindContent(Label tab)
    {
        return UIManager.root.Q(GenerateContentName(tab));
    }
}

