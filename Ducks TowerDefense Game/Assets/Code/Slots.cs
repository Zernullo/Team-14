using UnityEngine;
using System.Collections;
using UnityEngine.UT;

public class Slots : MonoBehaviour
 {
    public Image[] slotImages; // UI images representing slot reels
    public Sprite[] symbols; // Slot symbols
    public Button spinButton;
    private bool isSpinning = false;
    private float spinSpeed = 0.1f;

    void Start() // starts the game lol
    {
        spinButton.onClick.AddListener(StartSpinning);
    }

    public void StartSpinning() // makes the slots go brrr
    {
        if (!isSpinning)
        {
            isSpinning = true;
            StartCoroutine(SpinReel());
        }
    }

    IEnumerator SpinReel() //spins for a random duration
    {
        float spinDuration = Random.Range(2f, 4f);
        float elapsed = 0f;

        while (elapsed < spinDuration)
        {
            for (int i = 0; i < slotImages.Length; i++)
            {
                slotImages[i].sprite = symbols[Random.Range(0, symbols.Length)];
            }
            elapsed += spinSpeed;
            yield return new WaitForSeconds(spinSpeed);
        }

        isSpinning = false;
        CheckWinCondition();
    }

    private void CheckWinCondition() // if all the images are the same then win
    {
        if (slotImages[0].sprite == slotImages[1].sprite && slotImages[1].sprite == slotImages[2].sprite)
        {
            Debug.Log("Jackpot! You win!");
            // Add reward logic here
        }
    }
}


