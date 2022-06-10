using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    TMP_Text _livesText;
    void Start() 
    {
        _livesText = GetComponent<TMP_Text>();
        _livesText.SetText(GameManager.Instance.Lives.ToString());
    }
    void Update()
    {
        _livesText.SetText(GameManager.Instance.Lives.ToString());
    }
}
