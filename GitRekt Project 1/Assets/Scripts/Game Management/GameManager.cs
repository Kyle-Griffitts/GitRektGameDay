using UnityEngine;
using Scripts.Data;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public CharacterData CurrentCharacter;
    public string SelectedKingdom;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}