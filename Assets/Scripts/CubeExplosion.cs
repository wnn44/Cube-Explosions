using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    public float shakeIntensity = 0.1f; // Интенсивность дрожания
    public float scaleFactor = 2.0f; // Коэффициент увеличения размера
    public float explosionForce = 10.0f; // Сила взрыва
    public float durationBeforeExplosion = 2.0f; // Время до взрыва
    public GameObject smallCubePrefab; // Префаб маленького кубика

    private Vector3 originalScale;
    private Vector3 originalPosition;
    private float timer = 0f;
    private bool isExploding = false;

    public void DestroyMy(Cube cube)
    {
        originalScale = cube.transform.localScale;
        originalPosition = cube.transform.position;

        while (timer < durationBeforeExplosion)
        {
            if (!isExploding)
            {
                timer += Time.deltaTime;

                // Плавное увеличение размера
                float scale = Mathf.Lerp(1.0f, scaleFactor, timer / durationBeforeExplosion);
                cube.transform.localScale = originalScale * scale;

                // Дрожание
                Vector3 shake = new Vector3(
                    Random.Range(-shakeIntensity, shakeIntensity),
                    Random.Range(-shakeIntensity, shakeIntensity),
                    Random.Range(-shakeIntensity, shakeIntensity)
                );
                cube.transform.position = originalPosition + shake;
            }

            if (timer >= durationBeforeExplosion)
            {
                isExploding = true;
                Explode();
            }

            // Уничтожаем основной кубик
            Destroy(cube.gameObject);
        }
    }

    void Explode()
    {
        // Создаем маленькие кубики
        for (int i = 0; i < 50; i++)
        {
            GameObject smallCube = Instantiate(smallCubePrefab, transform.position, Random.rotation);
            Rigidbody cube = smallCube.GetComponent<Rigidbody>();
            if (cube != null)
            {
                cube.AddExplosionForce(explosionForce, transform.position, 5.0f);
            }
        }

    }
}

