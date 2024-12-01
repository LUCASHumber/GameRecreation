using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public CapsuleCollider2D capsuleCollider { get; private set; }
    public  PlayerMovement movement { get; private set; }
    //public DeathAnimation deathAnimation { get; private set; }

    public PlayerSpriteAnimation smallAnimation;
    public PlayerSpriteAnimation bigAnimation;
    private PlayerSpriteAnimation activeAnimation;

    public bool big => bigAnimation.enabled;
    //public bool dead => deathAnimation.enabled;
    public bool starpower { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        movement = GetComponent<PlayerMovement>();
        //deathAnimation = GetComponent<DeathAnimation>();
        activeAnimation = GetComponent<PlayerSpriteAnimation>();
    }

    public void Hit() 
    {
        //if (!dead && !starpower) {
        //    if (big)
        //    {
        //        Shrink();
        //    }
        //    else {
        //        Death();
        //    }
        //}
    }

    public void Death()
    { 
        smallAnimation.enabled = false;
        bigAnimation.enabled = false;
        //deathAnimation.enabled = false;

        //GameManager.Instance.ResetLevel(3f);
    }

    public void Grow() 
    {
        smallAnimation.enabled = false;
        bigAnimation.enabled = true;
        activeAnimation = bigAnimation;

        capsuleCollider.size = new Vector2(1f, 2f);
        capsuleCollider.offset = new Vector2(0f, 0.5f);

        StartCoroutine(ScaleAnimation());
    }

    public void Shrink()
    {
        smallAnimation.enabled = true;
        bigAnimation.enabled = false;
        activeAnimation = smallAnimation;

        capsuleCollider.size = new Vector2(1f, 1f);
        capsuleCollider.offset = new Vector2(0f, 0f);

        StartCoroutine(ScaleAnimation());
    }

    private IEnumerator ScaleAnimation()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if (Time.frameCount % 4 == 0)
            {
                smallAnimation.enabled = !smallAnimation.enabled;
                bigAnimation.enabled = !smallAnimation.enabled;
            }

            yield return null;
        }

        smallAnimation.enabled = false;
        bigAnimation.enabled = false;
        activeAnimation.enabled = true;
    }

    public void Starpower()
    {
        StartCoroutine(StarpowerAnimation());
    }

    private IEnumerator StarpowerAnimation()
    {
        starpower = true;

        float elapsed = 0f;
        float duration = 10f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if (Time.frameCount % 4 == 0)
            {
                activeAnimation.spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            }

            yield return null;
        }

        activeAnimation.spriteRenderer.color = Color.white;
        starpower = false;
    }

}
