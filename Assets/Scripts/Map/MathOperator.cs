using System.Linq;
using TMPro;
using UnityEngine;

namespace OneHourJam.Map
{
    public class MathOperator : MonoBehaviour
    {
        private TMP_Text _text;
        private Rigidbody2D _rb;

        private Operator _operator;

        private int _number;

        private void Awake()
        {
            _text = GetComponentInChildren<TMP_Text>();
            _rb = GetComponent<Rigidbody2D>();

            if (Random.Range(0, 2) < 0)
            {
                _number = Random.Range(0, 6);
            }
            else
            {
                _number = Random.Range(0, 16);
            }
            var values = System.Enum.GetValues(typeof(Operator)).Cast<Operator>().ToArray();
            _operator = values[Random.Range(0, values.Length)];


            char opChar = _operator switch
            {
                Operator.Plus => '+',
                Operator.Minus => '-',
                Operator.Mult => 'x',
                Operator.Divide => '/',
                _ => throw new System.NotImplementedException()
            };
            _text.text = $"{opChar}{_number}";

            _rb.linearVelocity = Vector2.right * 5f;
        }

        private void OnMouseDown()
        {
            GameManager.Instance.AddMath(_operator, _number);
            Destroy(gameObject);
        }

        private void Update()
        {
            if (transform.position.x > 25f) // Should be good enough
            {
                Destroy(gameObject);
            }
        }

        public enum Operator
        {
            Plus,
            Minus,
            Mult,
            Divide
        }
    }
}
