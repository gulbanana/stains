namespace Stains
{
    struct Pulse
    {
        public double Value;
        private bool decreasing;

        public void Tick(double seconds)
        {
            var diff = seconds % 2.0;
            if (!decreasing)
            {
                Value += diff;
                if (Value > 1.0)
                {
                    decreasing = true;
                    Value -= (Value - 1.0);
                }
            }
            else
            {
                Value -= diff;
                if (Value < 0.0)
                {
                    decreasing = false;
                    Value += (0.0 - Value);
                }
            }
        }
    }
}
