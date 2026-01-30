using UnityEngine;
using UnityEngine.UI;

public class EndlessPixelGrid : MonoBehaviour
{
    public Image[] gridPixels;
    public Image[] inputPixels;

    private bool[,] grid = new bool[10, 7];
    private bool[] inputLine = new bool[7];

    void Start() => RenderAll();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) ToggleInput(6);
        if (Input.GetKeyDown(KeyCode.A)) ToggleInput(5);
        if (Input.GetKeyDown(KeyCode.UpArrow)) ToggleInput(4);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ToggleInput(3);
        if (Input.GetKeyDown(KeyCode.DownArrow)) ToggleInput(2);
        if (Input.GetKeyDown(KeyCode.RightArrow)) ToggleInput(1);
        if (Input.GetKeyDown(KeyCode.S)) ToggleInput(0);

        if (Input.GetKeyDown(KeyCode.D))
            CommitInputLine();

        if (Input.GetKeyDown(KeyCode.G))
            ResetAll();

        void ResetAll()
        {
            for (int r = 0; r < 10; r++)
                for (int c = 0; c < 7; c++)
                    grid[r, c] = false;

            for (int i = 0; i < 7; i++)
                inputLine[i] = false;

            RenderAll();
        }

    }

    void CommitInputLine()
    {
        for (int r = 0; r < 9; r++)
            for (int c = 0; c < 7; c++)
                grid[r, c] = grid[r + 1, c];

        for (int c = 0; c < 7; c++)
            grid[9, c] = inputLine[c];

        for (int i = 0; i < 7; i++)
            inputLine[i] = false;

        RenderAll();
    }


    void ToggleInput(int index)
    {
        inputLine[index] = !inputLine[index];
        RenderInputLine();
    }

    void RenderAll() { RenderGrid(); RenderInputLine(); }

    void RenderGrid()
    {
        for (int r = 0; r < 10; r++)
            for (int c = 0; c < 7; c++)
                gridPixels[r * 7 + c].color = grid[r, c] ? Color.white : Color.black;
    }

    void RenderInputLine()
    {
        for (int i = 0; i < 7; i++)
            inputPixels[i].color = inputLine[i] ? Color.white : Color.black;
    }
}
