using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Beat : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private PostProcessVolume beatPP;

    private float nextBeatTime;
    private float beatLength = 0.5f;

    private void Start()
    {
        nextBeatTime = Time.time + beatLength;
    }

    private void FixedUpdate()
    {
        if (Time.fixedTime >= nextBeatTime)
        {
            audioSource.Play();
            beatPP.weight = 1;
            nextBeatTime += beatLength;
        }
        else
        {
            beatPP.weight -= 0.02f;
        }
    }
}
