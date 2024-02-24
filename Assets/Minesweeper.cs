using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Minesweeper : MonoBehaviour
{
    public GameObject cellPrefab;
    public int width = 9;
    public int height = 9;
    public Material cellMaterial;

    RaycastHit tmpHitHighlight;

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
                // Attach CellData script to the cell GameObject
                CellData cellData = go.AddComponent<CellData>();
                cellData.row = i;
                cellData.col = j;

                CellData.CreateCellWithBomb(go, i, j);

            }
        }
        GameObject specificCell = GameObject.Find("[5,3]"); // Replace with the name of the cell you want to change
        specificCell.GetComponent<Renderer>().material.color = Color.red;

        GameObject bomb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bomb.GetComponent<Renderer>().material.color = Color.black;

        bomb.transform.position = specificCell.transform.position;



    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out tmpHitHighlight, 100))
            {
                Debug.Log($"We have a hit ");
            }

        }
    }
}

