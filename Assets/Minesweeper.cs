using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minesweeper : MonoBehaviour
{
    public GameObject cellPrefab;
    public int width = 9;
    public int height = 9;
    public Material cellMaterial;

    void Start()
    {


        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.position = new Vector3(i, 0, j);
                go.transform.localScale = new Vector3(1, 0.1f, 1);
                go.transform.name = $"[{i},{j}]";

                go.transform.GetComponent<Renderer>().material = cellMaterial;
                // Instantiate a new cell at the correct position
               // GameObject cell = Instantiate(cellPrefab, new Vector3(x, y, 0), Quaternion.identity);
               // cell.transform.parent = this.transform; // Set the cell's parent to the game board
            }
        }
        GameObject specificCell = GameObject.Find("[1,1]"); // Replace with the name of the cell you want to change
        specificCell.GetComponent<Renderer>().material.color = Color.red;
    }
}
