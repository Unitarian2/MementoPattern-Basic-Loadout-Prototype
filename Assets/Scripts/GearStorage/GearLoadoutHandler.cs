using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearLoadoutHandler : MonoBehaviour
{
    [SerializeField] private PlayerGear playerGear;
    [SerializeField] private Button[] loadoutButtons;

    readonly PlayerGear.Memento[] loadoutMementos = new PlayerGear.Memento[3];
    int selectedLoadout = 0;

    private void Start()
    {
        for (int i = 0; i < loadoutButtons.Length; i++)
        {
            loadoutMementos[i] = playerGear.CreateMemento();
            var index = i;
            loadoutButtons[i].onClick.AddListener(() => SelectLoadout(index));
        }
        ChangeButtonColor();
    }

    private void SelectLoadout(int index)
    {
        SaveLoadout();
        selectedLoadout = index;
        playerGear.SetMemento(loadoutMementos[index]);

        ChangeButtonColor();
    }

    void SaveLoadout()
    {
        loadoutMementos[selectedLoadout] = playerGear.CreateMemento();
    }

    void ChangeButtonColor()
    {
        for (int i = 0; i < loadoutButtons.Length; i++)
        {
            loadoutButtons[i].GetComponent<Image>().color = Color.black;
        }

        loadoutButtons[selectedLoadout].GetComponent<Image>().color = Color.white;
    }
}
