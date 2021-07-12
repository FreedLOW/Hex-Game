using UnityEngine;
using UnityEngine.UI;

public class HexController : MonoBehaviour
{
    public HexObject[] hex;
    private int randomHex;

    [SerializeField] Sprite[] hexSprites;
    private SpriteRenderer hexSpriteRenderer;

    [SerializeField] Transform player;

    [SerializeField] GameObject hexCanvas;
    [SerializeField] GameObject hexPrice;
    [SerializeField] GameObject hexObject;
    [SerializeField] Text priceHex;

    [SerializeField] LayerMask hexMask;

    float maxDistance = 1f;

    public int RandomHex { get => randomHex; private set => randomHex = value; }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;

        RandomHex = Random.Range(0, hex.Length);

        print("name hex " + hex[RandomHex].name + " hex ID: " + hex[RandomHex].Id);

        hexSpriteRenderer = hexObject.GetComponent<SpriteRenderer>();
        hexSpriteRenderer.sprite = hexSprites[Random.Range(0, hexSprites.Length)];  //рандомно меняю спрайт и гекса
    }

    private void Update()
    {
        CheckOtherHex();
    }

    void CheckOtherHex() //поиск коллизий с другими гексами
    {
        bool hit = Physics2D.BoxCast(transform.position, transform.lossyScale, 0f, Vector2.one, maxDistance, hexMask);
        if (hit)
        {
            hexCanvas.SetActive(true);
            priceHex.text = hex[RandomHex].Price.ToString();
        }
    }

    public void ActivateHex()
    {
        if ((GameController.Instance.playerMoney - hex[RandomHex].Price) >= 0)  //если достаточно денег, то покупаю участок
        {
            GameController.Instance.playerMoney -= hex[RandomHex].Price;
            hexObject.SetActive(true);
            hexPrice.SetActive(false);
        }
        else print("Not enough money bich!");
    }

    private void OnDrawGizmos()
    {
        bool hit = Physics2D.BoxCast(transform.position, transform.lossyScale, 0f, Vector2.one, maxDistance, hexMask);
        if (hit)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, transform.lossyScale);
        }
    }
}