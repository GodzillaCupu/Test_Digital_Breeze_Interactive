using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private string winWording;
    [SerializeField] private string loseWording;

    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI targetText;


    public void WinPanel()
    {
        targetText = ChangeWording(winWording);
        panel = OpenPanel(true);
    }

    public void LosePanel()
    {
        targetText = ChangeWording(loseWording);
        panel = OpenPanel(true);
    }

    public TextMeshProUGUI ChangeWording(string wording)
    {
        targetText.text = wording;
        return targetText;
    }

    public GameObject OpenPanel(bool isOpen)
    {
        panel.SetActive(isOpen);
        InputHandler input = GameObject.FindAnyObjectByType<InputHandler>();
        input.DisableInput();
        return panel;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
