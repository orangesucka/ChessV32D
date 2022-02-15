using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessmanWhite : MonoBehaviour
{
    //References
    public GameObject controller;
    public GameObject movePlate;

    //Positions
    private int xBoard = -1;
    private int yBoard = -1;

    //Variable to keep track of "Black" player or "White" player
    private string player;
    
    //References for all the 3D GameObjects that the chesspiece can be
    //Needs work
    //public GameObject BlackBishop, BlackKing, BlackKnight, BlackPawn, BlackQueen, BlackRook;
    public Mesh WhiteBishop, WhiteKing, WhiteKnight, WhitePawn, WhiteQueen, WhiteRook;
    
/*
    //References for all the sprites that the chesspiece can be
    public Sprite black_bishop, black_king, black_knight, black_pawn, black_queen, black_rook;
    public Sprite white_bishop, white_king, white_knight, white_pawn, white_queen, white_rook;
*/
    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        //take the instantiated location and adjust the transform
        SetCoords();

        switch (this.name)
        {
/*
            //case "BlackBishop": GetComponent<MeshFilter>().mesh = BlackBishop; break;
            case "BlackBishop": BlackBishop = GetComponent<GameObject>(); break;
            //case "BlackKing": GetComponent<MeshFilter>().mesh = BlackKing; break;
            case "BlackKing": BlackKing = GetComponent<GameObject>(); break;
            //case "BlackKnight": GetComponent<MeshFilter>().mesh = BlackKnight; break;
            case "BlackKnight": BlackKnight = GetComponent<GameObject>(); break;
            //case "BlackPawn": GetComponent<MeshFilter>().mesh = BlackPawn; break;
            case "BlackPawn": BlackPawn = GetComponent<GameObject>(); break;
            //case "BlackQueen": GetComponent<MeshFilter>().mesh = BlackQueen; break;
            case "BlackQueen": BlackQueen = GetComponent<GameObject>(); break;
            //case "BlackRook": GetComponent<MeshFilter>().mesh = BlackRook; break;
            case "BlackRook": BlackRook = GetComponent<GameObject>(); break;
*/
            case "WhiteBishop": GetComponent<MeshFilter>().mesh = WhiteBishop; player = "white"; break;
            //case "WhiteBishop": WhiteBishop = GetComponent<GameObject>(); break;
            case "WhiteKing": GetComponent<MeshFilter>().mesh = WhiteKing; player = "white"; break;
            //case "WhiteKing": WhiteKing = GetComponent<GameObject>(); break;
            case "WhiteKnight": GetComponent<MeshFilter>().mesh = WhiteKnight; player = "white"; break;
            //case "WhiteKnight": WhiteKnight = GetComponent<GameObject>(); break;
            case "WhitePawn": GetComponent<MeshFilter>().mesh = WhitePawn; player = "white"; break;
            //case "WhitePawn": WhitePawn = GetComponent<GameObject>(); break;
            case "WhiteQueen": GetComponent<MeshFilter>().mesh = WhiteQueen; player = "white"; break;
            //case "WhiteQueen": WhiteQueen = GetComponent<GameObject>(); break;
            case "WhiteRook": GetComponent<MeshFilter>().mesh = WhiteRook; player = "white"; break;
            //case "WhiteRook": WhiteRook = GetComponent<GameObject>(); break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    private void OnMouseUp()
    {
        DestroyMovePlates();

        InitiateMovePlates();
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates()
    {
        switch (this.name)
        {

            case "WhiteBishop":
            //case "BlackBishop":
                LineMovePlate(1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(-1, -1);
                break;

            case "WhiteKing":
            //case "BlackKing":
                SurroundMovePlate();
                break;

            case "WhiteKnight":
            //case "BlackKnight":
                LMovePlate();
                break;

            case "WhiteQueen":
            //case "BlackQueen":
                LineMovePlate(0, 1);
                LineMovePlate(0, -1);
                LineMovePlate(1, -1);
                LineMovePlate(1, 0);
                LineMovePlate(1, 1);
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 0);
                LineMovePlate(-1, 1);
                break;

            case "WhitePawn":
                PawnMovePlate(xBoard, yBoard + 1);
                break;
            case "BlackPawn":
                PawnMovePlate(xBoard, yBoard - 1);
                break;

            case "WhiteRook":
            //case "BlackRook":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                break;
        }
    }

    public void LineMovePlate(int xIncrement, int yIncrement)
    {
        GameWhite sc = controller.GetComponent<GameWhite>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while (sc.PositionOnBoard(x,y) && sc.GetPosition(x,y) == null)
        {
            MovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;
        }

        if(sc.PositionOnBoard(x,y) && sc.GetPosition(x, y).GetComponent<ChessmanWhite>().player != player)
        {
            MovePlateAttackSpawn(x, y);
        }
    }

    private void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard - 2, yBoard - 1);

    }

    private void SurroundMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 0);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 0);
        PointMovePlate(xBoard + 1, yBoard + 1);
    }
    private void PointMovePlate(int x, int y)
    {
        GameWhite sc = controller.GetComponent<GameWhite>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if(cp == null)
            {
                MovePlateSpawn(x, y);
            }
            else if(cp.GetComponent<ChessmanWhite>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    private void PawnMovePlate(int x, int y)
    {
        GameWhite sc = controller.GetComponent<GameWhite>();
        if (sc.PositionOnBoard(x, y))
        {
            if(sc.GetPosition(x,y) == null)
            {
                MovePlateSpawn(x, y);
            }

            if(sc.PositionOnBoard(x +1, y) && sc.GetPosition(x + 1, y) != null &&
                sc.GetPosition(x + 1, y).GetComponent<ChessmanWhite>().player != player)
            {
                MovePlateAttackSpawn(x + 1, y);
            }
            if (sc.PositionOnBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null &&
                sc.GetPosition(x - 1, y).GetComponent<ChessmanWhite>().player != player)
            {
                MovePlateAttackSpawn(x - 1, y);
            }
        }
    }

    private void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlateWhite mpScript = mp.GetComponent<MovePlateWhite>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    private void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlateWhite mpScript = mp.GetComponent<MovePlateWhite>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
}
