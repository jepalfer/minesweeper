using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class tileLogic : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _flaggedSprite;
    [SerializeField] private Sprite _emptySprite;
    [SerializeField] private Sprite _bombSprite;
    [SerializeField] private TextMeshProUGUI _numberOfBombs;
    private cellEnum _typeOfTile;
    private bool _isFlagged;
    private int _row;
    private int _column;
    private int _bombsSurround;
    private bool _isRevealed;

    private void Start()
    {
        _isFlagged = false;
        _isRevealed = false;
        _bombsSurround = 0;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        List<List<GameObject>> grid = globalVariables.getTileGrid();
        if (eventData.button == PointerEventData.InputButton.Left && !(_isFlagged || _isRevealed))
        {
            if (_typeOfTile != cellEnum.BOMB)
            {
                GetComponent<Button>().interactable = false;
                setSprite(_emptySprite);
                /*
                if (_row == 0 && _column == 0)      //Esquina arriba izquierda
                {
                    setBombsSurroundTile(7);
                }
                else if (_row == 0 && (_column > 0 && _column < globalVariables.getNumOfRows() - 1))        //Fila de arriba
                {
                    setBombsSurroundTile(8);
                }
                else if (_row == 0 && _column == globalVariables.getNumOfRows() - 1)        //Esquina arriba derecha
                {
                    setBombsSurroundTile(9);
                }
                else if ((_row > 0 && _row < globalVariables.getNumOfRows() - 1) && _column == 0)   //Columna de la izquierda
                {
                    setBombsSurroundTile(4);
                }
                else if ((_row > 0 && _row < globalVariables.getNumOfRows() - 1) && (_column > 0 && _column < globalVariables.getNumOfRows() - 1))  //Medio del mapa
                {
                    setBombsSurroundTile(5);
                }
                else if ((_row > 0 && _row < globalVariables.getNumOfRows() - 1) && _column == globalVariables.getNumOfRows() - 1)  //Columna de la derecha
                {
                    setBombsSurroundTile(6);
                }
                else if (_row == globalVariables.getNumOfRows() - 1 && _column == 0)    //Esquina abajo izquierda
                {
                    setBombsSurroundTile(3);
                }
                else if (_row == globalVariables.getNumOfRows() - 1 && (_column > 0 && _column < globalVariables.getNumOfRows() - 1))       //Fila de abajo
                {
                    setBombsSurroundTile(2);
                }
                else if (_row == globalVariables.getNumOfRows() - 1 && _column == globalVariables.getNumOfRows() - 1)       //Esquina abajo derecha
                {
                    setBombsSurroundTile(1);
                }*/
                revealAroundTile(gameObject);
            }
            else
            {
                GameOver();
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right && !_isRevealed)
        {
            _isFlagged = !_isFlagged;

            if (_isFlagged)
            {
                setSprite(_flaggedSprite);
                Debug.Log(globalVariables.getController().getFlags().text);
                int flags;
                int.TryParse(globalVariables.getController().getFlags().text, out flags);
                globalVariables.getController().getFlags().text = (--flags).ToString();

            }
            else
            {
                setSprite(_normalSprite);
                int flags;
                int.TryParse(globalVariables.getController().getFlags().text, out flags);
                globalVariables.getController().getFlags().text = (++flags).ToString();

            }
        }
    }

    public void setBombsSurroundTile(int type)
    {
        _bombsSurround = getBombsSurround(type);

        if (_bombsSurround != 0)
        {
            _numberOfBombs.text = _bombsSurround.ToString();
        }
    }

    public void calculateBombsAroundTile(GameObject tile)
    {
        if (tile.GetComponent<tileLogic>().getRow() == 0 && tile.GetComponent<tileLogic>().getColumn() == 0)      //Esquina arriba izquierda
        {
            tile.GetComponent<tileLogic>().setBombsSurroundTile(7);
        }
        else if (tile.GetComponent<tileLogic>().getRow() == 0 && (tile.GetComponent<tileLogic>().getColumn() > 0 && tile.GetComponent<tileLogic>().getColumn() < globalVariables.getNumOfRows() - 1))        //Fila de arriba
        {
            tile.GetComponent<tileLogic>().setBombsSurroundTile(8);
        }
        else if (tile.GetComponent<tileLogic>().getRow() == 0 && tile.GetComponent<tileLogic>().getColumn() == globalVariables.getNumOfRows() - 1)        //Esquina arriba derecha
        {
            tile.GetComponent<tileLogic>().setBombsSurroundTile(9);
        }
        else if ((tile.GetComponent<tileLogic>().getRow() > 0 && tile.GetComponent<tileLogic>().getRow() < globalVariables.getNumOfRows() - 1) && tile.GetComponent<tileLogic>().getColumn() == 0)   //Columna de la izquierda
        {
            tile.GetComponent<tileLogic>().setBombsSurroundTile(4);
        }
        else if ((tile.GetComponent<tileLogic>().getRow() > 0 && tile.GetComponent<tileLogic>().getRow() < globalVariables.getNumOfRows() - 1) && (tile.GetComponent<tileLogic>().getColumn() > 0 && tile.GetComponent<tileLogic>().getColumn() < globalVariables.getNumOfRows() - 1))  //Medio del mapa
        {
            tile.GetComponent<tileLogic>().setBombsSurroundTile(5);
        }
        else if ((tile.GetComponent<tileLogic>().getRow() > 0 && tile.GetComponent<tileLogic>().getRow() < globalVariables.getNumOfRows() - 1) && tile.GetComponent<tileLogic>().getColumn() == globalVariables.getNumOfRows() - 1)  //Columna de la derecha
        {
            tile.GetComponent<tileLogic>().setBombsSurroundTile(6);
        }
        else if (tile.GetComponent<tileLogic>().getRow() == globalVariables.getNumOfRows() - 1 && tile.GetComponent<tileLogic>().getColumn() == 0)    //Esquina abajo izquierda
        {
            tile.GetComponent<tileLogic>().setBombsSurroundTile(3);
        }
        else if (tile.GetComponent<tileLogic>().getRow() == globalVariables.getNumOfRows() - 1 && (tile.GetComponent<tileLogic>().getColumn() > 0 && tile.GetComponent<tileLogic>().getColumn() < globalVariables.getNumOfRows() - 1))       //Fila de abajo
        {
            tile.GetComponent<tileLogic>().setBombsSurroundTile(2);
        }
        else if (tile.GetComponent<tileLogic>().getRow() == globalVariables.getNumOfRows() - 1 && tile.GetComponent<tileLogic>().getColumn() == globalVariables.getNumOfRows() - 1)       //Esquina abajo derecha
        {
            tile.GetComponent<tileLogic>().setBombsSurroundTile(1);
        }
    }

    public void revealAroundTile(GameObject tile)
    {
        if (!tile.GetComponent<tileLogic>().getIsRevealed())
        {
            if (tile.GetComponent<tileLogic>().getTypeOfTile() != cellEnum.BOMB)
            {
                tile.GetComponent<Button>().interactable = false;
                calculateBombsAroundTile(tile);
                tile.GetComponent<tileLogic>().setIsRevealed(true);
                tile.GetComponent<tileLogic>().setSprite(_emptySprite);
                if (tile.GetComponent<tileLogic>().getBombsSurroundTile() == 0)
                {
                    if (tile.GetComponent<tileLogic>().getRow() - 1 > 0)
                    {
                        revealAroundTile(globalVariables.getTileGrid()[tile.GetComponent<tileLogic>().getRow() - 1][tile.GetComponent<tileLogic>().getColumn()]);
                    }
                    if (tile.GetComponent<tileLogic>().getRow() + 1 < globalVariables.getNumOfRows())
                    {
                        revealAroundTile(globalVariables.getTileGrid()[tile.GetComponent<tileLogic>().getRow() + 1][tile.GetComponent<tileLogic>().getColumn()]);
                    }
                    if (tile.GetComponent<tileLogic>().getColumn() - 1 > 0)
                    {
                        revealAroundTile(globalVariables.getTileGrid()[tile.GetComponent<tileLogic>().getRow()][tile.GetComponent<tileLogic>().getColumn() - 1]);
                    }
                    if (tile.GetComponent<tileLogic>().getColumn() + 1 < globalVariables.getNumOfRows())
                    {
                        revealAroundTile(globalVariables.getTileGrid()[tile.GetComponent<tileLogic>().getRow()][tile.GetComponent<tileLogic>().getColumn() + 1]);
                    }
                }
            }
        }
    }

    public int getBombsSurroundTile()
    {
        return _bombsSurround;
    }

    public int getBombsSurround(int tileType)
    {
        int numOfBombs = 0;
        if (tileType == 5)      //Medio
        {
            for (int row = -1; row <= 1; row++)
            {
                for (int column = -1; column <= 1; column++)
                {
                    if (row != 0 && column != 0)
                    {
                        if (globalVariables.getTileGrid()[_row + row][_column + column].GetComponent<tileLogic>().getTypeOfTile() == cellEnum.BOMB)
                        {
                            numOfBombs += 1;
                        }
                    }
                }
            }
        }
        else
        {
            switch (tileType)
            {
                case 1:     //Esquina aI
                    for (int row = 0; row >= -1; row--)
                    {
                        for (int column = 0; column <= 1; column++)
                        {
                            if (row != 0 && column != 0)
                            {
                                if (globalVariables.getTileGrid()[_row + row][_column + column].GetComponent<tileLogic>().getTypeOfTile() == cellEnum.BOMB)
                                {
                                    numOfBombs += 1;
                                }
                            }
                        }
                    }
                    break;
                case 2:     //Fila a
                    for (int row = 0; row >= -1; row--)
                    {
                        for (int column = -1; column <= 1; column++)
                        {
                            if (row != 0 && column != 0)
                            {
                                if (globalVariables.getTileGrid()[_row + row][_column + column].GetComponent<tileLogic>().getTypeOfTile() == cellEnum.BOMB)
                                {
                                    numOfBombs += 1;
                                }
                            }
                        }
                    }
                    break;
                case 3:     //Esquina aD
                    for (int row = 0; row >= -1; row--)
                    {
                        for (int column = -1; column <= 0; column++)
                        {
                            if (row != 0 && column != 0)
                            {
                                if (globalVariables.getTileGrid()[_row + row][_column + column].GetComponent<tileLogic>().getTypeOfTile() == cellEnum.BOMB)
                                {
                                    numOfBombs += 1;
                                }
                            }
                        }
                    }
                    break;
                case 4:     //Columna I
                    for (int row = 1; row >= -1; row--)
                    {
                        for (int column = 0; column <= 1; column++)
                        {
                            if (row != 0 && column != 0)
                            {
                                if (globalVariables.getTileGrid()[_row + row][_column + column].GetComponent<tileLogic>().getTypeOfTile() == cellEnum.BOMB)
                                {
                                    numOfBombs += 1;
                                }
                            }
                        }
                    }
                    break;
                case 6:     //Columna D
                    for (int row = 1; row >= -1; row--)
                    {
                        for (int column = 0; column >= -1; column--)
                        {
                            if (row != 0 && column != 0)
                            {
                                if (globalVariables.getTileGrid()[_row + row][_column + column].GetComponent<tileLogic>().getTypeOfTile() == cellEnum.BOMB)
                                {
                                    numOfBombs += 1;
                                }
                            }
                        }
                    }
                    break;
                case 7:     //Esquina AI
                    for (int row = 0; row <= 1; row++)
                    {
                        for (int column = 0; column <= 1; column++)
                        {
                            if (row != 0 && column != 0)
                            {
                                if (globalVariables.getTileGrid()[_row + row][_column + column].GetComponent<tileLogic>().getTypeOfTile() == cellEnum.BOMB)
                                {
                                    numOfBombs += 1;
                                }
                            }
                        }
                    }
                    break;
                case 8:     //Fila A
                    for (int row = 0; row <= 1; row++)
                    {
                        for (int column = -1; column <= 1; column++)
                        {
                            if (row != 0 && column != 0)
                            {
                                if (globalVariables.getTileGrid()[_row + row][_column + column].GetComponent<tileLogic>().getTypeOfTile() == cellEnum.BOMB)
                                {
                                    numOfBombs += 1;
                                }
                            }
                        }
                    }
                    break;
                case 9:     //Esquina AD
                    for (int row = 0; row <= 1; row++)
                    {
                        for (int column = -1; column <= 0; column++)
                        {
                            if (row != 0 && column != 0)
                            {
                                if (globalVariables.getTileGrid()[_row + row][_column + column].GetComponent<tileLogic>().getTypeOfTile() == cellEnum.BOMB)
                                {
                                    numOfBombs += 1;
                                }
                            }
                        }
                    }
                    break;
            }
        }
        return numOfBombs;
          
    }

    public void setSprite(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite; 
    }

    public void setType(cellEnum type)
    {
        _typeOfTile = type;
    }

    public void setRow(int row)
    {
        _row = row;
    }
    public void setColumn(int column)
    {
        _column = column;
    }

    public void setIsRevealed(bool value)
    {
        _isRevealed = value;
    }

    public bool getIsRevealed()
    {
        return _isRevealed;
    }

    public int getRow()
    {
        return _row;
    }
    public int getColumn()
    {
        return _column;
    }
    public cellEnum getTypeOfTile()
    {
        return _typeOfTile;
    }

    public void GameOver()
    {
        Debug.Log("perdiste jiji");
    }
}
