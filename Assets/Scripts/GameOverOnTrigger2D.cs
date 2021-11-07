using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameOverOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;
    [SerializeField] int health;
    [SerializeField] int num0fHearts;
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] Animator animator;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            Destroy(other.gameObject);
            health--;
            if (health == 0)
            {
                StartCoroutine("Quit");
            }
        }
    }

    private void Update() {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health > num0fHearts)
            {
                health = num0fHearts;
            }

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
                {
                hearts[i].sprite = emptyHeart;
                 }
            if (i < num0fHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            
        }
        
        animator.SetFloat("Health", health);

    }
    IEnumerator Quit()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
        //EditorUtility.DisplayDialog("GameOver", "I Bet You Can Do Better!", "Try Again!");
        //UnityEditor.EditorApplication.isPlaying = false;
        

    }

}
