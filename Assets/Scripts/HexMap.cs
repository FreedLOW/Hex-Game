using UnityEngine;

public class HexMap : MonoBehaviour
{
    [SerializeField] GameObject hexPrefab;

    [SerializeField] int numberRows = 15;
    [SerializeField] int numberColums = 30;

    [SerializeField] int startPosX, startPosY = 0;

    private void Awake()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for (int x = startPosX; x < numberColums; x++)
        {
            for (int y = startPosY; y < numberRows; y++)
            {
                Hex hex = new Hex(x, y);

                //Instantiate(hexPrefab[x], new Vector3(x, y), Quaternion.identity, transform);
                var newHex = Instantiate(hexPrefab, hex.PositionFromCamera(Camera.main.transform.position, numberRows, numberColums), Quaternion.identity, transform);
            }
        }

        StaticBatchingUtility.Combine(this.gameObject);  //делаю объект статическим для увелечения производительности
    }
}