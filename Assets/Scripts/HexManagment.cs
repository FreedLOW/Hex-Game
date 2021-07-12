using System.Collections;
using UnityEngine;

public class HexManagment : MonoBehaviour
{
    Transform player;

    HexController hexController;

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerController>().transform;  //нахожу игрока

        hexController = GetComponentInParent<HexController>();

        //print(hexController.hex[hexController.RandomHex].name);

        StartCoroutine(GetIncome());
    }

    private void OnMouseDown()
    {
        player.position = transform.position + new Vector3(0.15f, 0.1f);  //при нажатии на гекс перемещаю игрока в указуную позицию
    }

    IEnumerator GetIncome()  //каждую минуту игрок получает прибыль
    {
        yield return new WaitForSecondsRealtime(60f);

        GameController.Instance.playerMoney += hexController.hex[hexController.RandomHex].Income;

        StartCoroutine(GetIncome());
    }
}