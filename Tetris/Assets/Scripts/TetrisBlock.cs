using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.8f; //Time before tetromino move down

    public static int height = 23;
    public static int width = 10;

    public Vector3 rotationPoint;

    [Header("Audio Clips")]
    public AudioClip moveSound;
    public AudioClip rotateSound;
    public AudioClip landSound;
    public AudioClip clearLineSound;

    private static Transform[,] grid = new Transform[width, height]; // It will store the block according to the position of the grid
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {

        if((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.A))) //Check left arrow key and A key input
        {
            transform.position += new Vector3(-1, 0, 0); //Shift to left
            
            if (!ValidMove()) //Check if is valid position after every move
            {
                transform.position -= new Vector3(-1, 0, 0);             
            }
            else
            {
                audioSource.PlayOneShot(moveSound);
            }
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.D))) //Check right arrow key and D key input
        {
            transform.position += new Vector3(1, 0, 0); //Shift to right           

            if (!ValidMove()) //Check if is valid position after every move
            {
                transform.position -= new Vector3(1, 0, 0);
            }else
            {
                audioSource.PlayOneShot(moveSound);
            }
        }
        else if((Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.W)))
        {
            //rotate
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            audioSource.PlayOneShot(rotateSound);
            if (!ValidMove()) 
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }



        //If we are pressing the down arrow key or S key, we return fallTime value divided by 10 otherwise we return directly  fallTime
        if(Time.time - previousTime > ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                audioSource.PlayOneShot(moveSound);
            }

            if (!ValidMove()) //Check if valid position after every move
            {
                transform.position -= new Vector3(0, -1, 0);

                AddToGrid();
                CheckForLines();

                if (CheckIsAboveGrid() == true)
                {
                    FindObjectOfType<GameManager>().GameOver();
                }

                this.enabled = false;
                FindObjectOfType<Spawner>().NewTetromino();               
            }

            previousTime = Time.time;
        }

    }

    void CheckForLines()
    {
        for (int i = height-1; i >= 0; i--)
        {
            if(HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for(int j=0;j<width;j++)
        {
            if (grid[j, i] == null)
                return false;
        }
        FindObjectOfType<Score>().numberOfRowsThisTurn++; //Since we found a full row, we increment the full row variable
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
            audioSource.PlayOneShot(clearLineSound);
        }
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if(grid[j,y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
    //It will loop all children and add their transform to the corresponding index on the grid
    void AddToGrid()
    {
        foreach (Transform children in transform) //Browse all childrens
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    bool ValidMove()
   //it will check for every square of the tetromino if the position of the square is inside of the grid
    {
        foreach(Transform children in transform) //Browse all childrens
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x); 
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >=height-1)
            {
                return false;
            }
            if(grid[roundedX, roundedY] != null) // checking if the position of the child is already taken by another square
            {
                return false;
            }
           
        }
        return true;
    }

    public bool CheckIsAboveGrid()
    {
        for (int x = 0; x < width; x++)
        {
            foreach(Transform children in transform)
            {
                int roundedY = Mathf.RoundToInt(children.transform.position.y);
                
                if( roundedY >= 21)
                {
                    return true;
                }
            }
        }
        return false;
    }
   
  
}
