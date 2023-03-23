using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeaderController
{
    private Label CoinText;

    public void Initialize()
    {
        AssingCoinLabel();
        GameData.OnUpdateCoin += OnUpdateCoin;
    }

    private void AssingCoinLabel()
    {
        TemplateContainer CoinLabel = UIManager.root.Query<TemplateContainer>(name: "CoinLabel");
        CoinText = CoinLabel.Q<Label>(name: "label-text");
    }

    public void OnUpdateCoin(string coin)
    {
        CoinText.text = coin;
    }
}
