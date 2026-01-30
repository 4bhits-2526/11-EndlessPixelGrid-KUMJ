using UnityEngine;
using UnityEngine.UI;

public class EndlessPixelGrid : MonoBehaviour
{
    [Header("UI References")]
    public Image[] gridPixels;      // 70 Images (10x7)
    public Image[] inputPixels;     // 7 Images

    // ===== DATENMODELL =====
    private bool[,] grid = new bool[10, 7];   // Raster
    private bool[] inputLine = new bool[7];   // Eingabezeile

    void Start()
    {
        RenderAll();
    }

    void RenderAll()
    {
        RenderGrid();
        RenderInputLine();
    }

    void RenderGrid()
    {
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                int index = row * 7 + col;
                gridPixels[index].color = grid[row, col] ? Color.white : Color.black;
            }
        }
    }

    void RenderInputLine()
    {
        for (int i = 0; i < 7; i++)
        {
            inputPixels[i].color = inputLine[i] ? Color.white : Color.black;
        }
    }
}
