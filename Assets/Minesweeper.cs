using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;


public class Minesweeper : MonoBehaviour
{
    public GameObject cellPrefab;
    public int width = 9;
    public int height = 9;
    public Material cellMaterial;

    //[SerializeField] private TextMeshPro myText;
    RaycastHit tmpHitHighlight;
    public TextMeshPro textMeshPro;
    void Start()
    {


        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
               var go = GameObject.CreatePrimitive(PrimitiveType.Cube); // Assign the created GameObject to go
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

                //Assigns bombs
                //CellData.CreateCellWithBomb(go, i, j);
                // instansiate the bombs
                if (Random.Range(1, 8) > 5)
                {
                    cellData.IsBomb = true;
                    
                }

            }
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {   
                // store a refrence of data type CellData in cellData variable, the refrence is to the CellData component which allows us to access its members
                // find current cell, retrieve its CellData component and assign it to cellData
                CellData cellData = GameObject.Find($"[{i},{j}]").GetComponent<CellData>();

                if (!cellData.IsBomb)
                {
                    int bombCount = 0;
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            if (x == 0 && y == 0)
                            {
                                continue; // Skip the current cell
                            }

                            int checkX = i + x;
                            int checkY = j + y;

                            // Check if the adjacent cell is within bounds
                            if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
                            {
                                CellData curCell = GameObject.Find($"[{checkX},{checkY}]").GetComponent<CellData>(); // Get the CellData component of the adjacent cell

                                if (curCell.IsBomb)
                                {
                                    bombCount++;
                                }
                            }
                        }
                    }
                    

                    cellData.cellValue = bombCount;
                    // TextMeshPro textt = cellData.GetComponentInChildren<TextMeshPro>();
                    // textt.text = bombCount.ToString();

