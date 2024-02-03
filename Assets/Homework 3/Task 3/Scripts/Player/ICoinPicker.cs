namespace Homework3.Task3
{
    public interface ICoinPicker
    {
        public int Coins { get; }

        void Add(int value);
    }
}