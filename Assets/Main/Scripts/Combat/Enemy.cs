using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : MonoBehaviour
{
    private CharacterCombat playerCombat;
    [SerializeField] private CharacterStats myStats;

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        playerCombat = player.GetComponent<CharacterCombat>();
    }

    public void Interact()
    {

        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }

}
