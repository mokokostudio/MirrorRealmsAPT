using UnityEngine;

namespace ET.Client
{
    public class Drop: MonoBehaviour
    {
        public Vector3 spawnPos = Vector3.zero;
        public Vector3 targetPos = Vector3.zero;
        public float jumpDuration = 1f;
        public float height = 2f;
        public int count = 5;

        private float speed = 0f;

        private float _a = 0;
        private float _b = 0;

        private float _time = 0;

        private void Start()
        {
            this.gameObject.transform.position = this.spawnPos;
            this.CalcSpeed();
            this.CalculateAB();
        }

        private void CalcSpeed()
        {
            var totalTime = 0f;
            var duration = this.jumpDuration;
            for (int i = 0; i < this.count; ++i)
            {
                totalTime += duration;
                duration /= 2;
            }

            this.speed = Vector3.Distance(this.spawnPos, this.targetPos) / totalTime;
        }

        private void CalculateAB()
        {
            _a = -4 * this.height / Mathf.Pow(this.jumpDuration, 2);
            _b = _a * (-1) * this.jumpDuration;
        }

        private void Update()
        {
            if (this.gameObject == null)
            {
                return;
            }

            var xz = this.CalcXZ();
            var y = this.CalcY();

            this.gameObject.transform.position = new Vector3(xz.x, y, xz.y);
            
            if (this.gameObject.transform.position == this.targetPos)
            {
                Destroy(this);
            }
        }

        private Vector2 CalcXZ()
        {
            var pos = Vector3.Lerp(this.transform.position, this.targetPos, Time.deltaTime * this.speed);
            return new Vector2(pos.x, pos.z);
        }

        private float CalcY()
        {
            if (this._time < this.jumpDuration)
            {
                _time += Time.deltaTime;
                var pos = this.spawnPos + (_a * Mathf.Pow(this._time, 2)
                    + _b * _time) * Vector3.up;
                return pos.y;
            }
            else if (this.count > 0)
            {
                this.count--;
                this._time = 0;
                this.height /= 2;
                this.jumpDuration /= 2;
                this.CalculateAB();
            }

            return 0;
        }
    }
}