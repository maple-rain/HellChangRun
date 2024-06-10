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
    private void Start()
    {
        MaxWeghit = 100f;
        CurWeghit = 50f;
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
    }

    public void loseWeghit()
    {
        CurWeghit -= Time.deltaTime*0.5f;
    }
    public void Consume(float loseWeight)
    {
        CurWeghit -= loseWeight;
    }
    public void JunkConsume(float GainWeight)
    {
        CurWeghit += GainWeight;
    }
    public void PlayerBuff()
    {
        playerScale = weight_bar.value * 0.05f;
        playerModel.transform.localScale = new Vector3(playerScale, 0.025f, 0.025f);
        //Debug.Log(weight_bar.value);
        //Debug.Log(player.initialSpeed);

        if (weight_bar.value > 0.5f)
        {
            player.initialSpeed -= Time.deltaTime * 0.3f;
        }
        if (weight_bar.value <= 0.5f)
        {
            player.initialSpeed += Time.deltaTime * 0.3f;
        }

    }
    public float GetPercentage()
    {
        return CurWeghit / MaxWeghit;
    }

}
