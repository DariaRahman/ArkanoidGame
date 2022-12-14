using System;
using System.Collections.Generic;
using UnityEngine;
public class Block : MonoBehaviour
{
   private static int _count = 0;
   [SerializeField] private List<Sprite> _sprites;
   [SerializeField] private int _score;
   [SerializeField] private SpriteRenderer _spriteRenderer;
   [SerializeField] private int _life;

#if UNITY_EDITOR
   public BlockData BlockData;
#endif
   public void SetData(ColoredBlock blockData)
   {
      _sprites = new List<Sprite>(blockData.Sprites);
      _score = blockData.Score;
      _spriteRenderer = GetComponent<SpriteRenderer>();
      _life = _sprites.Count;
      _spriteRenderer.sprite = _sprites[_life - 1];
      ParticleSystem.MainModule main = GetComponent<ParticleSystem>().main;
      main.startColor = _spriteRenderer.color = blockData.BaseColor;
   }

   public void ApplyDamage()
   {
      _life--;
      if (_life < 1)
      {
         _spriteRenderer.enabled = false;
         GetComponent<BoxCollider2D>().enabled = false;
         GetComponent<ParticleSystem>().Play();
      }
      else
      {
         _spriteRenderer.sprite = _sprites[_life - 1];
      }
   }
   
   
   private void OnEnable()
   {
      _count++;
   }

   private void OnDisable()
   {
      _count--;
      if (_count < 1)
      {
         Debug.Log("block ended");
      }
      
   }
}
