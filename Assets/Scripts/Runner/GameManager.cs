using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Renderer background;
    public GameObject column;
    public GameObject smallRock;
    public GameObject bigRock;
    public GameObject startMenu;
    public GameObject gameOverMenu;
    public List<GameObject> columns;
    public List<GameObject> obstacles;
    public bool gameOver = false;
    public bool gameStart = false;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Crear mapa
        for (int i = 0; i < 21; i++)
        {
            columns.Add(Instantiate(column, new Vector2(-10 + i, -3), Quaternion.identity));
        }

        //Crear obstaculos
        obstacles.Add(Instantiate(smallRock, new Vector2(14, -2), Quaternion.identity));
        obstacles.Add(Instantiate(bigRock, new Vector2(18, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart && !gameOver)
        {
            startMenu.SetActive(false);
            background.material.mainTextureOffset += new Vector2(0.02f, 0) * Time.deltaTime;
            //Mover mapa
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].transform.position.x <= -10)
                {
                    columns[i].transform.position = new Vector3(10, -3, 0);
                }

                columns[i].transform.position =
                    columns[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }

            //Mover obstaculos
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i].transform.position.x <= -10)
                {
                    float randomObst = Random.Range(10, 18);
                    obstacles[i].transform.position = new Vector3(randomObst, -2, 0);
                }

                obstacles[i].transform.position =
                    obstacles[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
        }
        else if (!gameStart)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                gameStart = true;
            }
        }
        else if (gameStart && gameOver)
        {
            gameOverMenu.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene("InitialMenuScene", LoadSceneMode.Single);
            }
        }
    }
}