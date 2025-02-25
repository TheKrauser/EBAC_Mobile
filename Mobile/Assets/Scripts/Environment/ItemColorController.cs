using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ItemColorController : MonoBehaviour
{
    [SerializeField] private List<ItemColorTheme> colorThemes;

    private MeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        var currentTheme = LevelManager.Instance.GetCurrentLevelTheme();

        mesh.materials[0].SetColor("_Color", colorThemes.Find(x => x.theme == currentTheme).color);
    }
}

[System.Serializable]
public class ItemColorTheme
{
    public Theme theme;
    public Color color;
}
