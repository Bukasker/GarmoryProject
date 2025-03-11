using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIDocument inventoryDocument;
    [SerializeField] private UIDocument mainMenuDocument;
    [SerializeField] private UIDocument uiButtonsDocument;

    [SerializeField] private PlayerController playerController;

    private VisualElement inventoryRoot;
    private VisualElement mainMenuRoot;
    private VisualElement buttonsRoot;

    private Button inventoryButton;
    private Button inventoryExitButton;
    private Button mainMenuButton;
    private Button playMainMenuButton;
    private Button exitMainMenuButton;

    private void Awake()
    {
        if (inventoryDocument != null)
        {
            inventoryRoot = inventoryDocument.rootVisualElement;
            inventoryExitButton = inventoryRoot.Q<Button>("ExitButton");
        }

        if (mainMenuDocument != null)
        {
            mainMenuRoot = mainMenuDocument.rootVisualElement;

            playMainMenuButton = mainMenuRoot.Q<Button>("PlayButton");
            exitMainMenuButton = mainMenuRoot.Q<Button>("QuitButton");

            if (playMainMenuButton != null)
            {
                playMainMenuButton.clicked += HideMainMenu;
            }

            if (exitMainMenuButton != null)
            {
                exitMainMenuButton.clicked += ExitGame;
            }
        }

        if (uiButtonsDocument != null)
        {
            buttonsRoot = uiButtonsDocument.rootVisualElement;
            inventoryButton = buttonsRoot.Q<Button>("InventoryButton");
            mainMenuButton = buttonsRoot.Q<Button>("MainMenuButton");
        }

        if (inventoryButton != null)
            inventoryButton.clicked += ToggleInventory;

        if (mainMenuButton != null)
            mainMenuButton.clicked += ToggleMainMenu;

        if (inventoryExitButton != null)
            inventoryExitButton.clicked += HideInventory;


        HideInventory();
        ShowMainMenu();
    }

    public void ShowInventory()
    {
        if (inventoryRoot != null)
        {
            inventoryRoot.style.display = DisplayStyle.Flex;
            playerController.DisableControls();
        }
    }

    public void HideInventory()
    {
        if (inventoryRoot != null)
        {
            inventoryRoot.style.display = DisplayStyle.None;
            playerController.EnableControls();
        }
    }

    public void ShowMainMenu()
    {
        if (mainMenuRoot != null)
        {
            mainMenuRoot.style.display = DisplayStyle.Flex;
            playerController.DisableControls();
        }
    }

    public void HideMainMenu()
    {
        if (mainMenuRoot != null)
        {
            mainMenuRoot.style.display = DisplayStyle.None;
            playerController.EnableControls();
        }
    }
    private void ExitGame()
    {
        Application.Quit();
    }

    private void ToggleInventory()
    {
        if (inventoryRoot.style.display == DisplayStyle.Flex)
        {
            HideInventory();
        }
        else
        {
            HideMainMenu();
            ShowInventory();
        }
    }

    private void ToggleMainMenu()
    {
        if (mainMenuRoot.style.display == DisplayStyle.Flex)
        {
            HideMainMenu();
        }
        else
        {
            HideInventory();
            ShowMainMenu();
        }
    }
}