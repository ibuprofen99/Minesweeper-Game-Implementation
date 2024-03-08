using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Minesweeper minesweeper;

    public void StartGameEasy()
    {
        minesweeper.CreateBoard(6, 6);
        GameObject canvasGameObject = GameObject.Find("Canvas");
        canvasGameObject.GetComponent<Canvas>().enabled = false;

    }

    public void StartGameMedium()
    {
        minesweeper.CreateBoard(9, 9);
        GameObject canvasGameObject = GameObject.Find("Canvas");
        canvasGameObject.GetComponent<Canvas>().enabled = false;

    }

    public void StartGameHard()
    {
        minesweeper.CreateBoard(15, 15);
        GameObject canvasGameObject = GameObject.Find("Canvas");
        canvasGameObject.GetComponent<Canvas>().enabled = false;

    }
}
