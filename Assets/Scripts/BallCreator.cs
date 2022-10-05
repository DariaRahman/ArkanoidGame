using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefub;
    private const float OffsetY = 0.7f;
    private void Start()
    {
        Create();
    }

    private void Create()
    {
        Instantiate(ballPrefub, new Vector3(transform.position.x, transform.position.y + OffsetY), Quaternion.identity,
            transform);
    }
}

