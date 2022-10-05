using System;
using UnityEngine;

public class BallMove : MonoBehaviour
{
   private GameOver _gameOver = null;
   //public GameObject GameOverMenu;
   private Rigidbody2D _rigidbody2D;
   private bool _isActive;
   private const float Force = 800f;
   private float _lastPositionX;

   private void Start()
   {
      _rigidbody2D = GetComponent<Rigidbody2D>();
      _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
      _gameOver = FindObjectOfType<GameOver>();
   }

   private void Update()
   {
#if UNITY_EDITOR
      if (Input.GetKeyDown(KeyCode.Space) && !_isActive)
      {
         BallActivate();
      }

      if (transform.position.y < -9f)
      {
         Destroy(gameObject);
         //Debug.Log("Ball dead");
         //GameOverMenu.SetActive(true);
         _gameOver.OpenGameOverMenu();
      }

#endif
#if UNITY_ANDROID
      if(Input.touchCount > 0 && !_isActive)
      {
         Touch touch = Input.GetTouch(0);
         if(touch.tapCount > 1)
         {
            BallActivate();
         }
      }
#endif
   }

   private void BallActivate()
   {
      _lastPositionX = transform.position.x;
      _isActive = true;
      transform.SetParent(null);
      _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
      _rigidbody2D.AddForce(Vector2.up * Force);
   }

   public void MoveCollision(Collision2D collision)
   {
      float ballPositionX = transform.position.x;

      if (collision.gameObject.TryGetComponent(out PlayerMove player))
      {
         if(ballPositionX < _lastPositionX + 0.1 && ballPositionX > _lastPositionX - 0.1) //movement almost vertically
         {
            float collisionPointX = collision.contacts[0].point.x; //touch point
            _rigidbody2D.velocity = Vector2.zero;
            float playerCenterPosition = player.gameObject.GetComponent<Transform>().position.x;
            float difference = playerCenterPosition - collisionPointX; //difference between centre of paddle and touch place
            float direction = collisionPointX < playerCenterPosition ? -1 : 1; //direction calculation
            _rigidbody2D.AddForce(new Vector2(direction * Mathf.Abs(difference * (Force / 2)), Force));
            
         }
         
      }

      _lastPositionX = ballPositionX;

   }
}