                    Debug.Log($"{i},{j} {cellData.cellValue}");
                }

            }
        }



        //GameObject specificCell = GameObject.Find("[5,3]"); // Replace with the name of the cell you want to change
        // specificCell.GetComponent<Renderer>().material.color = Color.red;
        //GameObject bomb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // bomb.GetComponent<Renderer>().material.color = Color.black;

        //bomb.transform.position = specificCell.transform.position;


    }


    void Update()
    {
        // instanstiates a ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // if left mouse if clicked
        if (Input.GetMouseButtonDown(0))
        {   // if ray hits an object

            if (Physics.Raycast(ray, out tmpHitHighlight, 100))
            {
                CellData cellData = tmpHitHighlight.collider.gameObject.GetComponent<CellData>();

                if (cellData.IsBomb)
                {
                   // Debug.Log($"We have a bomb: [{cellData.col} , {cellData.row}] ");

                    // Optionally, change the color of the cell to indicate a bomb
                    cellData.GetComponent<Renderer>().material.color = Color.red;

                    GameObject bomba = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    bomba.GetComponent<Renderer>().material.color = Color.black;
                    bomba.transform.position = cellData.transform.position;
                }

                if (cellData != null && cellData.IsBomb ==false)
                {

                    if (cellData.cellValue == 0)
                    {
                        Texture2D texture = Resources.Load<Texture2D>("Number-zero");

                        if (texture != null)
                        {
                            cellData.GetComponent<Renderer>().material.EnableKeyword("_METALLICGLOSSMAP");
                            cellData.GetComponent<Renderer>().material.SetTexture("_MetallicGlossMap", texture);
                        }
                        else
                        {
                            Debug.LogError("Failed to load texture");
                        }
                    }

                    if (cellData.cellValue == 1)
                    {
                        Texture2D texture = Resources.Load<Texture2D>("Number-one");

                        if (texture != null)
                        {
                            cellData.GetComponent<Renderer>().material.EnableKeyword("_METALLICGLOSSMAP");
                            cellData.GetComponent<Renderer>().material.SetTexture("_MetallicGlossMap", texture);
                        }
                        else
                        {
                            Debug.LogError("Failed to load texture");
                        }

                    }
                    if (cellData.cellValue == 2)
                    {
                        Texture2D texture = Resources.Load<Texture2D>("Number-two");

                        if (texture != null)
                        {
                            cellData.GetComponent<Renderer>().material.EnableKeyword("_METALLICGLOSSMAP");
                            cellData.GetComponent<Renderer>().material.SetTexture("_MetallicGlossMap", texture);
                        }
                        else
                        {
                            Debug.LogError("Failed to load texture");
                        }

                    }
                    if (cellData.cellValue == 3)
                    {
                        Texture2D texture = Resources.Load<Texture2D>("Number-three");

                        if (texture != null)
                        {
                            cellData.GetComponent<Renderer>().material.EnableKeyword("_METALLICGLOSSMAP");
                            cellData.GetComponent<Renderer>().material.SetTexture("_MetallicGlossMap", texture);
                        }
                        else
                        {
                            Debug.LogError("Failed to load texture");
                        }

                    }
                    if (cellData.cellValue == 4)
                    {
                        Texture2D texture = Resources.Load<Texture2D>("Number-four");

                        if (texture != null)
                        {
                            cellData.GetComponent<Renderer>().material.EnableKeyword("_METALLICGLOSSMAP");
                            cellData.GetComponent<Renderer>().material.SetTexture("_MetallicGlossMap", texture);
                        }
                        else
                        {
                            Debug.LogError("Failed to load texture");
                        }

                    }
                    if (cellData.cellValue == 5)
                    {
                        Texture2D texture = Resources.Load<Texture2D>("Number-five");

                        if (texture != null)
                        {
                            cellData.GetComponent<Renderer>().material.EnableKeyword("_METALLICGLOSSMAP");
                            cellData.GetComponent<Renderer>().material.SetTexture("_MetallicGlossMap", texture);
                        }
                        else
                        {
                            Debug.LogError("Failed to load texture");
                        }

                    }
                    if (cellData.cellValue == 6)
                    {
                        Texture2D texture = Resources.Load<Texture2D>("Number-six");

                        if (texture != null)
                        {
                            cellData.GetComponent<Renderer>().material.EnableKeyword("_METALLICGLOSSMAP");
                            cellData.GetComponent<Renderer>().material.SetTexture("_MetallicGlossMap", texture);
                        }
                        else
                        {
                            Debug.LogError("Failed to load texture");
                        }

                    }
                    if (cellData.cellValue == 7)
                    {
                        Texture2D texture = Resources.Load<Texture2D>("Number-seven");

                        if (texture != null)
                        {
                            cellData.GetComponent<Renderer>().material.EnableKeyword("_METALLICGLOSSMAP");
                            cellData.GetComponent<Renderer>().material.SetTexture("_MetallicGlossMap", texture);
                        }
                        else
                        {
                            Debug.LogError("Failed to load texture");
                        }

                    }
                    if (cellData.cellValue == 8)
                    {
                        Texture2D texture = Resources.Load<Texture2D>("Number-eight");

                        if (texture != null)
                        {
                            cellData.GetComponent<Renderer>().material.EnableKeyword("_METALLICGLOSSMAP");
                            cellData.GetComponent<Renderer>().material.SetTexture("_MetallicGlossMap", texture);
                        }
                        else
                        {
                            Debug.LogError("Failed to load texture");
                        }

                    }
                    // textMeshPro.text = "test"; 

                    // Create a new child GameObject for the text
                    /*GameObject textObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    textObject.transform.parent = cellData.transform;
                    textObject.transform.localPosition = Vector3.zero;
                    


                    // Add the TextMeshPro component to the textObject
                    TextMeshPro textMeshPro = textObject.AddComponent<TextMeshPro>();
                    textMeshPro.text = cellData.cellValue.ToString();
                    textObject.transform.position = new Vector3(0f, 0f, 0f);
                    textObject.transform.rotation = Quaternion.Euler(78.023735f, 152.712906f, 242.715057f);
                    textObject.transform.localScale = new Vector3(0.200000003f, 0.200000003f, 1f);*/
                }
                // Debug.Log($"We have a hit: [{cellData.IsBomb}] ");
            }

        }
    }

}

