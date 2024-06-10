using UnityEngine;

public class Consumable : MonoBehaviour
{
    private IConsumableBehaviour consumableBehaviour;
    private void Awake()
    {
        consumableBehaviour = GetComponent<IConsumableBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<CharacterController>();

        if(player != null)
        {
            consumableBehaviour.OnConsumed(player.gameObject);
            SfxManager.Instance.PlayEatSound();
            Destroy(gameObject);
        }
    }
}
