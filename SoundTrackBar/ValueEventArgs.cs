namespace SoundTrackBar
{
    public class ValueEventArgs
    {
        public ValueEventArgs(int value) {
            this.Value = value;
        }
        public int Value { get; private set; }
    }
}

