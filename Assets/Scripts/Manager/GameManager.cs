using OneHourJam.Manager;
using OneHourJam.Map;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneHourJam
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        private Camera _cam;

        [SerializeField]
        private GameObject _mathPrefab;

        [SerializeField]
        private TMP_Text _numberText;

        public int MyNumber => _myNumber;

        private int _myNumber;
        private float _timer;
        private int _opCount;

        private void Awake()
        {
            Instance = this;
            _cam = Camera.main;

            StartCoroutine(SpawnMath());
        }

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        public void AddMath(MathOperator.Operator op, int number)
        {
            _opCount++;
            switch (op)
            {
                case MathOperator.Operator.Plus:
                    _myNumber += number;
                    break;

                case MathOperator.Operator.Minus:
                    _myNumber -= number;
                    break;

                case MathOperator.Operator.Mult:
                    _myNumber *= number;
                    break;

                case MathOperator.Operator.Divide:
                    _myNumber /= number;
                    break;

                default: throw new System.NotImplementedException();
            }

            if (_myNumber == 500)
            {
                CommonManager.ClickAmount = _opCount;
                CommonManager.Time = _timer;
                SceneManager.LoadScene("Victory");
            }

            if (Mathf.Abs(_myNumber) > 1_000_000f)
            {
                SceneManager.LoadScene("Secret");
            }

            UpdateUI();
        }

        private IEnumerator SpawnMath()
        {
            var bounds = CalculateBounds(_cam);
            while (true)
            {
                yield return new WaitForSeconds(.25f);

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
