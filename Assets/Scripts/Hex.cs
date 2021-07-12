using UnityEngine;

public class Hex
{
    public readonly int X;

    public readonly int Y;

    public readonly int S;

    public Hex(int x, int y)
    {
        this.X = x;
        this.Y = y;
        this.S = -(x + y);
    }

    static readonly float Width_Multiplier = Mathf.Sqrt(3) / 2;

    public Vector3 Position()  //возвращает позицию в мировых координатах гекса
    {
        return new Vector3(HorizontalSpacing() * (this.X + this.Y / 2f), VerticalSpacing() * this.Y, 0);
        //return new Vector3(horizontalSpace * (this.X + this.Y / 2f), verticalSpace * this.Y, 0);
    }

    float HexHeight()
    {
        return 1f;
    }

    float HexWidth()
    {
        return Width_Multiplier * HexHeight();
    }

    float HorizontalSpacing()
    {
        return HexWidth();
    }

    float VerticalSpacing()
    {
        return HexHeight() * .65f;
    }

    public Vector3 PositionFromCamera(Vector3 cameraPosition, float numberRows, float numberColums)  //возвращает позицию гекста от камеры
    {
        float mapHeight = numberRows * VerticalSpacing();
        float mapWidth = numberColums * HorizontalSpacing();

        Vector3 position = Position();

        float widthFromCamera = (position.x - cameraPosition.x) / mapWidth;

        if (Mathf.Abs(widthFromCamera) <= 0.5f)
        {
            return position;
        }

        if (widthFromCamera > 0)
            widthFromCamera += .5f;
        else widthFromCamera -= .5f;

        int widthToFix = (int)widthFromCamera;

        position.x -= widthToFix * mapWidth;

        return position;
    }
}