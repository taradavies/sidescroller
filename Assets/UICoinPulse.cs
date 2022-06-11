using UnityEngine;

public class UICoinPulse : MonoBehaviour
{
    Animator _coinController;

    void Awake() {
        _coinController = GetComponent<Animator>();
    }

    void Start() {
        GameManager.Instance.OnCoinCollected += GameManager_OnCoinCollected;
    }

    private void GameManager_OnCoinCollected(int coin)
    {
       _coinController.SetTrigger("PickedUp");
    }
}
