using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeaderController
{
    private Label CoinLabel;

    public void Initialize()
    {
        GetCoinLabel();
        GameData.OnUpdateCoin += OnUpdateCoin;
    }

    private void GetCoinLabel()
    {
        TemplateContainer instance = UIManager.root.Query<TemplateContainer>(name: "CoinLabelInstance");
        CoinLabel = instance.Q<Label>(name: "label-text");
    }

    public void OnUpdateCoin(string coin)
    {
        CoinLabel.text = coin;
    }
}
