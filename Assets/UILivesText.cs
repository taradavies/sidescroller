using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    TMP_Text _livesText;
    void Awake() 
    {
        _livesText = GetComponent<TMP_Text>();
    }
    void Start()
    {
        _livesText.SetText(GameManager.Instance.Lives.ToString());
        GameManager.Instance.OnLivesChanged += GameManager_OnLivesChanged;
    }
    void GameManager_OnLivesChanged(int lives)
    {
        _livesText.SetText(lives.ToString());
    }
}
