using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    // Ссылка на игрока и объект зомби
    public Transform ThePlayer;
    public GameObject TheEnemy;

    // Скорость передвижения и скорость поворота зомби
    public float EnemySpeed = 4.0f;
    public float rotationSpeed = 4.0f;

    // Ссылка на скрипт ZombieDeath, определяющий жизнь зомби
    private ZombieDeath zombieDeath;

    // Флаг, указывающий на смерть зомби
    public bool isDead = false;

    // Дистанция атаки зомби
    public float attackRange = 1f;

    // Флаг, указывающий на текущую атаку зомби
    private bool isAttacking = false;

    // Ссылка на скрипт GlobalHealth, управляющий здоровьем игрока
    private GlobalHealth globalHealth;

    // Время задержки между атаками
    public float attackCooldown = 2.5f;

    // Время последней атаки
    private float lastAttackTime;

    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource hurtSound3;
    public AudioSource AmbMusic;
    public AudioSource JumpScareMusic;
    public int hurtGen;
    public GameObject theFlash;

    private bool isPlayingSound = false;


    // Инициализация переменных при старте
    private void Start()
    {
        // Получаем компонент ZombieDeath из объекта зомби
        zombieDeath = TheEnemy.GetComponent<ZombieDeath>();

        // Находим объект GlobalHealth в сцене
        globalHealth = GameObject.FindObjectOfType<GlobalHealth>();
    }

    // Обновление каждый кадр
    private void Update()
    {
        // Проверяем, жив ли зомби
        if (!isDead)
        {
            // Проверяем, жив ли зомби
            if (zombieDeath.EnemyHealth > 0)
            {
                // Проверяем, прошло ли достаточно времени с последней атаки
                if (Time.time - lastAttackTime > attackCooldown)
                {
                    // Проверяем, не атакует ли зомби уже
                    CheckAttack();
                    
                    // Если зомби не атакует, двигаем его к игроку
                    if (!isAttacking)
                    {
                        MoveTowardsPlayer();
                    }
                }
            }
            else
            {
                // Если зомби мертв, вызываем метод смерти
                Die();
            }
        }
    }

    // Метод перемещения зомби к игроку
    private void MoveTowardsPlayer()
    {
        // Вычисляем расстояние до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, ThePlayer.position);

        // Проверяем, находится ли игрок в пределах атаки
        if (distanceToPlayer > attackRange)
        {
            // Вычисляем направление к игроку и поворачиваем зомби
            Vector3 direction = (ThePlayer.position - transform.position).normalized;
            direction.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            // Перемещаем зомби в направлении игрока
            transform.Translate(Vector3.forward * EnemySpeed * Time.deltaTime);

            // Воспроизводим анимацию бега
            TheEnemy.GetComponent<Animation>().Play("Run");
        }
    }

    // Корутина атаки зомби
    private IEnumerator AttackCoroutine()
    {
        // Останавливаем анимацию бега и запускаем анимацию атаки
        TheEnemy.GetComponent<Animation>().Stop("Run");
        TheEnemy.GetComponent<Animation>().Play("Attack1");
        
        // Устанавливаем флаг, что зомби начал атаку
        isAttacking = true;

        // Ждем 0.5 секунды перед воспроизведением звука удара
        yield return new WaitForSeconds(0.5f);

        // Проверяем, не воспроизводится ли уже другой звук
        if (!isPlayingSound)
        {
            // Устанавливаем флаг воспроизведения звука
            isPlayingSound = true;

            // Уменьшаем здоровье игрока на 5 единиц
            globalHealth.CurrentHealth -= 5;
            hurtGen = Random.Range(1,4);
            if (hurtGen == 1)
            {
                hurtSound1.Play();
            }
            else if (hurtGen == 2)
            {
                hurtSound2.Play();
            }
            else if (hurtGen == 3)
            {
                hurtSound3.Play();
            }
            theFlash.SetActive(true);
            yield return new WaitForSeconds (0.1f);
            theFlash.SetActive(false);        

            // Сбрасываем флаг атаки и запоминаем время последней атаки
            isAttacking = false;
            lastAttackTime = Time.time;
            attackCooldown = 1.0f;
            // Ждем 3 секунды
            yield return new WaitForSeconds(3f);

            // Сбрасываем флаг воспроизведения звука
            isPlayingSound = false;
        }
    }

    // Метод проверки атаки
    private void CheckAttack()
    {
        // Вычисляем расстояние до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, ThePlayer.position);
        
        // Если игрок в пределах атаки, запускаем атаку
        if (distanceToPlayer <= attackRange)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    // Метод смерти зомби
    private void Die()
    {
        // Останавливаем анимацию бега, запускаем анимацию смерти
        TheEnemy.GetComponent<Animation>().Stop("Run");
        TheEnemy.GetComponent<Animation>().Play("Death");
        
        // Отключаем физику зомби и его коллайдер
        TheEnemy.GetComponent<Rigidbody>().isKinematic = true;
        TheEnemy.GetComponent<BoxCollider>().enabled = false;
        JumpScareMusic.Stop();
        AmbMusic.Play();
        // Устанавливаем флаг смерти
        isDead = true;
    }
}
