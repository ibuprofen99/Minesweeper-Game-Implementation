using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;

public class CellData : MonoBehaviour
{
    public bool IsBomb;     // is current cell a bomb
    public int cellValue;          // represent adjacent number of neighboring bombs

    public bool selected;   // has it been selected?
    bool flag;              // has it been flagged?

    public Transform bombRef;
    public Transform pressedButton;
    public Transform cellBase;

    public string CellId => $"[{row},{col}]";

    public int row;
    public int col;

    public TMP_Text tmpCellValue;

    // Start is called before the first frame update
    void Start()
    {
        //bombRef.gameObject.SetActive(false);
        //tmpCellValue.transform.gameObject.SetActive(false);
        //tmpCellValue.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static CellData CreateCellWithBomb(GameObject go, int i, int j)
    {
        CellData cellData = go.AddComponent<CellData>();
        cellData.row = i;
        cellData.col = j;



        return cellData;
    }
}
