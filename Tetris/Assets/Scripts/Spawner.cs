using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Tetrominoes;
    public GameManager gameManager;

    private GameObject previewTetromino;
    private GameObject nextTetromino;

    private bool gameStarted = false;

    public GameObject previewTetrominoPosition;

    private void Start()
    {
        NewTetromino();
    }

    public void NewTetromino()
    {
        if (gameStarted == false)
        {
            gameStarted = true;
            nextTetromino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], transform.position, Quaternion.identity);
            previewTetromino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], previewTetrominoPosition.transform.position, Quaternion.identity);
            previewTetromino.GetComponent<TetrisBlock>().enabled = false;
        }

        else if (gameManager.isEnd==false && gameStarted== true)
        {
            previewTetromino.transform.localPosition = transform.position;
            nextTetromino = previewTetromino;
            nextTetromino.GetComponent<TetrisBlock>().enabled = true;

            previewTetromino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], previewTetrominoPosition.transform.position, Quaternion.identity);
            previewTetromino.GetComponent<TetrisBlock>().enabled = false;
        }
    }
}
