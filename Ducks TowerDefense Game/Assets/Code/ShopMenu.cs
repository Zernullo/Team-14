using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public RectTransform shopPanel;    // Reference to the Shop Panel
    public Button startButton;         // Reference to the Start Button
    private float shopPanelWidth;      // Store the width of the shop panel

    private void Start(){
        // Store the width of the shop panel
        shopPanelWidth = shopPanel.rect.width;

        // Hide the shop panel at the start
        shopPanel.anchoredPosition = new Vector2((272*2), 0);
    }

    // Called when the Shop button is clicked
    public void OpenShop(){
        Debug.Log("OpenShop called" + shopPanelWidth);
        // Show the shop panel by moving it into view
        shopPanel.anchoredPosition = new Vector2(292, 0);
        // Disable the Start Button
        startButton.gameObject.SetActive(false);
    }

    // Called when the Close button is clicked
    public void CloseShop(){
        Debug.Log("CloseShop called");
        // Hide the shop panel by moving it off-screen
        shopPanel.anchoredPosition = new Vector2((272*2), 0);
        // Enable the Start Button
        startButton.gameObject.SetActive(true);
    }
}