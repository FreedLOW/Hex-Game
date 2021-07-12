using UnityEngine;
using UnityEngine.UI;

public class HexController : MonoBehaviour
{
    public HexObject[] hex;
    private int randomHex;

    [SerializeField] Sprite[] hexSprites;
    private SpriteRenderer hexSpriteRenderer;

    Transform player;

    [SerializeField] GameObject hexCanvas;
    [SerializeField] GameObject hexPrice;
    [SerializeField] GameObject hexObject;
    [SerializeField] Text priceHex;
    [SerializeField] Text getIncome;

    [SerializeField] LayerMask hexMask;

    float maxDistance = .5f;

    public int RandomHex { get => randomHex; private set => randomHex = value; }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;

        RandomHex = Random.Range(0, hex.Length);

        print("name hex " + hex[RandomHex].name + " hex ID: " + hex[RandomHex].Id);

        hexSpriteRenderer = hexObject.GetComponent<SpriteRenderer>();
        hexSpriteRenderer.sprite = hexSprites[Random.Range(0, hexSprites.Length)];  //рандомно меняю спрайт и гекса

        CheckPlayer();

        getIncome.text = hex[RandomHex].Income.ToString();
    }

    private void Update()
    {
        CheckOtherHex();
    }

    void CheckOtherHex() //поиск коллизий с другими гексами
    {
        bool hit = Physics2D.BoxCast(transform.position, transform.lossyScale, 0f, Vector2.one, maxDistance, hexMask);
        if (hit && hexCanvas != null)
        {
            hexCanvas.SetActive(true);
            priceHex.text = hex[RandomHex].Price.ToString();
        }
        else return;
    }

    void CheckPlayer()
    {
        BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
        var col = box.OverlapPoint(player.position);
        if (col)
        {
            hexObject.SetActive(true);
            Destroy(hexCanvas);
        }
    }

    public void ActivateHex()
    {
        if ((GameController.Instance.playerMoney - hex[RandomHex].Price) >= 0)  //если достаточно денег, то покупаю участок
        {
            GameController.Instance.playerMoney -= hex[RandomHex].Price;
            hexObject.SetActive(true);
            hexPrice.SetActive(false);
            getIncome.gameObject.SetActive(true);
        }
        else print("Not enough money!");
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