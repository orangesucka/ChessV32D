using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlateBlack : MonoBehaviour
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
            GameObject cp = controller.GetComponent<GameBlack>().GetPosition(matrixX, matrixY);

            Destroy(cp);
        }

        controller.GetComponent<GameBlack>().
            SetPositionEmpty(refrence.GetComponent<ChessmanBlack>().GetXBoard(),
                             refrence.GetComponent<ChessmanBlack>().GetYBoard());

        refrence.GetComponent<ChessmanBlack>().SetXBoard(matrixX);
        refrence.GetComponent<ChessmanBlack>().SetYBoard(matrixY);
        refrence.GetComponent<ChessmanBlack>().SetCoords();

        controller.GetComponent<GameBlack>().SetPosition(refrence);

        refrence.GetComponent<ChessmanBlack>().DestroyMovePlates();
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

