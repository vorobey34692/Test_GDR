using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinNumber;
    [SerializeField] private GameObject _loseText;
    [SerializeField] private GameObject _winText;
    [SerializeField] private GameObject _reloadButton;

    private void Start()
    {
        EventManager.GameOver += LosePlay;
        EventManager.AddCoin += UpdateCoin;
    }

    private void UpdateCoin(int numbers)
    {
        _coinNumber.text = numbers.ToString();
    }

    private void LosePlay(bool win)
    {
        if (!win)
            _loseText.SetActive(true);
        else if (win)
            _winText.SetActive(true);

        _coinNumber.gameObject.SetActive(false);
        _reloadButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReloadGame()
    {
        _winText.SetActive(false);
        _loseText.SetActive(false);
        Time.timeScale = 1;
        EventManager.GameOver -= LosePlay;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
