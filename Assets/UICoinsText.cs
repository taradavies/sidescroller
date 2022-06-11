using System;
using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    TMP_Text _coinsText;
    void Start()
    {
        _coinsText = GetComponent<TMP_Text>();
        GameManager.Instance.OnCoinCollected += GameManager_OnCoinCollected;
    }

    private void GameManager_OnCoinCollected(int coinsCollected)
    {
        _coinsText.SetText(coinsCollected.ToString());
    }
}
