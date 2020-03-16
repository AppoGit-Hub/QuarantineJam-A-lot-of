using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Menu")]
    public DeathMenu DeathMenu;

    public enum MenuType
    {
        None,
        DeathMenu
    }

    private MenuType _UserIsInMenu = MenuType.None;
    public MenuType UserIsInMenu
    {
        get
        {
            return _UserIsInMenu;
        }
    }

    public void SwitchToMenu(MenuType m)
    {
        DisableAllMenu();

        switch (m)
        {
            case MenuType.None:
                break;
            case MenuType.DeathMenu:
                DeathMenu.SetActive(true);
                break;

        }
    }
    public void DisableAllMenu()
    {
        DeathMenu.SetActive(false);
    }
}
