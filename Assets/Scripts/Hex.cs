using System.Collections;
using System.Collections.Generic;
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
        float radius = 1f;
        float height = radius;
        float width =  Width_Multiplier * height;

        float horizontalSpace = width;
        float verticalSpace = height * .65f;

        return new Vector3(horizontalSpace * (this.X + this.Y / 2f), verticalSpace * this.Y, 0);
        //return new Vector3(horizontalSpace * (this.X + this.Y / 2f), verticalSpace * this.Y, 0);
    }
}