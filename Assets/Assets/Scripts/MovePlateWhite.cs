using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlateWhite : MonoBehaviour
{
    public GameObject controller;

    GameObject refrence = null;

    //Board position, not world positions
    int matrixX;
    int matrixY;

    //false movement, true: Attacking
    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
            //Change to Red
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack)
        {
            GameObject cp = controller.GetComponent<GameWhite>().GetPosition(matrixX, matrixY);

            Destroy(cp);
        }

        controller.GetComponent<GameWhite>().
            SetPositionEmpty(refrence.GetComponent<ChessmanWhite>().GetXBoard(),
                             refrence.GetComponent<ChessmanWhite>().GetYBoard());

        refrence.GetComponent<ChessmanWhite>().SetXBoard(matrixX);
        refrence.GetComponent<ChessmanWhite>().SetYBoard(matrixY);
        refrence.GetComponent<ChessmanWhite>().SetCoords();

        controller.GetComponent<GameWhite>().SetPosition(refrence);

        refrence.GetComponent<ChessmanWhite>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        refrence = obj; 
    }

    public GameObject GetReference()
    {
        return refrence;
    }
}
