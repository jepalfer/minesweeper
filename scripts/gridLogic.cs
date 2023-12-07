using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gridLogic : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _panel;
    private List<List<GameObject>> _tileGrid;

    private void Awake()
    {
        globalVariables.setRows(14);
        globalVariables.setGameDifficulty(difficultyLevel.HARD);

        globalVariables.setBombsQuantity(Mathf.RoundToInt((float)(0.2 * Mathf.Pow(globalVariables.getNumOfRows(), 2))));

        List<(int, int)> coordinates = new List<(int, int)>();
        List<(int, int)> coordinatesWithBomb = new List<(int, int)>();

        for (int row = 0; row < globalVariables.getNumOfRows(); ++row)
        {
            for (int column = 0; column < globalVariables.getNumOfRows(); ++column)
            {
                coordinates.Add((row, column));
            }
        }
        for (int i = 0; i < globalVariables.getNumberOfBombs(); ++i)
        {
            int index = Random.Range(0, coordinates.Count);
            coordinatesWithBomb.Add(coordinates[index]);
            coordinates.RemoveAt(index);
        }

        GetComponent<GridLayoutGroup>().constraintCount = globalVariables.getNumOfRows();
        Vector2 newSize = new Vector2(
            (GetComponent<RectTransform>().rect.height - (GetComponent<GridLayoutGroup>().padding.top + GetComponent<GridLayoutGroup>().padding.bottom + ((globalVariables.getNumOfRows() - 1) * GetComponent<GridLayoutGroup>().spacing.y))) / globalVariables.getNumOfRows(),
            (GetComponent<RectTransform>().rect.height - (GetComponent<GridLayoutGroup>().padding.top + GetComponent<GridLayoutGroup>().padding.bottom + ((globalVariables.getNumOfRows() - 1) * GetComponent<GridLayoutGroup>().spacing.y))) / globalVariables.getNumOfRows()
        );
        GetComponent<GridLayoutGroup>().cellSize = newSize;
        RectOffset newPadding = new RectOffset();
        float cellWidth = Mathf.RoundToInt(GetComponent<GridLayoutGroup>().cellSize.x);
        float spacing = Mathf.RoundToInt(GetComponent<GridLayoutGroup>().spacing.x);

        newPadding.left = (int)((GetComponent<RectTransform>().rect.width - (globalVariables.getNumOfRows() * cellWidth + (globalVariables.getNumOfRows() - 1) * spacing)) / 2);
        newPadding.right = (int)((GetComponent<RectTransform>().rect.width - (globalVariables.getNumOfRows() * cellWidth + (globalVariables.getNumOfRows() - 1) * spacing)) / 2);
        newPadding.top = 25; 
        newPadding.bottom = 25;
        GetComponent<GridLayoutGroup>().padding = newPadding;

        _tileGrid = new List<List<GameObject>>();

        for (int row = 0; row < globalVariables.getNumOfRows(); ++row)
        {
            List<GameObject> currentRow = new List<GameObject>();
            for (int column = 0; column < globalVariables.getNumOfRows(); ++column)
            {
                GameObject currentTile = Instantiate(_tilePrefab);
                currentTile.GetComponent<tileLogic>().setRow(row);
                currentTile.GetComponent<tileLogic>().setColumn(column);

                currentTile.GetComponent<tileLogic>().setType(cellEnum.EMPTY);
                if (coordinatesWithBomb.Contains((row, column)))
                {
                    currentTile.GetComponent<tileLogic>().setType(cellEnum.BOMB);
                }


                currentTile.transform.SetParent(_panel, false);
                currentRow.Add(currentTile);
            }
            _tileGrid.Add(currentRow);
        }
        globalVariables.setTileGrid(_tileGrid);
    }
    private void Start()
    {
        globalVariables.getController().getFlags().text = globalVariables.getNumberOfBombs().ToString();
    }

}
