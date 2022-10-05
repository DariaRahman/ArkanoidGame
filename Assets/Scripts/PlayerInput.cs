
using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   public static event Action<float> OnMove;
   
   private Vector2 _startPosition = Vector2.zero; //against which we check the presence of movement
   private float _direction = 0f; //direction of movement
   
   

   private void Update()
   {
#if UNITY_EDITOR
      OnMove?.Invoke(Input.GetAxisRaw("Horizontal")); //call an action
      
#endif
#if UNITY_ANDROID
       GetTouchInput();
#endif
   }

   private void GetTouchInput()
   {
       if (Input.touchCount > 0)
       { 
           Touch touch = Input.GetTouch(0);

           switch(touch.phase)
           {
               case TouchPhase.Began:
                   _startPosition = touch.position;
                   _direction = 0f;
                   break;
               case TouchPhase.Moved:
                   _direction = touch.position.x > _startPosition.x ? 1f : -1f;
                   break;
               case TouchPhase.Stationary:
                   break;
               case TouchPhase.Canceled:
                   break;
               default:
                   _startPosition = touch.position;
                   _direction = 0f;
                    break;
           }
           OnMove?. Invoke(_direction);
       }
   }
}
