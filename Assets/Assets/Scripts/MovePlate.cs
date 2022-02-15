using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
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
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);
            if (cp.name == "white_king") controller.GetComponent<Game>().Winner("Black");
            if (cp.name == "black_king") controller.GetComponent<Game>().Winner("White");

            Destroy(cp);
        }

        controller.GetComponent<Game>().
            SetPositionEmpty(refrence.GetComponent<Chessman>().GetXBoard(),
                             refrence.GetComponent<Chessman>().GetYBoard());

        refrence.GetComponent<Chessman>().SetXBoard(matrixX);
        refrence.GetComponent<Chessman>().SetYBoard(matrixY);
        refrence.GetComponent<Chessman>().SetCoords();

        controller.GetComponent<Game>().SetPosition(refrence);

        controller.GetComponent<Game>().NextTurn();

        refrence.GetComponent<Chessman>().DestroyMovePlates();
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
