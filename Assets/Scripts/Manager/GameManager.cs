using System.Collections;
using TMPro;
using UnityEngine;

namespace OneHourJam
{
    public class GameManager : MonoBehaviour
    {
        private Camera _cam;

        [SerializeField]
        private GameObject _mathPrefab;

        [SerializeField]
        private TMP_Text _numberText;

        private int _myNumber;

        private void Awake()
        {
            _cam = Camera.main;

            StartCoroutine(SpawnMath());
        }

        private IEnumerator SpawnMath()
        {
            var bounds = CalculateBounds(_cam);
            while (true)
            {
                yield return new WaitForSeconds(.5f);

                var y = Random.Range(bounds.min.y, bounds.max.y);

                var pos = new Vector2(bounds.min.x - 2f, y);
                Instantiate(_mathPrefab, pos, Quaternion.identity);
            }
        }

        private void UpdateUI()
        {
            _numberText.text = $"Your number: {_myNumber}";
        }

        // http://answers.unity.com/answers/502236/view.html
        public static Bounds CalculateBounds(Camera cam)
        {
            float screenAspect = Screen.width / (float)Screen.height;
            float cameraHeight = cam.orthographicSize * 2;
            Bounds bounds = new(
                cam.transform.position,
                new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
            return bounds;
        }
    }
}
