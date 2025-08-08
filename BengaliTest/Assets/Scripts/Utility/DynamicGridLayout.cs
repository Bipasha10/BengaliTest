using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class DynamicGridLayout : MonoBehaviour
{
    public int rows = 2;
    public int columns = 2;

    private RectTransform rectTransform;
    private GridLayoutGroup gridLayout;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gridLayout = GetComponent<GridLayoutGroup>();
    }

    void OnEnable()
    {
        rows = Constants.gridRow;
        columns = Constants.gridCol;
        ApplyGrid();
    }

    public void ApplyGrid()
    {
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        float cellWidth = (width - gridLayout.spacing.x * (columns - 1) - gridLayout.padding.left - gridLayout.padding.right) / columns;
        float cellHeight = (height - gridLayout.spacing.y * (rows - 1) - gridLayout.padding.top - gridLayout.padding.bottom) / rows;

        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = columns;
        gridLayout.cellSize = new Vector2(cellWidth, cellHeight);
    }

    public void SetLayout(int newRows, int newCols)
    {
        rows = newRows;
        columns = newCols;
        ApplyGrid();
    }
}
