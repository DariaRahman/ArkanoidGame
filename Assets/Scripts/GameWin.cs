using UnityEngine;

public class GameWin : MonoBehaviour
{
    [SerializeField] private GameObject _gameWin;

    public void OpenGameWinMenu()
    {
        _gameWin.SetActive(true);
    }
}
