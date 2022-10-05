using UnityEngine;

public class BlockCount : MonoBehaviour
{
    private GameWin _gameWin;
    public GameObject[] Blocks;

    private void Update()
    {   
        //foreach (GameObject i in Blocks)
        for (int i = 0; i <= Blocks.Length - 1; i++)
        {
            if (Blocks.Length == 0)
            {      
                Debug.Log("hello");
                _gameWin.OpenGameWinMenu();
            }
        }
        
    }
}
