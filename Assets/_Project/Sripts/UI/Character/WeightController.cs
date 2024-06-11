using UnityEngine;
using UnityEngine.UI;

public class WeightController : MonoBehaviour
{
    public Slider weight_bar;
    public GameObject playerModel;
    public PlayerController player;

    private float MaxWeghit;
    private float CurWeghit;
    private float playerScale;
    private float MaxSpeed;
    private float CurSpeed;

    private float LowScale;
    private float MaxScale;
    private void Start()
    {
        MaxWeghit = 100.0f;
        CurWeghit = 50.0f;
        MaxSpeed = 20.0f;
        CurSpeed = player.initialSpeed;
        LowScale = 0.01f;
        MaxScale = 0.08f;
    }

    private void Update()
    {
        loseWeghit();
        weight_bar.value = GetPercentage();
        PlayerBuff();
        if(CurWeghit < 0.0f)
        {
            Time.timeScale = 0f;
        }
        if (CurWeghit >= MaxWeghit)
        {
            Time.timeScale = 0f;
        }
    }

    public void Consume(float loseWeight)
    {
        CurWeghit -= loseWeight;
    }
    public void JunkConsume(float GainWeight)
    {
        CurWeghit += GainWeight;
    }
    public void loseWeghit()
    {
        CurWeghit -= Time.deltaTime*0.2f;
    }
    public void PlayerBuff()
    {
        playerScale = Mathf.Clamp(weight_bar.value * 0.05f, LowScale, MaxScale);
        playerModel.transform.localScale = new Vector3(playerScale, 0.025f, 0.025f);

        switch (weight_bar.value)
        {
            case float n when (n >= 0.1f && n < 0.3f):
                player.initialSpeed -= Time.deltaTime * 0.3f;
                break;
            case float n when (n >= 0.3f && n < 0.45f):
                player.initialSpeed += Time.deltaTime * 0.1f;
                player.initialSpeed = Mathf.Clamp(player.initialSpeed, CurSpeed-2, MaxSpeed-2);
                break;
            case float n when (n >= 0.45f && n < 0.6f):
                player.initialSpeed += Time.deltaTime * 0.2f;
                player.initialSpeed = Mathf.Clamp(player.initialSpeed, CurSpeed, MaxSpeed);
                break;
            case float n when (n >= 0.6f && n < 0.7f):
                player.initialSpeed += Time.deltaTime * 0.1f;
                player.initialSpeed = Mathf.Clamp(player.initialSpeed, CurSpeed - 2, MaxSpeed - 2);
                break;
            case float n when (n >= 0.7f && n < 0.8f):
                player.initialSpeed -= Time.deltaTime * 0.1f;
                break;
            case float n when (n >= 0.8f && n < 1.0f):
                player.initialSpeed -= Time.deltaTime * 0.3f;
                break;
        }
    }
    public float GetPercentage()
    {
        return CurWeghit / MaxWeghit;
    }

}
