using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
    public Transform flag;
    public Transform poleBottom;
    public Transform castle;
    public float speed = 6f;
    public int nextWorld = 1;
    public int nextStage = 1;

    private AudioManager audioManager;

    private void Start()
    {
        // Find the AudioManager in the scene
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {

            StartCoroutine(MoveTo(flag, poleBottom.position));
            StartCoroutine(LevelCompleteSequence(player));
        }
    }

    private IEnumerator LevelCompleteSequence(Player player)
    {
        player.movement.enabled = false;

        if (audioManager != null)
        {
            audioManager.PlayFlagpoleSlideMusic();
        }

        yield return MoveTo(player.transform, poleBottom.position);
        yield return MoveTo(player.transform, player.transform.position + Vector3.right);
        yield return MoveTo(player.transform, player.transform.position + Vector3.right + Vector3.down);
        yield return MoveTo(player.transform, castle.position);

        if (audioManager != null)
        {
            audioManager.PlayGameEndMusic();
        }

        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        GameManager.Instance.LoadLevel(nextWorld, nextStage);


    }

    private IEnumerator MoveTo(Transform subject, Vector3 position)
    {
        while (Vector3.Distance(subject.position, position) > 0.125f)
        {
            subject.position = Vector3.MoveTowards(subject.position, position, speed * Time.deltaTime);
            yield return null;
        }

        subject.position = position;
    }
}
