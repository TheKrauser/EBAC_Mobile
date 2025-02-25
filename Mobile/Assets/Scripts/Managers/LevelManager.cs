using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Transform container;

    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    private int index;
    private GameObject currentLevel;

    private void Start()
    {
        SpawnNextLevel();
    }

    private void SpawnNextLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
            index++;

            if (index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }

        if (container.TryGetComponent<ScaleHelper>(out ScaleHelper scale))
        {
            scale.Scale();
        }

        currentLevel = Instantiate(levels[index], container);
        //currentLevel.transform.position = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        index = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnNextLevel();
        }
    }

    public Theme GetCurrentLevelTheme()
    {
        return levels[index].GetComponent<ThemeManager>().levelTheme;
    }
}
