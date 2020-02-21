using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    public bool gamePaused;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
       // _enemy = Instantiate(enemyPrefab) as GameObject;
      //  _enemy.transform.position = new Vector3(0, 1, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("`") && gamePaused == false)
        {
            gamePaused = true;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown("`") && gamePaused)
        {
            gamePaused = false;
            Cursor.visible = false;
        }
    }
}
