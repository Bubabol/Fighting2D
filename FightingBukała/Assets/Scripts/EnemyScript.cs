using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour

{
    [SerializeField] private int MaxHP;
    
    [SerializeField] private HealthBar huj;
    private int CurrentHP;
   
    void Start ()
    {
        CurrentHP = MaxHP; 
        huj.SetMaxHealth(CurrentHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Death()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
        private void TakeDamage(int Kutas )
    {
        CurrentHP -= Kutas;
        huj.SetHealth(CurrentHP);
        if (CurrentHP < 0)
        {
            Death();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log (collision.tag);
        if (collision.tag == ("Atak"))
        {
            TakeDamage(10);
        }
    }
}
