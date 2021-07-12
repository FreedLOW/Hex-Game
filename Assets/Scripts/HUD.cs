using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] Text money;

    private void Update()
    {
        money.text = GameController.Instance.playerMoney.ToString();
    }
}