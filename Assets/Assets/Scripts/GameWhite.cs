using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWhite : MonoBehaviour
{
    public GameObject chessPiece;

    //Positions and team Chess Piece
    private GameObject[,] positions = new GameObject[8, 8];
    //private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    private string currentPlayer = "white";

    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerWhite = new GameObject[]
        {
           Create("WhiteRook",0,0),Create("WhiteKnight",1,0),Create("WhiteBishop",2,0),Create("WhiteQueen",3,0),
           Create("WhiteKing",4,0),Create("WhiteBishop",5,0),Create("WhiteKnight",6,0),Create("WhiteRook",7,0),
           Create("WhitePawn",0,1),Create("WhitePawn",1,1),Create("WhitePawn",2,1),Create("WhitePawn",3,1),
           Create("WhitePawn",4,1),Create("WhitePawn",5,1),Create("Whitepawn",6,1),Create("WhitePawn",7,1)
        };
/*
        playerBlack = new GameObject[]
        {
           Create("BlackRook",0,7),Create("BlackKnight",1,7),Create("BlackBishop",2,7),Create("BlackQueen",3,7),
           Create("BlackKing",4,7),Create("BlackBishop",5,7),Create("BlackKnight",6,7),Create("BlackRook",7,7),
           Create("BlackPawn",0,6),Create("BlackPawn",1,6),Create("BlackPawn",2,6),Create("BlackPawn",3,6),
           Create("BlackPawn",4,6),Create("BlackPawn",5,6),Create("BlackPawn",6,6),Create("BlackPawn",7,6)
        };
*/
        for (int i = 0; i < playerWhite.Length; i++)
        {
            //SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chessPiece, new Vector3(0, 0, -1), Quaternion.Euler(-135,0,0));
        ChessmanWhite cm = obj.GetComponent<ChessmanWhite>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        ChessmanWhite cm = obj.GetComponent<ChessmanWhite>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1))
            return false;
        return true;
    }
}
